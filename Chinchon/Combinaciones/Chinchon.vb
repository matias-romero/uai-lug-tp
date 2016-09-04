Namespace Combinaciones

    Public Class Chinchon
        Inherits Combinacion

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

        Public Overrides Function EsValida() As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
