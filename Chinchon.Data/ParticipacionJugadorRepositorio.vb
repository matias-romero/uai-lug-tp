Imports Chinchon.Entities

'Este repositorio es de consumo interno
Friend Class ParticipacionJugadorRepositorio
    Private ReadOnly _conector As IConector

    Public Sub New(conector As IConector)
        _conector = conector
    End Sub

    Public Sub CargarParticipacionesPorJugador(jugador As Jugador)
        'TODO: SELECT desde DB
    End Sub

    Public Function ActualizarParticipacionesPorJugador(jugador As Jugador)
        'TODO: UPSERT a DB
    End Function

    Private Function CargarParticipacionJugadorDesdeDataRow(jugador As Jugador, dataRow As DataRow) As ParticipacionJugadorEnPartida
        Dim participacion = Me.MaterializarParticipacionJugadorDesdeDataRow(dataRow)
        jugador.ParticipacionesRegistradasEnPartidas.Add(participacion)
    End Function

    Private Function MaterializarParticipacionJugadorDesdeDataRow(dataRow As DataRow) As ParticipacionJugadorEnPartida
        Dim participacion As New ParticipacionJugadorEnPartida()
        participacion.Id = dataRow.Item("ID")
        participacion.IdentificadorPartida = dataRow.Item("IDENTIFICADORPARTIDA")
        participacion.TiempoDeJuegoNeto = TimeSpan.FromTicks(dataRow.Item("TIEMPODEJUEGONETO"))
        participacion.FueGanador = dataRow.Item("FUEGANADOR")
        Return participacion
    End Function
End Class
