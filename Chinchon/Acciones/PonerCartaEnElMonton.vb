Imports Chinchon.Entities

Namespace Acciones
    Public Class PonerCartaEnElMonton
        Implements IAccion

        Private _partida As Partida
        Private _cartaDescartada As Carta
        Public Sub New(partida As Partida, cartaDescartada As Carta)
            _partida = partida
            _cartaDescartada = cartaDescartada
        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            _partida.TurnoEnCurso.CartaDescartada = _cartaDescartada
        End Sub
    End Class
End Namespace