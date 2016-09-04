Imports Chinchon

Public Class CartaComodin
    Inherits Carta

    'Configuro el valor del comodin cuando no se combina
    Public Shared Property ValorComodin As Integer = 25

    Public Sub New()
        MyBase.New(0, Palo.Oro)
    End Sub

    Public Overrides ReadOnly Property Numero As Integer
        Get
            Return Me.NumeroAsignadoPorUsuario
        End Get
    End Property

    Public Overrides ReadOnly Property Palo As Palo
        Get
            Return Me.PaloAsignadoPorUsuario
        End Get
    End Property

    ''' <summary>
    ''' Devuelve o establece el numero asignado por el usuario como valor de la carta
    ''' </summary>
    Public Property NumeroAsignadoPorUsuario As Integer

    ''' <summary>
    ''' Devuelve o establece el palo asignado por el usuario como valor de la carta
    ''' </summary>
    Public Property PaloAsignadoPorUsuario As Palo

    Public Overrides ReadOnly Property ValorSinCombinar As Integer
        Get
            Return ValorComodin
        End Get
    End Property
End Class
