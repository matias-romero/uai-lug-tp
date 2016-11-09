Imports Chinchon
Imports Chinchon.Entities

Public Class frmTablero
    Private ReadOnly _vistaPorJugador as VistaPorJugador
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Public sub New(vpj As VistaPorJugador)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _vistaPorJugador = vpj
    End Sub

    Private Sub frmTablero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = _vistaPorJugador.Jugador.ToString()
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

    Private Sub ManoPorJugador2_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) 
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
