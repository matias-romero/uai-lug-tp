Imports Chinchon

Public Class frmTablero
    Private ReadOnly _vistaPorJugador As VistaPorJugador
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Public Sub New(vpj As VistaPorJugador)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _vistaPorJugador = vpj
        AddHandler _vistaPorJugador.ComenzoMiTurno, AddressOf Me.ComienzaMiTurno
        AddHandler _vistaPorJugador.FinalizoMiTurno, AddressOf Me.FinalizaMiTurno
        AddHandler _vistaPorJugador.CambioEstadoPartida, AddressOf Me.RefrescarEstadoPartida

        'Fake para disparar el evento al iniciar la partida
        Call RefrescarEstadoPartida(_vistaPorJugador, EventArgs.Empty)
    End Sub

    Private Sub frmTablero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = _vistaPorJugador.Jugador.ToString()
    End Sub

    Private Sub ManoPorJugador1_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles ManoPorJugador1.OperacionDeSoltarCartaDetectada
        'TODO: Conectar con el orquestador
        If e.Origen.Equals(Me.VisorMonton) Then
            'Tomo carta desde el monton
            _vistaPorJugador.TomarCartaDesdeElMonton()
        ElseIf e.Origen.Equals(Me.VisorMazo) Then
            'Tomo carta desde el mazo
            _vistaPorJugador.TomarCartaDesdeElMazo()
        End If
        MessageBox.Show(String.Format("Solto la carta {0} en la mano del jugador 1", e.Carta))
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

    Private Sub ComienzaMiTurno(sender As Object, e As EventArgs)
        MessageBox.Show("Es el turno de: " & _vistaPorJugador.Jugador.ToString())
    End Sub

    Private Sub FinalizaMiTurno(sender As Object, e As EventArgs)
        MessageBox.Show("Termino el turno de: " & _vistaPorJugador.Jugador.ToString())
    End Sub

    Private Sub RefrescarEstadoPartida(sender As Object, e As EventArgs)
        Me.VisorMonton.CartaVisible = _vistaPorJugador.CartaVisibleMonton
        'me.VisorMazo.Enabled = _vistaPorJugador.EstaVacioElMazo
        Me.ManoPorJugador1.Init(_vistaPorJugador.Mano)
    End Sub
End Class
