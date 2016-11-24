Imports Chinchon.Entities
Imports Chinchon.Entities.Exceptions

Public Class JugadorRepositorio
    Implements IJugadorRepositorio

    Private ReadOnly _conector As IConector
    Private ReadOnly _repositorioParticipaciones As ParticipacionJugadorRepositorio

    Public Sub New(conector As IConector)
        Me.New(conector, New ParticipacionJugadorRepositorio(conector))
    End Sub

    Private Sub New(conector As IConector, repositorioParticipaciones As ParticipacionJugadorRepositorio)
        _conector = conector
        _repositorioParticipaciones = repositorioParticipaciones
    End Sub

    Public Function ExisteApodo(apodo As String) As Boolean Implements IJugadorRepositorio.ExisteApodo
        Return Me.ConsultarJugador(apodo) IsNot Nothing
    End Function

    ''' <summary>
    ''' Actualiza los datos del jugador en el repositorio
    ''' </summary>
    ''' <param name="jugador">Jugador por actualizar</param>
    Public Sub Actualizar(jugador As Jugador) Implements IJugadorRepositorio.Actualizar
        If jugador.Id.Equals(0) Then 'Es nuevo
            Throw New ArgumentException("El jugador por actualizar debe existir en la base")
        End If

        'Las credenciales no pueden ser modificadas por acá, por eso solo actualizo las estadísticas
        _repositorioParticipaciones.ActualizarParticipacionesPorJugador(jugador)
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un grupo de jugadores como un bloque
    ''' </summary>
    ''' <param name="jugadores">Listado de jugadores por actualizar</param>
    Public Sub Actualizar(jugadores As IEnumerable(Of Jugador)) Implements IJugadorRepositorio.Actualizar
        For Each jugador As Jugador In jugadores
            Call Me.Actualizar(jugador)
        Next
    End Sub

    ''' <summary>
    ''' Crea un nuevo jugador utilizando las credenciales indicadas
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="password"></param>
    ''' <returns>Retorna el jugador recien registrado</returns>
    Public Function RegistrarNuevo(usuario As String, password As String) As Jugador Implements IJugadorRepositorio.RegistrarNuevo
        'Analizo si el apodo ya existe
        Dim jugadorExistente As Jugador = Me.ConsultarJugador(usuario)
        If jugadorExistente Is Nothing Then
            'Registro al nuevo usuario
            jugadorExistente = New Jugador()
            jugadorExistente.Id = Me.CalcularProximoID()
            jugadorExistente.Apodo = usuario

            Const consultaInsert As String = "INSERT INTO JUGADOR (ID, APODO, PASSWORDHASH) VALUES(@ID, @APODO, @HASH)"
            Dim parametroId As IDbDataParameter = _conector.CrearNuevoParametro("@ID", jugadorExistente.Id)
            Dim parametroUsuario As IDbDataParameter = _conector.CrearNuevoParametro("@APODO", jugadorExistente.Apodo)
            Dim parametroHash As IDbDataParameter = _conector.CrearNuevoParametro("@HASH", password) 'TODO: Aplicarle el hashing
            Dim filasAfectadas As Integer = _conector.ModificarFilas(consultaInsert, parametroId, parametroUsuario, parametroHash)
            If filasAfectadas = 1 Then
                Return jugadorExistente
            End If
        End If

        Throw New ApodoJugadorExistenteException(usuario)
    End Function

    ''' <summary>
    ''' Comprueba las credenciales del jugador registrado
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="password"></param>
    ''' <returns></returns> 
    Public Function ValidarCredenciales(usuario As String, password As String) As Jugador Implements IJugadorRepositorio.ValidarCredenciales
        Const consulta As String = "SELECT ID, APODO FROM JUGADOR WHERE APODO=@APODO AND PASSWORDHASH=@HASH"
        Dim parametroUsuario As IDbDataParameter = _conector.CrearNuevoParametro("@APODO", usuario)
        Dim parametroHash As IDbDataParameter = _conector.CrearNuevoParametro("@HASH", password) 'TODO: Aplicarle el hashing
        Dim tabla As DataTable = _conector.LeerResultados(consulta, parametroUsuario, parametroHash)

        If tabla.Rows.Count = 1 Then
            Dim jugador As Jugador = Me.MaterializarJugadorDesdeDataRow(tabla.Rows(0))
            _repositorioParticipaciones.CargarParticipacionesPorJugador(jugador)
            Return jugador
        End If

        Throw New CredencialesInvalidasException()
    End Function

    Private Function MaterializarJugadorDesdeDataRow(dataRow As DataRow) As Jugador
        Dim jugador As New Jugador()
        jugador.Id = dataRow.Item("ID")
        jugador.Apodo = dataRow.Item("APODO")
        Return jugador
    End Function

    Private Function CalcularProximoID() As Integer
        Const consulta As String = "SELECT ISNULL(MAX(ID),0) + 1 AS ID FROM JUGADOR"
        Return _conector.LeerEscalar(Of Integer)(consulta)
    End Function

    Private Function ConsultarJugador(apodo As String) As Jugador
        Const consulta As String = "SELECT ID, APODO FROM JUGADOR WHERE APODO=@APODO"
        Dim parametroUsuario As IDbDataParameter = _conector.CrearNuevoParametro("@APODO", apodo)
        Dim tabla As DataTable = _conector.LeerResultados(consulta, parametroUsuario)

        If tabla.Rows.Count = 1 Then
            Dim jugador As Jugador = Me.MaterializarJugadorDesdeDataRow(tabla.Rows(0))
            _repositorioParticipaciones.CargarParticipacionesPorJugador(jugador)
            Return jugador
        End If

        Return Nothing
    End Function
End Class
