Imports Chinchon.Entities

Public Class Turno
    Public Event TurnoFinalizado As EventHandler

    Private ReadOnly _mano As Mano
    Private ReadOnly _jugador As Jugador
    Private ReadOnly _stopwatch As New Stopwatch() 'Utilizo un cronometro para llevar registro de la duración de cada turno

    Public Sub New(jugador As Jugador, mano As Mano)
        _mano = mano
        _jugador = jugador

        _stopwatch.Start()
    End Sub

    ''' <summary>
    ''' Devuelve el jugador del turno
    ''' </summary>
    Public ReadOnly Property Jugador As Jugador
        Get
            Return _jugador
        End Get
    End Property

    Public ReadOnly Property Mano As Mano
        Get
            Return _mano
        End Get
    End Property

    Private _cartaLevantada As Carta
    Public Property CartaLevantada As Carta
        Get
            Return _cartaLevantada
        End Get
        Set(value As Carta)
            _cartaLevantada = value
            Call ComprobarSiTerminoSuTurno()
        End Set
    End Property

    Private _cartaDescartada As Carta
    Public Property CartaDescartada As Carta
        Get
            Return _cartaDescartada
        End Get
        Set(value As Carta)
            _cartaDescartada = value
            Call ComprobarSiTerminoSuTurno()
        End Set
    End Property

    Private Sub ComprobarSiTerminoSuTurno()
        If Me.CartaLevantada IsNot Nothing AndAlso Me.CartaDescartada IsNot Nothing Then
            Call Me.Mano.IntercambiarCarta(Me.CartaDescartada, me.CartaLevantada)
            Call Me.FinalizarTurno()
        End If
    End Sub

    ''' <summary>
    ''' Devuelve el tiempo transcurrido durante el turno
    ''' </summary>
    Public ReadOnly Property TiempoTranscurrido As TimeSpan
        Get
            Return _stopwatch.Elapsed
        End Get
    End Property

    Public Sub FinalizarTurno()
        _stopwatch.Stop()
        Me.OnTurnoFinalizado()
    End Sub

    Private Sub OnTurnoFinalizado()
        RaiseEvent TurnoFinalizado(Me, EventArgs.Empty)
    End Sub
End Class
