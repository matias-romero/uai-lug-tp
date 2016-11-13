Imports Chinchon.Entities

Namespace Acciones
    Public Class TomarCartaDesdeLaBaraja
        Implements IAccion

        Private ReadOnly _partida As Partida

        Public Sub New(partida As Partida)
            _partida = partida
        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Dim proximaCarta As Carta = _partida.Mazo.TomarCarta()
            _partida.TurnoEnCurso.CartaLevantada = proximaCarta
        End Sub
    End Class
End Namespace