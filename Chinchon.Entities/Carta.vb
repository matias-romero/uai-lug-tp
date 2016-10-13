

Public Class Carta
    Implements IEquatable(Of Carta)
    Implements IComparable(Of Carta)

    Private ReadOnly _palo As Palo
    Private ReadOnly _numero As Integer

    Public Sub New(numero As Integer, palo As Palo)
        _numero = numero
        _palo = palo
    End Sub

    Public Overridable ReadOnly Property Palo As Palo
        Get
            Return _palo
        End Get
    End Property

    Public Overridable ReadOnly Property Numero As Integer
        Get
            Return _numero
        End Get
    End Property

    Public Overridable ReadOnly Property ValorSinCombinar As Integer
        Get
            'Las cartas normales valen lo que diga su número
            Return Me.Numero
        End Get
    End Property

    Public Overrides Function GetHashCode() As Integer
        Return Me.Numero.GetHashCode() + 10000 * (Me.Palo + 1)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        'Aca debo comprobar la nulidad y que tambien sean de tipos compatibles, por eso abuso del TryCast
        Return Me.Equals(TryCast(obj, Carta))
    End Function

    Public Overloads Function Equals(other As Carta) As Boolean Implements IEquatable(Of Carta).Equals
        If other Is Nothing Then
            Return False
        End If

        Return Me.Numero.Equals(other.Numero) AndAlso Me.Palo.Equals(other.Palo)
    End Function

    Public Function CompareTo(other As Carta) As Integer Implements IComparable(Of Carta).CompareTo
        'Si son iguales, directo retorno
        If Me.Equals(other) Then
            Return 0
        End If

        'Ordeno por palo primero, con diferente palo ya puedo definir el orden
        Dim comparacionPalo As Integer = Me.Palo.CompareTo(other.Palo)
        If comparacionPalo <> 0 Then
            Return comparacionPalo
        End If

        'Si tienen el mismo palo, me fijo por el numero
        Return Me.Numero.CompareTo(other.Numero)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("{0} de {1:G}", Me.Numero, Me.Palo)
    End Function
End Class
