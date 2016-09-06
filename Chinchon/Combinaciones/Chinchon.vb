Namespace Combinaciones

    ''' <summary>
    ''' Un "chinchón" es una escalera con las 7 cartas de la mano
    ''' </summary>
    Public Class Chinchon
        Inherits Escalera

        Public Overrides ReadOnly Property MinimoCartasNecesarias As Integer
            Get
                Return 7
            End Get
        End Property

        Public Overrides ReadOnly Property MaximoCartasPermitidas As Integer
            Get
                Return 7
            End Get
        End Property

    End Class

End Namespace
