Imports Chinchon.Combinaciones
Imports Chinchon.Exceptions

Namespace Acciones

    Public Class PresentarCombinacion
        Implements IAccion

        Private ReadOnly _partida As Partida
        Private ReadOnly _combinacion As Combinacion

        Public Sub New(partida As Partida, combinacion As Combinacion)
            _partida = partida
            _combinacion = combinacion
        End Sub

        Public Sub Validar()
            If Not _combinacion.EsValida() Then
                Throw new AccionNoPermitidaException(String.Format("La combinación de {0} indicada no es válida", _combinacion.ToString()))
            End If
        End Sub


        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Call Me.Validar()

            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            turnoEnCurso.Mano.RegistrarCombinacion(_combinacion)
        End Sub
    End Class
End Namespace