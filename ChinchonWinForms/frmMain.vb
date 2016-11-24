Imports System.Timers
Imports Chinchon
Imports Chinchon.Entities

Public Class frmMain
    Private WithEvents TimerDelayHelper As New Timers.Timer(1500) With {.Enabled = False, .AutoReset = False}

    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto
    Private _ultimoResumenDePartida As ResumenPartida

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} (v{1})", Application.ProductName, Application.ProductVersion)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ComenzarPartida(partidaActual As Partida)
        _ultimoResumenDePartida = Nothing
        AddHandler partidaActual.PartidaFinalizada, AddressOf Me.OnPartidaFinalizada

        For Each jugador As Jugador In partidaActual.JugadoresActivos.Reverse()
            Dim vistaPorJugador As VistaPorJugador = partidaActual.VerComo(jugador)
            Dim formTablero As frmTablero = New frmTablero(vistaPorJugador)
            formTablero.Name = String.Format("frmTablero_{0}", jugador.Id)
            formTablero.MdiParent = Me
            formTablero.Show()
        Next

        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub OnPartidaFinalizada(sender As Object, e As EventArgs)
        Dim partidaFinalizada As Partida = DirectCast(sender, Partida)
        _ultimoResumenDePartida = New ResumenPartida(partidaFinalizada)

        'Guardo las estadísticas de la partida
        Call Me.RegistrarEstadisticasJugadores(_ultimoResumenDePartida.Participantes)
        'Utilizo un timer para diferir el evento y liberar el stack (Cheap-Threading)
        TimerDelayHelper.Start()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not PromptYesNoQuestion(My.Resources.Prompt_AbandonarPartida) Then
            e.Cancel = True
        End If

        'Grabo lo que necesite y cierro el juego normalmente
    End Sub

    Public Shared Function PromptYesNoQuestion(msg As String) As Boolean
        Return MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    Private Sub NuevaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem.Click
        Using formulario As New frmNuevaPartida()
            If formulario.ShowDialog(Me) = DialogResult.OK Then
                Call Me.ComenzarPartida(Orquestador.PartidaActual)
            End If

            formulario.Close()
        End Using

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Call Me.Close()
    End Sub

    Private Sub OrdenarTablerosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenarTablerosToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub RegistrarEstadisticasJugadores(jugadores As IEnumerable(Of Jugador))
        Try
            Dim repositorioJugadores As IJugadorRepositorio = Orquestador.Repositorios.Jugadores()
            Call repositorioJugadores.Actualizar(jugadores)
        Catch ex As Exception
            MessageBox.Show(My.Resources.Error_GuardandoEstadisticasEnRepositorio, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MostrarResultadosPartida()
        'Cierro todos los tableros y muestro el resultado de la partida
        For Each tablero As frmTablero In Me.MdiChildren
            tablero.Close()
            tablero.Dispose()
        Next

        Using formResumen As New frmResumenPartida(_ultimoResumenDePartida)
            formResumen.ShowDialog(Me)
        End Using
    End Sub

    Private Sub TimerDelayHelper_Elapsed(sender As Object, e As ElapsedEventArgs) Handles TimerDelayHelper.Elapsed
        Me.BeginInvoke(Sub() Call Me.MostrarResultadosPartida())
    End Sub
End Class
