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
        Dim partida As New Partida()
        Dim jugadorA As New Jugador()
        Dim jugadorB As New Jugador()

        partida.Unirse(jugadorA)
        partida.Unirse(jugadorB)
        partida.Comenzar()

    End Sub
End Class
