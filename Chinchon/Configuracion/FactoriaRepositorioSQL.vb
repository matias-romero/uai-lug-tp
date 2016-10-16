Imports Chinchon.Data
Imports Chinchon.Entities

Namespace Configuracion

    ''' <summary>
    ''' Implementación de los Repositorios utilizando un repositorio SQL subyacente
    ''' </summary>
    Public Class FactoriaRepositorioSQL
        Implements IFactoriaRepositorios

        Private ReadOnly _cadenaConexion As String

        Public Sub New(cadenaConexion As String)
            _cadenaConexion = cadenaConexion
        End Sub

        Public Function Jugadores() As IJugadorRepositorio Implements IFactoriaRepositorios.Jugadores
            Return New JugadorRepositorio(New Conector(_cadenaConexion))
        End Function
    End Class
End Namespace