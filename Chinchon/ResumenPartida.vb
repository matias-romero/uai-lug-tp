Imports Chinchon.Entities

''' <summary>
''' Encapsula la visión general de la partida en forma de resumen
''' </summary>
Public Class ResumenPartida
    Private ReadOnly _unaPartida As Partida

    Public Sub New(unaPartida As Partida)
        _unaPartida = unaPartida
    End Sub

    Public ReadOnly Property Id As Guid
        Get
            Return _unaPartida.Id
        End Get
    End Property

    ''' <summary>
    ''' Devuelve verdadero indicando que la partida finalizó
    ''' </summary>
    Public ReadOnly Property FueFinalizada As Boolean
        Get
            Return _unaPartida.JugadoresActivos.Count() = 1
        End Get
    End Property

    ''' <summary>
    ''' Devuelve al ganador de la partida o bien Nothing si todavía no fue determinado
    ''' </summary>
    Public ReadOnly Property Ganador As Jugador
        Get
            If Me.FueFinalizada Then
                Return _unaPartida.JugadoresActivos.Single()
            End If

            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Devuelve todos los jugadores que participaron de la partida
    ''' </summary>
    Public ReadOnly Property Participantes As IEnumerable(Of Jugador)
        Get
            Return _unaPartida.JugadoresRegistrados
        End Get
    End Property

    ''' <summary>
    ''' Devuelve la participacion del jugador en esta partida
    ''' </summary>
    ''' <param name="jugador">Participante de la partida</param>
    Public Function VerParticipacionDelJugador(jugador As Jugador) As ParticipacionJugadorEnPartida
        Return jugador.ParticipacionesRegistradasEnPartidas.SingleOrDefault(Function(p) p.IdentificadorPartida.Equals(Me.Id))
    End Function
End Class
