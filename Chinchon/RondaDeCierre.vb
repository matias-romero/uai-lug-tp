Imports Chinchon

''' <summary>
''' Es la ronda en donde cada jugador debe presentar sus combinaciones y computar los puntos
''' </summary>
Public Class RondaDeCierre
    Inherits Ronda

    Friend Sub New(numero As Integer, jugadoresActivos As IEnumerable(Of ManoPorJugador))
        MyBase.New(numero, jugadoresActivos)
    End Sub

    Public Shared Function IsCompatible(ronda As Ronda)
        Return TypeOf ronda Is RondaDeCierre
    End Function
End Class
