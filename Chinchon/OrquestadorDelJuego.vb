Imports Chinchon.Configuracion
Imports Chinchon.Entities

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

    Private ReadOnly _partidaActual As Partida
    Private _factoriaRepositorios As IFactoriaRepositorios

    Public Sub New()
        _partidaActual = New Partida()
    End Sub

    Public ReadOnly Property PartidaActual As Partida
        Get
            Return _partidaActual
        End Get
    End Property

    Public ReadOnly Property Repositorios As IFactoriaRepositorios
        Get
            'TODO: Contemplar que si no definió alguno explicitamente utilice un modelo InMemory
            Return _factoriaRepositorios
        End Get
    End Property

    Public Sub UtilizarRepositoriosUsandoCadenaDeConexion(cadenaConexion As String)
        _factoriaRepositorios = New FactoriaRepositorioSQL(cadenaConexion)
    End Sub

    ''' <summary>
    ''' Recibe el gesto realizado por el jugador y efectua la jugada esperada en la partida
    ''' </summary>
    ''' <param name="carta">Carta en cuestión</param>
    ''' <param name="origen">Desde donde se tomó la carta</param>
    ''' <param name="destino">Lugar donde se depositó la carta</param>
    ''' <returns></returns>
    Public Function EfectuarJugada(carta As Carta, origen As Object, destino As Object) As Boolean

    End Function
End Class
