Namespace Combinaciones

    ''' <summary>
    ''' Un pie o trío es cuando tengo tres o cuatro cartas con el mismo número (y distinto palo)
    ''' </summary>
    Public Class Pie
        Inherits Combinacion

        Public Overrides ReadOnly Property MaximoCartasPermitidas As Integer
            Get
                Return 4
            End Get
        End Property

        Public Overrides Function EsValida() As Boolean
            Dim cartasCombinadas As Carta() = Me.Cartas.ToArray() 'Evito multiples enumeraciones
            If cartasCombinadas.Length >= MinimoCartasNecesarias AndAlso cartasCombinadas.Length <= MaximoCartasPermitidas Then
                'Si todas las cartas combinadas tienen el mismo número
                Dim unaCarta As Carta = cartasCombinadas(0)
                Return cartasCombinadas.All(Function(c) c.Numero.Equals(unaCarta.Numero))
            End If

            Return False
        End Function
    End Class

End Namespace
