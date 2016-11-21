Imports Chinchon.Entities
Imports Moq

<TestClass()>
Public Class TestDePartida

    <TestMethod()>
    Public Sub CadaPartidaDebeTenerSuPropioIdentificador()
        Dim partidaA As New Partida()
        Dim partidaB As New Partida()

        Assert.AreNotEqual(partidaA.Id, partidaB.Id)
    End Sub

    <TestMethod()>
    Public Sub UnaPartidaRequiereAlMenosDosJugadoresParaPoderComenzarPreservandoElOrdenEnQueSeUnen()
        Dim partida As New Partida()

        Assert.IsFalse(partida.JugadoresActivos.Any(), "Una nueva partida no debe traer ningún jugador registrado")

        Dim jugadorA As New Jugador()
        Dim jugadorB As New Jugador()
        Dim eventoDisparado As Boolean = False
        Dim manejadorDelEvento As EventHandler = Sub(sender, e) eventoDisparado = True
        AddHandler partida.PartidaListaParaEmpezar, manejadorDelEvento

        partida.Unirse(jugadorA)
        Assert.IsFalse(eventoDisparado)

        partida.Unirse(jugadorB)
        Assert.IsTrue(eventoDisparado)

        Dim secuenciaEsperada As Jugador() = New Jugador() {jugadorA, jugadorB}
        Assert.IsTrue(secuenciaEsperada.SequenceEqual(partida.JugadoresActivos), "Debe devolverme los dos jugadores registrados en el mismo orden que se registraron")
    End Sub

    <TestMethod()>
    Public Sub UnaPartidaDebeNotificarCadaVezQueComienzaUnaRonda()
        Dim contadorEventoDisparados As Integer = 0
        Dim manejadorDelEvento As EventHandler = Sub(sender, e) contadorEventoDisparados += 1
        Dim jugadorA As New Jugador()
        Dim jugadorB As New Jugador()
        Dim partida As New Partida()
        AddHandler partida.EmpiezaNuevaRonda, manejadorDelEvento

        'ACT & ASSERT
        partida.Comenzar(jugadorA, jugadorB)
        Assert.AreEqual(1, contadorEventoDisparados, "No se disparo el evento de comienzo de ronda al comenzar la partida")

        partida.NuevaRonda()
        Assert.AreEqual(2, contadorEventoDisparados, "No se disparo el evento de comienzo de ronda al comenzar una nueva ronda")
    End Sub

    <TestMethod()>
    public sub UnaMazoDebePerderSieteCartasPorCadaJugadorRegistradoEnLaPartida()
        'ARRANGE
        const CantidadEsperadaCartas As Integer = Baraja.CantidadCartasTotales - 7 * 2
        Dim barajadorMock As New Mock(Of IBarajador)
        Dim mazoArreglado As New Baraja(barajadorMock.Object)
        Dim partida As New Partida(Guid.NewGuid(), mazoArreglado)

        'ACT
        partida.Comenzar(New Jugador(), New Jugador())
        
        'ASSERT
        Assert.AreEqual(CantidadEsperadaCartas, mazoArreglado.Count())
    End sub

    <TestMethod()>
    <TestCategory("Integracion")>
    Public Sub ProbarUnaPartidaCompleta()
        'ARRANGE
        Dim montonArreglado As New Monton()
        Dim barajadorMock As New Mock(Of IBarajador)
        Dim mazoArreglado As New Baraja(barajadorMock.Object) 'Com,Com,1oro,2o,3o,...,1esp,2e,...,1copa,...,1basto,...,12b
        Dim partida As New Partida(Guid.NewGuid(), mazoArreglado, montonArreglado)
        
        Dim jugadorRed As Jugador = New Jugador() With {.Id = 1, .Apodo = "Red"}
        Dim jugadorBlue As Jugador  = New Jugador() With {.Id = 2, .Apodo = "Blue"}
        partida.Comenzar(jugadorRed, jugadorBlue)

        Dim mvpRed As VistaPorJugador = partida.VerComo(jugadorRed)
        Dim mvpBlue As VistaPorJugador = partida.VerComo(jugadorBlue)

        'ACT & ASSERT
        Assert.AreEqual(new CartaComodin(), mazoArreglado.First(), "La primer carta debe ser 1 comodín")
        Assert.AreEqual(new Carta(10, Palo.Espada), mazoArreglado.ProximaCarta, "La proxima carta debe ser el 10 de Espada (reparti las ultimas 14 ya)")
        Assert.IsTrue(mvpRed.EsMiTurno, "Debe ser el turno de Red")
        Assert.IsFalse(mvpBlue.EsMiTurno, "Blue todavía no tiene el turno")

        mvpRed.TomarCartaDesdeElMazo()
        Assert.IsTrue(mvpRed.EsMiTurno, "Hasta que no descarta sigue el siendo el turno de Red")
        mvpRed.DescartarCarta(mvpRed.Mano.Cartas.ElementAt(2))
        Assert.IsFalse(mvpRed.EsMiTurno, "Si tomé y descarté una carta terminó mi turno")

        'Assert.AreEqual(jugadorBlue, partida.TurnoEnCurso.Jugador)
    End Sub
End Class

