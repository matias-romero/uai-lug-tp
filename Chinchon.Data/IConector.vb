Public interface IConector
    Inherits IDisposable

    ''' <summary>
    ''' Creo un nuevo parametro dependiente del proveedor de datos configurado
    ''' </summary>
    ''' <param name="nombre">Nombre representativo del parametro</param>
    ''' <param name="valor">Valor del parametro</param>
    ''' <returns>Devuelve el nuevo parámetro para ser incluido en el comando</returns>
    Function CrearNuevoParametro(nombre As String, valor As Object) As IDbDataParameter

    ''' <summary>
    ''' Ejecuta una consulta de lectura esperando al menos un set de resultados
    ''' </summary>
    ''' <param name="consulta">Consulta en lenguaje SQL</param>
    ''' <param name="parametros">Listado opcional de parámetros incluidos en la consulta</param>
    ''' <returns>Devuelve el set de datos afectados por la consulta en una tabla en memoria, desconectada del repositorio</returns>
    Function LeerResultados(consulta As String, ParamArray parametros As IDbDataParameter()) As DataTable

    ''' <summary>
    ''' Ejecuta una consulta de lectura esperando un único resultado escalar
    ''' </summary>
    ''' <param name="consulta">Consulta en lenguaje SQL</param>
    ''' <param name="parametros">Listado opcional de parámetros incluidos en la consulta</param>
    ''' <returns>Devuelve el valor escalar que retorne la consulta</returns>
    Function LeerEscalar(Of T)(consulta As String, ParamArray parametros As IDbDataParameter()) As T

    ''' <summary>
    ''' Ejecuta una consulta de modificacion contra el repositorio de datos
    ''' </summary>
    ''' <param name="consulta">Consulta de modificacion en lenguaje SQL</param>
    ''' <param name="parametros">Listado opcional de parámetros incluidos en la consulta</param>
    ''' <returns>Devuelve la cantidad de filas afectadas por la consulta</returns>
    Function ModificarFilas(consulta As String, ParamArray parametros As IDbDataParameter()) As Integer
End interface