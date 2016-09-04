Namespace Combinaciones

    Public Class Escalera
        Inherits Combinacion

        Public Overrides ReadOnly Property MaximoCartasPermitidas As Integer
            Get
                Return 4
            End Get
        End Property

        Public Overrides Function EsValida() As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
