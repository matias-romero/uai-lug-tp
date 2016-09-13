Imports Chinchon.Data

Public Class Sesion
    Public Shared Property DefaultInstance As Sesion = New Sesion()

    Private ReadOnly _cadenaConexionDb As String

    Public Sub New()
        _cadenaConexionDb = My.Settings.RepositorioPrincipal
    End Sub

    Public Function RepositorioJugadores() As JugadorRepositorio
        Return New JugadorRepositorio(New Conector(_cadenaConexionDb))
    End Function
End Class
