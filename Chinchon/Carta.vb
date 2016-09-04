Public Class Carta
    Public Sub New(numero As Integer, palo As Palo)
        Me.Numero = numero
        Me.Palo = palo
    End Sub

    Public Overridable ReadOnly Property Palo As Palo

    Public Overridable ReadOnly Property Numero As Integer

    Public Overridable ReadOnly Property ValorSinCombinar As Integer
        Get
            'Las cartas normales valen lo que diga su número
            Return Me.Numero
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("{0} de {1:G}", Me.Numero, Me.Palo)
    End Function
End Class
