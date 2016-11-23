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

    <TestMethod()>
    Public Sub ComprobarIgualdadEntreJugadores()
        'ARRANGE
        Dim jugadorA As New Jugador() With { .Id = 1 }
        Dim jugadorB As New Jugador() With { .Id = 1 }
        Dim jugadorC As Jugador = jugadorA
        Dim jugadorD As New Jugador() With { .Id = 2 }
        Dim listado As Jugador() = new Jugador(){ jugadorA, jugadorB, jugadorC }       

        'ACT & ASSERT
        Assert.AreEqual(jugadorB, jugadorA, "Si tienen el mismo ID deben ser el mismo objeto de dominio")
        Assert.AreNotEqual(jugadorC, jugadorD, "Con diferentes ID no pueden ser el mismo elemento")
        Assert.AreEqual(0, Array.IndexOf(listado, jugadorA), "Debe haberlo encontrado en la primera posicion")
        Assert.AreEqual(0, Array.IndexOf(listado, jugadorB), "Debe haberlo encontrado en la primera posicion utilizando la igualdad por ID")
        Assert.AreEqual(0, Array.IndexOf(listado, jugadorC), "Debe haberlo encontrado en la primera posicion utilizando la igualdad por referencia")
        Assert.AreEqual(-1, Array.IndexOf(listado, jugadorD), "El jugador D no existe en el listado")
    End Sub
End Class