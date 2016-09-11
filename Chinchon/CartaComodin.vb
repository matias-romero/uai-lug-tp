
Public Class CartaComodin
    Inherits Carta

    'Configuro el valor del comodin cuando no se combina
    Public Const ValorComodin As Integer = 25

    Public Sub New()
        MyBase.New(0, Chinchon.Palo.Oro)
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

    ''' <summary>
    ''' Determina si el comodín ya tiene un valor específico asignado
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property TieneValorAsignado As Boolean
        Get
            Return Me.NumeroAsignadoPorUsuario <> 0
        End Get
    End Property

    Public Overrides ReadOnly Property ValorSinCombinar As Integer
        Get
            Return ValorComodin
        End Get
    End Property
End Class
