Imports Chinchon.Entities
Imports Chinchon.Exceptions

Namespace Acciones
    Public Class PonerCartaEnElMonton
        Implements IAccion

        Private ReadOnly _partida As Partida
        Private ReadOnly _cartaDescartada As Carta

        Public Sub New(partida As Partida, cartaDescartada As Carta)
            _partida = partida
            _cartaDescartada = cartaDescartada
        End Sub

        Public Sub Validar()
            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            If turnoEnCurso.CartaLevantada Is nothing Then
                Throw new AccionNoPermitidaException("Debe levantar una carta primero.")
            End If
        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Call Me.Validar()

            _partida.Monton.Poner(_cartaDescartada)
            _partida.TurnoEnCurso.CartaDescartada = _cartaDescartada
        End Sub
    End Class
End Namespace