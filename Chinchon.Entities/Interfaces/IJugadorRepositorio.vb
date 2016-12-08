Public Interface IJugadorRepositorio
    Function ExisteApodo(apodo As String) As Boolean
    Function RegistrarNuevo(usuario As String, password As string) As Jugador
    Function ValidarCredenciales(usuario As String, password As String) As Jugador
    Sub Actualizar(jugador As Jugador)
    Sub Actualizar(jugadores As IEnumerable(Of Jugador))
End Interface
