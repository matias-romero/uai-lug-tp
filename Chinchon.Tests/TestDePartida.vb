Imports Chinchon.Combinaciones
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
        partida.PuntajeLimite = 10 'Para hacerlo super corto
        partida.Comenzar(jugadorRed, jugadorBlue)

        Dim mvpRed As VistaPorJugador = partida.VerComo(jugadorRed)
        Dim mvpBlue As VistaPorJugador = partida.VerComo(jugadorBlue)

        Dim solicitoPresentarCombinacionesRed As Boolean = false
        AddHandler mvpRed.SolicitarQuePresenteSusCombinaciones, sub(sender, args) solicitoPresentarCombinacionesRed = true

        Dim solicitoPresentarCombinacionesBlue As Boolean = false
        AddHandler mvpBlue.SolicitarQuePresenteSusCombinaciones, sub(sender, args) solicitoPresentarCombinacionesBlue = true

        'ACT & ASSERT
        Assert.AreEqual(new CartaComodin(), mazoArreglado.First(), "La primer carta debe ser 1 comodín")
        Dim proximaCartaDelMazoAlEmpezar As Carta = new Carta(10, Palo.Espada)
        Assert.AreEqual(proximaCartaDelMazoAlEmpezar, mazoArreglado.ProximaCarta, "La proxima carta debe ser el 10 de Espada (reparti las ultimas 14 ya)")
        Assert.IsTrue(mvpRed.EsMiTurno, "Debe ser el turno de Red")
        Assert.IsFalse(mvpBlue.EsMiTurno, "Blue todavía no tiene el turno")

        'Primer turno de cada uno
        mvpRed.TomarCartaDesdeElMazo()
        Assert.IsTrue(mvpRed.EsMiTurno, "Hasta que no descarta sigue siendo el turno de Red")

        Dim cartaDescartePrimerTurnoRed As Carta  = mvpRed.Mano.Cartas.ElementAt(1)
        mvpRed.DescartarCarta(cartaDescartePrimerTurnoRed)
        Assert.IsFalse(mvpRed.EsMiTurno, "Si tomé y descarté una carta terminó mi turno")
        Assert.IsTrue(mvpBlue.EsMiTurno, "No avanzó al otro jugador al terminar el turno")
        Assert.AreEqual(mvpBlue.CartaVisibleMonton, cartaDescartePrimerTurnoRed)
        Assert.AreEqual(proximaCartaDelMazoAlEmpezar, mvpRed.Mano.Cartas.ElementAt(1), "Debe haber intercambiado la tercera carta con la que levantó del mazo")

        mvpBlue.TomarCartaDesdeElMonton()
        Assert.IsTrue(mvpBlue.EsMiTurno, "Hasta que no descarta sigue siendo el turno de Blue")
        Dim cartaDescartePrimerTurnoBlue As Carta = mvpBlue.Mano.Cartas.ElementAt(0)
        mvpBlue.DescartarCarta(cartaDescartePrimerTurnoBlue)
        Assert.AreEqual(mvpRed.CartaVisibleMonton, cartaDescartePrimerTurnoBlue)
        Assert.IsFalse(mvpBlue.EsMiTurno, "Si descarté tuvo que terminar el primer turno de Blue")
        Assert.AreEqual(cartaDescartePrimerTurnoRed, mvpBlue.Mano.Cartas.ElementAt(0), "Debe haber intercambiado la primera carta de la mano por la que levantó recien")

        'Segundo turno de cada uno y nueva ronda
        Assert.IsFalse(mvpBlue.EstaCerradaLaRonda, "La ronda debe seguir en juego para Blue")
        Assert.IsFalse(mvpRed.EstaCerradaLaRonda, "La ronda debe seguir en juego para Red")
        Assert.IsTrue(mvpRed.EsMiTurno, "Debe ser el segundo turno de Red")
        Assert.IsFalse(mvpBlue.EsMiTurno, "Blue todavía no tiene el segundo turno")

        mvpRed.TomarCartaDesdeElMazo()
        Assert.IsFalse(solicitoPresentarCombinacionesRed)
        mvpRed.CerrarRonda(mvpRed.Mano.Cartas.ElementAt(1))
        Assert.IsTrue(solicitoPresentarCombinacionesRed, "Al hacer el cierre tiene que pedirme las combinaciones para presentar")

        Assert.IsTrue(mvpRed.EsMiTurno, "Debe ser el tercer turno de Red")
        Dim combinacionA As New Escalera()
        combinacionA.AgregarCartas(mvpRed.Mano.Cartas.Skip(2))
        Assert.IsTrue(combinacionA.EsValida())

        Assert.IsFalse(solicitoPresentarCombinacionesBlue, "Todavía no debió pedirle combinaciones a Blue")
        Call mvpRed.RegistrarCombinaciones(combinacionA)
        Assert.IsTrue(solicitoPresentarCombinacionesBlue, "Una vez presentadas las combinaciones de Red debe seguir con Blue")
        Assert.IsTrue(mvpBlue.EsMiTurno)
    End Sub
End Class

