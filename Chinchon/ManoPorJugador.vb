Imports Chinchon.Entities

Friend Class ManoPorJugador
    Private ReadOnly _jugador As Jugador

    Public Sub New(unJugador As Jugador)
        _jugador = unJugador
    End Sub

    Public ReadOnly Property Jugador As Jugador
        Get
            Return _jugador
        End Get
    End Property

    Public Property PuntajeAcumulado as Integer 

    Public Property Mano As Mano
End Class
