Imports Chinchon
Imports Chinchon.Entities

Public Class frmMain
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} (v{1})", Application.ProductName, Application.ProductVersion)
        If (Orquestador.PartidaActual IsNot Nothing) Then Me.ComenzarPartida(Orquestador.PartidaActual) 'Para casos prearmados
        Me.WindowState = FormWindowState.Maximized
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub ComenzarPartida(partidaActual As Partida)
        AddHandler partidaActual.PartidaFinalizada, AddressOf Me.OnPartidaFinalizada

        For Each jugador As Jugador In partidaActual.JugadoresActivos.Reverse()
            Dim vistaPorJugador As VistaPorJugador = partidaActual.VerComo(jugador)
            Dim formTablero As frmTablero = New frmTablero(vistaPorJugador)
            formTablero.Name = String.Format("frmTablero_{0}", jugador.Id)
            formTablero.MdiParent = Me
            formTablero.Show()
        Next

    End Sub

    Private Sub OnPartidaFinalizada(sender As Object, e As EventArgs)
        Dim partidaFinalizada As Partida = DirectCast(sender, Partida)
        Dim resumen As New ResumenPartida(partidaFinalizada)
        'Cierro todos los tableros y muestro el resultado de la partida
        For Each tablero As frmTablero In Me.MdiChildren
            tablero.Close()
            'tablero.Dispose()
        Next

        'TODO: Poner un formulario mas feliz con el resumen de la partida
        MessageBox.Show("Gracias por jugar con nosotros. Finalizó la partida " + partidaFinalizada.Id.ToString() + " : FELICITACIONES " + resumen.Ganador.ToString())
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
End Class
