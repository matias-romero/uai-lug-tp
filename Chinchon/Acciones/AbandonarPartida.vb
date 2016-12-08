Imports Chinchon.Entities

Namespace Acciones
    Public Class AbandonarPartida
        Implements IAccion

        Private ReadOnly _partida As Partida
        Private ReadOnly _jugador As Jugador

        Public Sub New(partida As Partida, jugador As Jugador)
            _partida = partida
            _jugador = jugador
        End Sub

        public sub Validar()
            'TODO: Comprobar si debe terminar la ronda al menos o lo saco directamente
        End sub

        Public Sub Ejecutar() Implements IAccion.Ejecutar
            Call Me.Validar()

            _partida.Abandonar(_jugador)
        End Sub
    End Class
End Namespace