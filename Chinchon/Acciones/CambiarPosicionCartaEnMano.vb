Imports Chinchon.Entities

Namespace Acciones
    Public Class CambiarPosicionCartaEnMano
        Implements IAccion

        Private ReadOnly _mano As Mano
        Private ReadOnly _cartaA As Carta
        Private ReadOnly _cartaB As Carta

        public sub New(mano As Mano, cartaA As Carta, cartaB As Carta)
            _mano = mano
            _cartaA = cartaA
            _cartaB = cartaB
        End sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            _mano.IntercambiarCarta(_cartaA, _cartaB)
        End Sub
    End Class
End Namespace

