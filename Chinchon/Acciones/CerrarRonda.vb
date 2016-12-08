Imports Chinchon.Entities
Imports Chinchon.Exceptions

Namespace Acciones

    Public Class CerrarRonda
        Implements IAccion

        Private ReadOnly _partida As Partida
        Private ReadOnly _cartaCierre As Carta

        Public Sub New(partida As Partida, cartaCierre As Carta)
            _partida = partida
            _cartaCierre = cartaCierre
        End Sub

        Public Sub Validar()
            Dim rondaEnCurso As Ronda = _partida.RondaActual
            if rondaEnCurso.Numero = 1 Then
                Throw new AccionNoPermitidaException("Debe haber pasado al menos una ronda para poder cerrar el juego")
            End If

            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            If turnoEnCurso.CartaLevantada Is nothing Then
                Throw new AccionNoPermitidaException("Primero debe levantar una carta.")
            End If
        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Call Me.Validar()

            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            turnoEnCurso.CartaDescartadaParaCierre = _cartaCierre
        End Sub
    End Class
End Namespace