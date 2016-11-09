Imports Chinchon.Entities

Namespace Acciones

    Public Class CerrarRonda
        Implements IAccion

        Private ReadOnly _partida As Partida
        Private ReadOnly _cartaCierre As Carta

        Public Sub New(partida As Partida, cartaCierre As Carta)
            _partida = partida
            _cartaCierre = cartaCierre
        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            _partida.RondaActual.Cerrar(turnoEnCurso.Jugador, _cartaCierre)
        End Sub
    End Class
End Namespace