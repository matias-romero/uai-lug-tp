Imports Chinchon

''' <summary>
''' Es la ronda en donde cada jugador debe presentar sus combinaciones y computar los puntos
''' </summary>
Public Class RondaDeCierre
    Inherits Ronda

    friend Sub New(numero As Integer, jugadoresActivos As IEnumerable(Of ManoPorJugador))
        MyBase.New(numero, jugadoresActivos)
    End Sub
End Class
