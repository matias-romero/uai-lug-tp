Imports Chinchon.Configuracion

'Dedicado para servir de "contenedor" que le brinde una interfaz simplificada a los consumidores
Public Class OrquestadorDelJuego
#Region "Singleton configurable"
    Private Shared _InstanciaPorDefecto As OrquestadorDelJuego

    Public Shared Property InstanciaPorDefecto As OrquestadorDelJuego
        Get
            If _InstanciaPorDefecto Is Nothing Then
                _InstanciaPorDefecto = New OrquestadorDelJuego()
            End If

            Return _InstanciaPorDefecto
        End Get
        Set(value As OrquestadorDelJuego)
            _InstanciaPorDefecto = value
        End Set
    End Property
#End Region

    Private _partidaActual As Partida
    Private _factoriaRepositorios As IFactoriaRepositorios
    
    Public ReadOnly Property PartidaActual As Partida
        Get
            Return _partidaActual
        End Get
    End Property
    
    Public sub CambiarPartidaActual(otraPartida As Partida)
        _partidaActual = otraPartida
    End sub

    Public ReadOnly Property Repositorios As IFactoriaRepositorios
        Get
            'TODO: Contemplar que si no definió alguno explicitamente utilice un modelo InMemory
            Return _factoriaRepositorios
        End Get
    End Property

    Public Sub UtilizarRepositoriosUsandoCadenaDeConexion(cadenaConexion As String)
        _factoriaRepositorios = New FactoriaRepositorioSQL(cadenaConexion)
    End Sub
End Class
