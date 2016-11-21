Imports Chinchon.Entities
Imports Chinchon.Exceptions

Namespace Acciones
    Public Class TomarCartaDesdeElMonton
        Implements IAccion

        Private ReadOnly _partida As Partida

        Public Sub New(partida As Partida)
            _partida = partida
        End Sub

        Public Sub Validar()
            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            If turnoEnCurso.CartaLevantada IsNot Nothing Then
                Throw new AccionNoPermitidaException(String.Format("Ya levantó un {0} en este turno.", turnoEnCurso.CartaLevantada) , "Debe descartar una carta para poder continuar")
            End If
        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Call me.Validar()

            Dim proximaCarta As Carta = _partida.Monton.Sacar()
            _partida.TurnoEnCurso.CartaLevantada = proximaCarta
        End Sub
    End Class
End Namespace