Imports Chinchon.Entities

Public Class frmPerfilJugador

    Public Sub New(jugador As Jugador)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call me.RefrescarControles(jugador)
    End Sub

    Private Sub RefrescarControles(jugador As Jugador)
        me.lblNombre.Text = jugador.Apodo
        me.lblVictorias.Text = jugador.TotalVictorias
        Me.lblDerrotas.Text = jugador.TotalDerrotas
        me.lblPromedioVictorias.Text = String.Format("{0:###,0}%", jugador.PromedioVictorias)
        me.lblTotalJugado.Text = jugador.TotalTiempoJugado.ToString("c")
        Me.lblTotalPartidas.Text = jugador.ParticipacionesRegistradasEnPartidas.Count
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Call Me.Close()
    End Sub
End Class