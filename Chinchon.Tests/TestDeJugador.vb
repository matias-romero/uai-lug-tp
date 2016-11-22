Imports Chinchon.Entities

<TestClass()>
Public Class TestDeJugador

    <TestMethod()>
    Public Sub UnJugadorDebeComputarSusEstadisticasBasadoEnSusParticipaciones()
        'ARRANGE
        Dim jugador As New Jugador()
        jugador.ParticipacionesRegistradasEnPartidas.Add(new ParticipacionJugadorEnPartida() With { .FueGanador = True, .TiempoDeJuegoNeto = TimeSpan.FromHours(1) })
        jugador.ParticipacionesRegistradasEnPartidas.Add(new ParticipacionJugadorEnPartida() With { .FueGanador = True, .TiempoDeJuegoNeto = TimeSpan.FromMinutes(15) })
        jugador.ParticipacionesRegistradasEnPartidas.Add(new ParticipacionJugadorEnPartida() With { .FueGanador = False, .TiempoDeJuegoNeto = TimeSpan.FromMinutes(30) })

        'ACT & ASSERT
        Assert.AreEqual(67, jugador.PromedioVictorias)
        Assert.AreEqual(1, jugador.TotalDerrotas)
        Assert.AreEqual(2, jugador.TotalVictorias)
        Assert.AreEqual(New TimeSpan(0, 1, 45, 0), jugador.TotalTiempoJugado, "Debe registrar un total de 1 hora y 45 minutos")
    End Sub

End Class