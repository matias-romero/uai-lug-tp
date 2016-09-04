Imports Chinchon

''' <summary>
''' Implementación del mezclador de cartas utilizando una version del algoritmo "Fisher–Yates shuffle"
''' </summary>
Public Class BarajadorPorAzar
    Implements IBarajador

    Private Shared ReadOnly RandomNumberGenerator = New Random()

    Public Shared Sub Shuffle(Of T)(list As IList(Of T))
        Dim n As Integer = list.Count

        While (n > 1)
            n -= 1
            Dim k As Integer = RandomNumberGenerator.Next(n + 1)
            Dim value As T = list(k)
            list(k) = list(n)
            list(n) = value
        End While
    End Sub

    Public Sub Barajar(cartas As IList(Of Carta)) Implements IBarajador.Barajar
        Call Shuffle(cartas)
    End Sub
End Class
