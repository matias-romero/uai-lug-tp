''' <summary>
''' Modela las 7 cartas en juego por cada jugador
''' </summary>
Public Class Mano
    Private ReadOnly _cartas As New List(Of Carta)

    Public Sub New(cartas As IEnumerable(Of Carta))
        _cartas.AddRange(cartas.Take(7))
    End Sub

    Public ReadOnly Property Cartas As IEnumerable(Of Carta)
        Get
            Return _cartas
        End Get
    End Property
End Class
