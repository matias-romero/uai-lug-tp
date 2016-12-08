Imports Chinchon.Combinaciones
Imports Chinchon.Exceptions

Namespace Acciones

    Public Class PresentarCombinaciones
        Implements IAccion

        Private ReadOnly _partida As Partida
        Private ReadOnly _combinaciones As Combinacion()

        Public Sub New(partida As Partida, combinaciones As IEnumerable(Of Combinacion))
            _partida = partida
            _combinaciones = combinaciones.ToArray()
        End Sub

        Public Sub Validar()
            For Each combinacion As Combinacion In _combinaciones
                If Not combinacion.EsValida() Then
                    Throw New AccionNoPermitidaException(String.Format("La combinación de {0} indicada no es válida", combinacion.ToString()))
                End If

            Next

        End Sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Call Me.Validar()

            Dim turnoEnCurso As Turno = _partida.TurnoEnCurso
            For Each combinacion As Combinacion In _combinaciones
                turnoEnCurso.Mano.RegistrarCombinacion(combinacion)

            Next
            
            'Una vez registrada mis combinaciones termino el turno dando lugar al próximo jugador
            Call turnoEnCurso.FinalizarTurno()
        End Sub
    End Class
End Namespace