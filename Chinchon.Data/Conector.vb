Imports System.Data.Common
Imports System.Text.RegularExpressions

''' <summary>
''' Encapsula la conexion con el repositorio de datos
''' </summary>
Public Class Conector
    Implements IConector

    'Defino el proveedor ADO.NET compatible que utilizara la capa de persistencia y lo trabajo agnóstico al motor de DB
    Public Shared Property ProveedorPorDefecto As DbProviderFactory = SqlClient.SqlClientFactory.Instance
    Private ReadOnly PatronConsultaDML As New Regex("(INSERT|SELECT|UPDATE|DELETE)\s+", RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    Private _conexion As DbConnection

    Public Sub New(cnnString As String)
        _conexion = ProveedorPorDefecto.CreateConnection()
        _conexion.ConnectionString = cnnString
    End Sub

    ''' <summary>
    ''' Creo un nuevo parametro dependiente del proveedor de datos configurado
    ''' </summary>
    ''' <param name="nombre">Nombre representativo del parametro</param>
    ''' <param name="valor">Valor del parametro</param>
    ''' <returns>Devuelve el nuevo parámetro para ser incluido en el comando</returns>
    Public Function CrearNuevoParametro(nombre As String, valor As Object) As IDbDataParameter Implements IConector.CrearNuevoParametro
        Dim parametro As IDbDataParameter = ProveedorPorDefecto.CreateParameter()
        parametro.ParameterName = nombre
        parametro.Value = valor
        Return parametro
    End Function

    ''' <summary>
    ''' Ejecuta una consulta de lectura esperando al menos un set de resultados
    ''' </summary>
    ''' <param name="consulta">Consulta en lenguaje SQL</param>
    ''' <param name="parametros">Listado opcional de parámetros incluidos en la consulta</param>
    ''' <returns>Devuelve el set de datos afectados por la consulta en una tabla en memoria, desconectada del repositorio</returns>
    Public Function LeerResultados(consulta As String, ParamArray parametros As IDbDataParameter()) As DataTable Implements IConector.LeerResultados
        Dim comando As IDbCommand = Me.CrearComandoParaConsulta(consulta, parametros)
        Dim adaptadorTabla As IDbDataAdapter = ProveedorPorDefecto.CreateDataAdapter()
        adaptadorTabla.SelectCommand = comando

        'Requiero un DataSet completo dado que IDbDataAdapter no soporta la sobrecarga del fill con una sola tabla
        Dim dataSet As DataSet = New DataSet()
        EstablecerConexionDuranteEjecucion(Sub() adaptadorTabla.Fill(dataSet))

        Return dataSet.Tables(0)
    End Function

    ''' <summary>
    ''' Ejecuta una consulta de lectura esperando un único resultado escalar
    ''' </summary>
    ''' <param name="consulta">Consulta en lenguaje SQL</param>
    ''' <param name="parametros">Listado opcional de parámetros incluidos en la consulta</param>
    ''' <returns>Devuelve el valor escalar que retorne la consulta</returns>
    Public Function LeerEscalar(Of T)(consulta As String, ParamArray parametros As IDbDataParameter()) As T Implements IConector.LeerEscalar
        Dim valorEscalar As Object = Nothing
        Dim comando As IDbCommand = Me.CrearComandoParaConsulta(consulta, parametros)

        'Requiero un DataSet completo dado que IDbDataAdapter no soporta la sobrecarga del fill con una sola tabla
        EstablecerConexionDuranteEjecucion(Sub() valorEscalar = comando.ExecuteScalar())

        'Un caso de null en db, debe ser una nullreference en vb.net, caso contrario me devuelve el dato convertido en el tipo esperado
        If DBNull.Value.Equals(valorEscalar) Then
            Return Nothing
        End If
        Return Convert.ChangeType(valorEscalar, GetType(T))
    End Function

    ''' <summary>
    ''' Ejecuta una consulta de modificacion contra el repositorio de datos
    ''' </summary>
    ''' <param name="consulta">Consulta de modificacion en lenguaje SQL</param>
    ''' <param name="parametros">Listado opcional de parámetros incluidos en la consulta</param>
    ''' <returns>Devuelve la cantidad de filas afectadas por la consulta</returns>
    Public Function ModificarFilas(consulta As String, ParamArray parametros As IDbDataParameter()) As Integer Implements IConector.ModificarFilas
        Dim filasAfectadas As Integer
        Dim comandoABM As IDbCommand = Me.CrearComandoParaConsulta(consulta, parametros)

        EstablecerConexionDuranteEjecucion(Sub() filasAfectadas = comandoABM.ExecuteNonQuery())

        Return filasAfectadas
    End Function

    'Reutilizo la creación de cada Command
    Private Function CrearComandoParaConsulta(consulta As String, parametros As IDbDataParameter()) As IDbCommand
        'Determino el tipo de comando basado en la consulta y desligo la responsabilidad al consumidor
        Dim tipoComando As CommandType = IIf(PatronConsultaDML.IsMatch(consulta), CommandType.Text, CommandType.StoredProcedure)
        Dim nuevoComando As IDbCommand = _conexion.CreateCommand()
        nuevoComando.CommandType = tipoComando
        nuevoComando.CommandText = consulta

        'Si me indicaron al menos un parámetro, los agrego al comando
        If parametros IsNot Nothing AndAlso parametros.Any() Then
            For Each dataParameter As IDbDataParameter In parametros
                nuevoComando.Parameters.Add(dataParameter)
            Next
        End If
        Return nuevoComando
    End Function

    'Ejecuto la instrucción bajo un contexto conectado y libero la conexión
    Private Sub EstablecerConexionDuranteEjecucion(accionConectada As Action)
        Try
            _conexion.Open()
            accionConectada.Invoke()
        Finally
            If (_conexion.State <> ConnectionState.Closed) Then
                _conexion.Close()
            End If
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                _conexion.Dispose()
            End If
            _conexion = Nothing
        End If
        disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
    End Sub
#End Region

End Class
