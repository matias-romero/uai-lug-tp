Imports Chinchon

Public Class VisorCarta
    Private _carta As Carta
    Private _cartaRenderizada As Image

    Public Property Carta As Carta
        Get
            Return _carta
        End Get
        Set(value As Carta)
            _carta = value

            'Libero los recursos no manejados GDI del bitmap
            If _cartaRenderizada IsNot Nothing Then
                _cartaRenderizada.Dispose()
                _cartaRenderizada = Nothing
            End If

            If _carta IsNot Nothing Then
                'Cambio la carta dibujada
                _cartaRenderizada = GestorDeImagenes.DibujarCarta(_carta)
                _picture.Image = _cartaRenderizada
            End If
        End Set
    End Property
End Class
