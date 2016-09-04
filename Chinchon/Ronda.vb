''' <summary>
''' Una ronda representa una vuelta completa por todos los jugadores de la partida
''' </summary>
Public Class Ronda
    Private _turnoActual As Integer
    Private _jugadoresActivos As Jugador()

    Public Sub New(jugadoresActivos As IEnumerable(Of Jugador))
        'Copio los jugadores activos en cada ronda ya que es posible que algunos vayan quedando descalificados
        _jugadoresActivos = jugadoresActivos.ToArray()
        _turnoActual = 0
    End Sub
End Class
