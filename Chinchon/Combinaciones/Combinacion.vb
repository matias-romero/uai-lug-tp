Namespace Combinaciones

    Public MustInherit Class Combinacion
        Private _cartas As List(Of Carta)

        ''' <summary>
        ''' Enumera las cartas incluidas en la combinación
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Cartas As IEnumerable(Of Carta)
            Get
                Return _cartas
            End Get
        End Property

        ''' <summary>
        ''' Determina el número mínimo de cartas permitidas para poder hacer la combinación
        ''' </summary>
        Public Overridable ReadOnly Property MinimoCartasNecesarias As Integer
            Get
                Return 3
            End Get
        End Property

        ''' <summary>
        ''' Determina el máximo número de cartas posibles para hacer la combinación
        ''' </summary>
        Public MustOverride ReadOnly Property MaximoCartasPermitidas As Integer

        ''' <summary>
        ''' Comprueba que la combinación elegida de cartas cumpla la regla de juego
        ''' </summary>
        Public MustOverride Function EsValida() As Boolean
    End Class

End Namespace
