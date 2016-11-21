Imports Chinchon

Public Class frmTablero
    Private ReadOnly ColorActivo As Color = Color.ForestGreen
    Private ReadOnly ColorInactivo As Color = Color.DarkGray

    Private ReadOnly _vistaPorJugador As VistaPorJugador

    Public Sub New(vpj As VistaPorJugador)
        ' This call is required by the designer.
        InitializeComponent()
        Me.BackColor = ColorInactivo
        Me.groupMano.Text = vpj.Jugador.Apodo

        ' Add any initialization after the InitializeComponent() call.
        _vistaPorJugador = vpj
        AddHandler _vistaPorJugador.ComenzoMiTurno, AddressOf Me.ComienzaMiTurno
        AddHandler _vistaPorJugador.FinalizoMiTurno, AddressOf Me.FinalizaMiTurno
        AddHandler _vistaPorJugador.CambioEstadoPartida, AddressOf Me.RefrescarEstadoPartida
        AddHandler _vistaPorJugador.MensajeEntranteDelSistema, AddressOf Me.MensajeEntranteDelSistemaDetectado

        Dim cantidadRivales As Integer = _vistaPorJugador.CantidadRivales
        Me.ManoOponente1.Visible = cantidadRivales >= 1
        Me.ManoOponente2.Visible = cantidadRivales >= 2
        Me.ManoOponente3.Visible = cantidadRivales >= 3

        'Fake para disparar el evento al iniciar la partida
        If _vistaPorJugador.EsMiTurno Then
            Call ComienzaMiTurno(_vistaPorJugador, EventArgs.Empty)
        End If
        Call RefrescarEstadoPartida(_vistaPorJugador, EventArgs.Empty)
    End Sub

    Private Sub frmTablero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = _vistaPorJugador.Jugador.ToString()
    End Sub

    Private Sub ManoPorJugador1_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles ManoPorJugador1.OperacionDeSoltarCartaDetectada
        Dim visorOrigen as VisorCarta = e.Origen
        If visorOrigen.RolAsignado.Equals("Monton") Then
            'Tomo carta desde el monton, y no puede volver hasta su proximo turno
            _vistaPorJugador.TomarCartaDesdeElMonton()
            Call RefrescarMonton()
        ElseIf visorOrigen.Equals(Me.VisorMazo) Then
            'Tomo carta desde el mazo, se la muestro para que descarte la que quiera
            Me.VisorMazo.MostrarCarta = True
            _vistaPorJugador.TomarCartaDesdeElMazo()
        Else 
            'Quiere reordenar sus cartas
            Dim visorDestino As VisorCarta = e.Destino
            _vistaPorJugador.ReordenarMano(visorOrigen.Carta, visorDestino.Carta)
        End If
    End Sub

    Private Sub VisorMonton_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles VisorMonton.OperacionDeSoltarCartaDetectada
        'Suelto una carta en el monton
        _vistaPorJugador.DescartarCarta(e.Carta)
        Call RefrescarMonton()
    End Sub

    Private Sub VisorMonton_OperacionDeCerrarRondaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles VisorMonton.OperacionDeCerrarRondaDetectada
        If frmMain.PromptYesNoQuestion(My.Resources.Prompt_OperacionDeCerrarRondaDetectada) Then
            _vistaPorJugador.CerrarRonda(e.Carta)
        End If
    End Sub

    Private Sub ComienzaMiTurno(sender As Object, e As EventArgs)
        Me.BackColor = ColorActivo
    End Sub

    Private Sub FinalizaMiTurno(sender As Object, e As EventArgs)
        Me.BackColor = ColorInactivo
    End Sub

    Private sub RefrescarMonton()
        Me.VisorMonton.CartaVisible = _vistaPorJugador.CartaVisibleMonton
    End sub

    Private Sub RefrescarEstadoPartida(sender As Object, e As EventArgs)
        Dim controlesHabilitados As Boolean = _vistaPorJugador.EsMiTurno

        Call RefrescarMonton()
        Me.VisorMazo.MostrarCarta = False
        Me.VisorMazo.Carta = _vistaPorJugador.ProximaCartaDelMazo
        Me.ManoPorJugador1.Init(_vistaPorJugador.Mano.Cartas)

        Me.VisorMonton.Enabled = controlesHabilitados
        Me.ManoPorJugador1.Enabled = controlesHabilitados
        Me.VisorMazo.Enabled = controlesHabilitados
        Me.VisorMonton.EstaCerrado = _vistaPorJugador.EstaCerradaLaRonda

        me.lblPuntajeAcumulado.Text = _vistaPorJugador.PuntajeAcumulado
    End Sub

    Private Sub MensajeEntranteDelSistemaDetectado(sender As Object, e As MensajeSistemaEventArgs)
        Me.panelNotificador.Notificar(e.Mensaje, e.Sugerencia)
    End Sub
End Class
