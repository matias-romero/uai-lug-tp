Public Class Turno
    Public Event TurnoFinalizado As EventHandler

    Private ReadOnly _jugador As Jugador
    Private ReadOnly _stopwatch As New Stopwatch() 'Utilizo un cronometro para llevar registro de la duración de cada turno

    Public Sub New(jugador As Jugador)
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
