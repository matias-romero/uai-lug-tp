Imports Chinchon
Imports Chinchon.Entities

''' <summary>
''' Fijado en el alcance, las barajas son siempre españolas y de 50 cartas (12 de cada palo y dos comodines)
''' </summary>
Public Class Baraja
    Implements IEnumerable(Of Carta)

    Public Const CantidadCartasTotales As Integer = 50

    Private ReadOnly _cartas As New List(Of Carta)
    Private ReadOnly _barajadorPorDefecto As IBarajador

    Public Sub New()
        Me.New(New BarajadorPorAzar())
    End Sub

    Public Sub New(barajadorPorDefecto As IBarajador)
        _barajadorPorDefecto = barajadorPorDefecto

        'Cargo las 12 cartas por cada Palo
        For i = 1 To 12
            _cartas.Add(New Carta(i, Palo.Oro))
            _cartas.Add(New Carta(i, Palo.Copa))
            _cartas.Add(New Carta(i, Palo.Espada))
            _cartas.Add(New Carta(i, Palo.Basto))
        Next

        'Agrego los dos comodines
        _cartas.Add(New CartaComodin())
        _cartas.Add(New CartaComodin())
    End Sub

    ''' <summary>
    ''' Mezcla el orden de las cartas en la baraja utilizando el barajador por defecto
    ''' </summary>
    Public Sub Barajar()
        _barajadorPorDefecto.Barajar(_cartas)
    End Sub

    Public Function TomarCarta() As Carta
        Return Me.TomarCartas(1).Single()
    End Function

    Public Function TomarCartas(cantidad As Integer) As Carta()
        Dim cartasTomadas As Carta() = _cartas.Take(cantidad).ToArray()
        _cartas.RemoveRange(0, cartasTomadas.Length)
        Return cartasTomadas
    End Function

#Region "Implemento IEnumerable para poder foreachear la baraja"
    Public Function GetEnumerator() As IEnumerator(Of Carta) Implements IEnumerable(Of Carta).GetEnumerator
        Return _cartas.GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return Me.GetEnumerator()
    End Function
#End Region
End Class
