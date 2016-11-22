Imports Chinchon
Imports Chinchon.Entities

Public Class frmMain
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each jugador As Jugador In Orquestador.PartidaActual.JugadoresActivos.Reverse()
            Dim vistaPorJugador As VistaPorJugador = Orquestador.PartidaActual.VerComo(jugador)
            Dim formTablero As frmTablero = new frmTablero(vistaPorJugador)
            formTablero.Name = string.Format("frmTablero_{0}", jugador.Id)
            formTablero.MdiParent = me
            formTablero.Show()
        Next

        me.WindowState = FormWindowState.Maximized
        me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not PromptYesNoQuestion(My.Resources.Prompt_AbandonarPartida) then
            e.Cancel = true
        End If

        'Grabo lo que necesite y cierro el juego normalmente
    End Sub

    public Shared Function PromptYesNoQuestion(msg As String) As Boolean
        Return MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function
End Class
