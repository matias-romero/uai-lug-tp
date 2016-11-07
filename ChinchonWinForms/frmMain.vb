Imports Chinchon
Imports Chinchon.Entities

Public Class frmMain
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: Remover inicialización para pruebas directas
        '**************************************************
        AddHandler Orquestador.PartidaActual.EmpiezaNuevaRonda, AddressOf Me.EmpiezaNuevoTurno
        AddHandler Orquestador.PartidaActual.EmpiezaNuevoTurno, AddressOf Me.EmpiezaNuevoTurno

        Orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 1, .Apodo = "Matias"})
        Orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 2, .Apodo = "Rival"})

        Orquestador.PartidaActual.Comenzar()
        '**************************************************

        Me.Text = Application.ProductName

        Dim baraja As New Baraja()
        baraja.Barajar()

        'Dim mano As New Mano(baraja.TomarCartas(7))
        'Me.ManoPorJugador1.Init(mano)

        Dim mano2 As New Mano(baraja.TomarCartas(7))
        Me.ManoPorJugador2.Init(mano2)
        Me.ManoPorJugador2.VisorCarta1.MostrarCarta = False
        Me.ManoPorJugador2.VisorCarta2.MostrarCarta = False
        Me.ManoPorJugador2.VisorCarta3.MostrarCarta = False
        Me.ManoPorJugador2.VisorCarta4.MostrarCarta = False
        Me.ManoPorJugador2.VisorCarta5.MostrarCarta = False
        Me.ManoPorJugador2.VisorCarta6.MostrarCarta = False
        Me.ManoPorJugador2.VisorCarta7.MostrarCarta = False

        Me.VisorMazo.Carta = baraja.LastOrDefault()
    End Sub

    Private Sub EmpiezaNuevoTurno(sender As Object, e As EventArgs)
        Dim turnoEnCurso As Turno = Orquestador.PartidaActual.TurnoEnCurso
        'Dim mano As New Mano(Baraja.TomarCartas(7))
        Me.ManoPorJugador1.Init(turnoEnCurso.Mano)

        'Dim mano2 As New Mano(Baraja.TomarCartas(7))
        'Me.ManoPorJugador2.Init(mano2)
        MessageBox.Show("Es el turno de: " & turnoEnCurso.Jugador.Apodo)
    End Sub

    Private Sub ManoPorJugador1_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles ManoPorJugador1.OperacionDeSoltarCartaDetectada
        'TODO: Conectar con el orquestador
        If e.Origen.Equals(Me.VisorMonton) Then
            'Tomo carta desde el monton
            Dim accion As New Acciones.TomarCartaDesdeElMonton(Orquestador.PartidaActual)
            accion.Ejecutar()
        ElseIf e.Origen.Equals(Me.VisorMazo) Then
            'Tomo carta desde el mazo
            Dim accion As New Acciones.TomarCartaDesdeLaBaraja(Orquestador.PartidaActual)
            accion.Ejecutar()
        End If
        MessageBox.Show(String.Format("Solto la carta {0} en la mano del jugador 1", e.Carta))
    End Sub

    Private Sub ManoPorJugador2_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles ManoPorJugador2.OperacionDeSoltarCartaDetectada
        'TODO: Conectar con el orquestador
        MessageBox.Show(String.Format("Solto la carta {0} en la mano del jugador 2", e.Carta))
    End Sub

    Private Sub VisorMonton_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles VisorMonton.OperacionDeSoltarCartaDetectada
        'TODO: Conectar con el orquestador
        'Suelto una carta en el monton
        Dim accion As New Acciones.PonerCartaEnElMonton(Orquestador.PartidaActual, e.Carta)
        accion.Ejecutar()
        MessageBox.Show(String.Format("Solto la carta {0} en el monton", e.Carta))
    End Sub

    Private Sub VisorMonton_OperacionDeCerrarRondaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles VisorMonton.OperacionDeCerrarRondaDetectada
        'TODO: Conectar con el orquestador
        MessageBox.Show(String.Format("Solicito cerrar la ronda con la carta {0}", e.Carta))
        VisorMonton.EstaCerrado = True
        Dim accionCierre As New Acciones.CerrarRonda(Orquestador.PartidaActual, e.Carta)
        accionCierre.Ejecutar()
        'TODO:
        'Orquestador.EfectuarJugada(e.Carta, e.Origen, e.Destino)
    End Sub

    Private Sub RefrescarEstadoPartida(unaPartida As Partida)
        Me.VisorMonton.CartaVisible = unaPartida.Monton.Cara
    End Sub
End Class
