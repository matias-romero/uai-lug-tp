''' <summary>
''' Modela una entrada de actividad por parte de un jugador en una partida. Sirve para fines estadísticos
''' </summary>
Public Class ParticipacionJugadorEnPartida
    public Property Id as Integer

    Public Property IdentificadorPartida as Guid

    Public Property TiempoDeJuegoNeto as TimeSpan

    Public Property PuntosAcumulados As Integer

    Public Property FueGanador As Boolean
End Class
