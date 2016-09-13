''' <summary>
''' Una ronda representa una vuelta completa por todos los jugadores de la partida
''' </summary>
Public Class Ronda
    Public Event CambioTurno As EventHandler

    Private _turnoActual As Integer
    Private _jugadoresActivos As Jugador()
    Private _turnosJugados As New List(Of Turno)

    Public Sub New(jugadoresActivos As IEnumerable(Of Jugador))
        _turnoActual = 0
        'Copio los jugadores activos en cada ronda ya que es posible que algunos vayan quedando descalificados
        _jugadoresActivos = jugadoresActivos.ToArray()
    End Sub

    Public ReadOnly Property TurnoActual As Turno
        Get
            Return _turnosJugados(_turnoActual)
        End Get
    End Property

    Public Sub AvanzarTurno()
        _turnoActual += 1
        Dim indiceJugadorActual As Integer = _turnoActual Mod _jugadoresActivos.Count()
        Dim jugadorActual As Jugador = _jugadoresActivos(indiceJugadorActual)
        _turnosJugados.Add(New Turno(jugadorActual))
    End Sub

    ''' <summary>
    ''' El jugador cierra la partida, validando las combinaciones armadas para calcular puntaje
    ''' </summary>
    ''' <param name="jugador">Jugador que realiza el cierre</param>
    ''' ''' <param name="carta">Carta utilizada para el cierre</param>
    Public Sub Cerrar(jugador As Jugador, carta As Carta)
        'TODO
    End Sub
End Class
