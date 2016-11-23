Imports Chinchon.Entities
Imports Chinchon.Entities.Exceptions

Public Class JugadorRepositorio
    Implements IJugadorRepositorio

    Private ReadOnly _conector As IConector

    Public Sub New(conector As IConector)
        _conector = conector
    End Sub
    
    ''' <summary>
    ''' Actualiza los datos del jugador en el repositorio
    ''' </summary>
    ''' <param name="jugador">Jugador a registrar</param>
    Public Sub Actualizar(jugador As Jugador) Implements IJugadorRepositorio.Actualizar
        Throw New NotImplementedException()
    End Sub

    ''' <summary>
    ''' Crea un nuevo jugador utilizando las credenciales indicadas
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    Public Function RegistrarNuevo(usuario As String, password As String) As Jugador Implements IJugadorRepositorio.RegistrarNuevo
        Throw New NotImplementedException()
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
            Dim repositorioParticipaciones As New ParticipacionJugadorRepositorio(_conector)
            repositorioParticipaciones.CargarParticipacionesPorJugador(jugador)
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
End Class
