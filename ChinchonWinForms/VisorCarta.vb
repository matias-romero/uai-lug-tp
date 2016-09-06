Imports Chinchon
Imports System.ComponentModel

<DefaultBindingProperty("Carta")>
Public Class VisorCarta
    Private _carta As Carta
    Private _cartaRenderizada As Image
    Private _mostrarCaraDeCarta As Boolean = True

    <Description("Devuelve o establece si se ve la cara de la carta o su reverso"), Category("Data"), DefaultValue(True)>
    Public Property MostrarCarta As Boolean
        Get
            Return _mostrarCaraDeCarta
        End Get
        Set
            _mostrarCaraDeCarta = Value
            Call Me.RenderizarCarta()
        End Set
    End Property

    <Description("Devuelve o establece la carta a visualizar"), Category("Data")>
    Public Property Carta As Carta
        Get
            Return _carta
        End Get
        Set
            _carta = Value
            Call Me.RenderizarCarta()
        End Set
    End Property

    Private Sub RenderizarCarta()
        'Libero los recursos no manejados GDI del bitmap
        If _cartaRenderizada IsNot Nothing Then
            _cartaRenderizada.Dispose()
            _cartaRenderizada = Nothing
        End If

        If _carta Is Nothing Then
            _cartaRenderizada = GestorDeImagenes.DibujarCartaEnBlanco()
        Else
            If Me.MostrarCarta Then
                _cartaRenderizada = GestorDeImagenes.DibujarCarta(_carta)
            Else
                _cartaRenderizada = GestorDeImagenes.DibujarReversoDeCarta()
            End If
        End If

        'Cambio la carta dibujada
        _picture.Image = _cartaRenderizada
    End Sub
End Class
