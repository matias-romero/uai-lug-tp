Imports Chinchon.Entities
Imports Chinchon.Exceptions

''' <summary>
''' Fijado en el alcance, las barajas son siempre españolas y de 50 cartas (12 de cada palo y dos comodines)
''' </summary>
Public Class Baraja
    Implements IBaraja
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
        _cartas.Sort()
    End Sub

    ''' <summary>
    ''' Mezcla el orden de las cartas en la baraja utilizando el barajador por defecto
    ''' </summary>
    Public Sub Barajar()
        _barajadorPorDefecto.Barajar(_cartas)
    End Sub

    ''' <summary>
    ''' Toma la última carta de la baraja
    ''' </summary>
    Public Function TomarCarta() As Carta Implements IBaraja.TomarCarta
        Return Me.TomarCartas(1).Single()
    End Function

    ''' <summary>
    ''' Toma las n últimas cartas de la baraja
    ''' </summary>
    ''' <param name="cantidad">Cantidad de cartas a extraer</param>
    Public Function TomarCartas(cantidad As Integer) As Carta()
        If _cartas.Count < cantidad Then
            Throw New NoHaySuficientesCartasException()
        End If

        Dim cartasTomadas As Carta() = Me.TomarUltimasCartas(cantidad).ToArray()
        _cartas.RemoveRange(_cartas.Count - cartasTomadas.Length, cartasTomadas.Length)
        Return cartasTomadas
    End Function

    ''' <summary>
    ''' Devuelve la última carta de la baraja (Proxima para tomar)
    ''' </summary>
    Public ReadOnly Property ProximaCarta As Carta Implements IBaraja.ProximaCarta
        Get
            If Me.EstaVacio Then 'Para evitar la InvalidOperationException cuando la pila esta vacia
                Return Nothing
            End If

            Return Me.TomarUltimasCartas(1).Single()
        End Get
    End Property

    ''' <summary>
    ''' Repone las cartas indicadas de nuevo en la baraja y las mezcla utilizando el barajador por defecto
    ''' </summary>
    ''' <param name="cartas">Cartas devueltas</param>
    Public Sub DevolverCartas(cartas As IEnumerable(Of Carta))
        _cartas.AddRange(cartas)
        Call Me.Barajar()
    End Sub

    Private ReadOnly Property EstaVacio As Boolean
        Get
            Return _cartas.Count = 0
        End Get
    End Property

    Private Function TomarUltimasCartas(cantidad As Integer) As IEnumerable(Of Carta)
        Return _cartas.Skip(Math.Max(0, _cartas.Count - cantidad))
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
