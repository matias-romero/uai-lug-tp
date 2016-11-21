Imports Chinchon.Entities

''' <summary>
''' El turno registra la jugada realizada por un jugador dentro de la ronda
''' </summary>
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

    ''' <summary>
    ''' Devuelve las cartas en la mano del jugador
    ''' </summary>
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

    Private _cartaDescartadaParaCierre As Carta
    Public Property CartaDescartadaParaCierre As Carta
        Get
            Return _cartaDescartadaParaCierre
        End Get
        Set(value As Carta)
            _cartaDescartadaParaCierre = value
            Call ComprobarSiTerminoSuTurno()
        End Set
    End Property

    'Le doy semántica al cierre
    Public ReadOnly Property RealizoUnCierre As Boolean
        Get
            Return Me.CartaDescartadaParaCierre IsNot Nothing
        End Get
    End Property

    Private Sub ComprobarSiTerminoSuTurno()
        'Debo haber levantado y descartado una carta para considerar que jugó
        If Me.CartaLevantada IsNot Nothing Then
            If Me.CartaDescartada IsNot Nothing Then 'Descarta en el pozo
                If Not Me.CartaLevantada.Equals(Me.CartaDescartada) Then
                    Call Me.Mano.IntercambiarCarta(Me.CartaDescartada, Me.CartaLevantada)
                End If

                Call Me.FinalizarTurno()

            ElseIf Me.CartaDescartadaParaCierre IsNot Nothing Then 'Descarta para un cierre
                If Not Me.CartaLevantada.Equals(Me.CartaDescartadaParaCierre) Then
                    Call Me.Mano.IntercambiarCarta(Me.CartaDescartadaParaCierre, Me.CartaLevantada)
                End If

                Call Me.FinalizarTurno()

            End If
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

    Private Sub FinalizarTurno()
        _stopwatch.Stop()
        Me.OnTurnoFinalizado()
    End Sub

    Private Sub OnTurnoFinalizado()
        RaiseEvent TurnoFinalizado(Me, EventArgs.Empty)
    End Sub
End Class
