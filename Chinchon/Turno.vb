Imports Chinchon.Entities

''' <summary>
''' El turno registra la jugada realizada por un jugador dentro de la ronda
''' </summary>
Public Class Turno
    Public Event TurnoFinalizado As EventHandler

    Private ReadOnly _mano As Mano
    Private ReadOnly _jugador As Jugador
    Private ReadOnly _stopwatch As New Stopwatch() 'Utilizo un cronometro para llevar registro de la duración de cada turno

    Private _cartaLevantada As Carta
    Private _cartaDescartada As Carta
    Private _cartaDescartadaParaCierre As Carta

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

    ''' <summary>
    ''' Devuelve o establece la carta que se levantó en este turno
    ''' </summary>
    Public Property CartaLevantada As Carta
        Get
            Return _cartaLevantada
        End Get
        Set(value As Carta)
            _cartaLevantada = value
            Call ComprobarSiTerminoSuTurno()
        End Set
    End Property

    ''' <summary>
    ''' Devuelve o establece la carta que se descartó al montón en este turno
    ''' </summary>
    Public Property CartaDescartada As Carta
        Get
            Return _cartaDescartada
        End Get
        Set(value As Carta)
            _cartaDescartada = value
            Call ComprobarSiTerminoSuTurno()
        End Set
    End Property

    ''' <summary>
    ''' Devuelve o establece la carta que se utilizó para cerrar en este turno
    ''' </summary>
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

    ''' <summary>
    ''' Devuelve el tiempo transcurrido durante este turno
    ''' </summary>
    Public ReadOnly Property TiempoTranscurrido As TimeSpan
        Get
            Return _stopwatch.Elapsed
        End Get
    End Property

    Private Sub ComprobarSiTerminoSuTurno()
        'Debo haber levantado y descartado una carta para considerar que jugó
        If Me.CartaLevantada IsNot Nothing Then
            Dim descarte As Carta = Nothing
            If Me.CartaDescartada IsNot Nothing Then 'Descarta en el pozo
                descarte = Me.CartaDescartada
            ElseIf Me.CartaDescartadaParaCierre IsNot Nothing Then 'Descarta para un cierre
                descarte = Me.CartaDescartadaParaCierre
            End If

            'Analizo si hubo algún tipo de descarte
            If descarte IsNot Nothing Then
                If Not Me.CartaLevantada.Equals(descarte) Then
                    Call Me.Mano.IntercambiarCarta(descarte, Me.CartaLevantada)
                End If

                Call Me.FinalizarTurno()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Notifica que finalizó el turno
    ''' </summary>
    Friend Sub FinalizarTurno()
        _stopwatch.Stop()
        RaiseEvent TurnoFinalizado(Me, EventArgs.Empty)
    End Sub
End Class
