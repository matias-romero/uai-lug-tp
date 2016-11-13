Imports Chinchon.Combinaciones
Imports Chinchon.Entities

''' <summary>
''' Modela las 7 cartas en juego por cada jugador
''' </summary>
Public Class Mano
    Private ReadOnly _cartas As New List(Of Carta)
    Private ReadOnly _combinaciones As New List(Of Combinacion)

    Public Sub New(cartas As IEnumerable(Of Carta))
        _cartas.AddRange(cartas.Take(7))
    End Sub

    Public ReadOnly Property Cartas As IEnumerable(Of Carta)
        Get
            Return _cartas
        End Get
    End Property

    Public ReadOnly Property Combinaciones As IEnumerable(Of Combinacion)
        Get
            Return _combinaciones
        End Get
    End Property

    ''' <summary>
    ''' Devuelve todas las cartas que no forman parte de alguna combinacion
    ''' </summary>
    Public ReadOnly Property CartasSinCombinar As IEnumerable(Of Carta)
        Get
            Return Me.Cartas.Where(Function(carta) Not Me.EstaCombinada(carta))
        End Get
    End Property

    ''' <summary>
    ''' Determina si la carta está formando alguna de las combinaciones
    ''' </summary>
    Public Function EstaCombinada(carta As Carta) As Boolean
        Return _combinaciones.Any(Function(c) c.TieneLaCarta(carta))
    End Function

    ''' <summary>
    ''' Realiza el intercambio entre una carta que tengo en la mano por otra carta externa
    ''' </summary>
    ''' <param name="cartaEnMano">Carta que tengo en mi mano</param>
    ''' <param name="cartaExterna">Carta por la cual deseo cambiar</param>
    Public Overloads Function IntercambiarCarta(cartaEnMano As Carta, cartaExterna As Carta) As Carta
        Dim indice As Integer = _cartas.IndexOf(cartaEnMano)
        Return Me.IntercambiarCarta(indice, cartaExterna)
    End Function

    ''' <summary>
    ''' Realiza el intercambio entre una carta que tengo en la mano por otra carta externa
    ''' </summary>
    ''' <param name="indice">Indica el indice de carta en mano entre 0..6 </param>
    ''' <param name="cartaExterna">Recibe la carta externa</param>
    ''' <returns>Devuelve la carta que se sacó de la mano</returns>
    Public Overloads Function IntercambiarCarta(indice As Integer, cartaExterna As Carta) As Carta
        If indice > 6 Or indice < 0 Then
            Throw New ArgumentOutOfRangeException("indice", indice, "El indice de carta en mano debe estar entre 0 y 6")
        End If

        If cartaExterna Is Nothing Then
            Throw New ArgumentNullException("cartaExterna", "Debe indicar la carta que quiere intercambiar")
        End If

        'Analizo si la carta que me pasa ya la tengo en otra posicion de mi mano para intercambiar lugares
        Dim indiceExterna As Integer = _cartas.IndexOf(cartaExterna)
        Dim carta As Carta = _cartas(indice)
        _cartas(indice) = cartaExterna

        If indiceExterna >= 0 Then
            _cartas(indiceExterna) = carta
        End If

        Return carta
    End Function

    Public Sub RegistrarCombinacion(combinacion As Combinacion)
        _combinaciones.Add(combinacion)
    End Sub

    Public Sub DeshacerCombinacion(combinacion As Combinacion)
        _combinaciones.Remove(combinacion)
    End Sub
End Class
