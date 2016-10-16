Imports Chinchon.Entities

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

        Assert.IsFalse(partida.Jugadores.Any(), "Una nueva partida no debe traer ningún jugador registrado")

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
        Assert.IsTrue(secuenciaEsperada.SequenceEqual(partida.Jugadores), "Debe devolverme los dos jugadores registrados en el mismo orden que se registraron")
    End Sub

    <TestMethod()>
    Public Sub UnaPartidaDebeNotificarCadaVezQueComienzaUnaRonda()
        Dim contadorEventoDisparados As Integer = 0
        Dim manejadorDelEvento As EventHandler = Sub(sender, e) contadorEventoDisparados += 1
        Dim jugadorA As New Jugador()
        Dim jugadorB As New Jugador()
        Dim partida As New Partida()
        AddHandler partida.EmpiezaNuevaRonda, manejadorDelEvento
        partida.Unirse(jugadorA)
        partida.Unirse(jugadorB)

        'ACT & ASSERT
        partida.Comenzar()
        Assert.AreEqual(1, contadorEventoDisparados, "No se disparo el evento de comienzo de ronda al comenzar la partida")

        partida.NuevaRonda()
        Assert.AreEqual(2, contadorEventoDisparados, "No se disparo el evento de comienzo de ronda al comenzar una nueva ronda")
    End Sub
End Class
