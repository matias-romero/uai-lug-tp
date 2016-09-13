Public Class Jugador
    Public Property Id As Integer
    Public Property Apodo As String

    Public Overrides Function ToString() As String
        Return Me.Apodo
    End Function
End Class
