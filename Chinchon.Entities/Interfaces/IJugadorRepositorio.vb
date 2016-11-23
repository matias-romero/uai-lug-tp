Public Interface IJugadorRepositorio
    Function RegistrarNuevo(usuario As String, password As string) As Jugador
    Function ValidarCredenciales(usuario As String, password As String) As Jugador
    Sub Actualizar(jugador As Jugador)
End Interface
