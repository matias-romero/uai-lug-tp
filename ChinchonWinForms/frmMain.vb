Imports Chinchon

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName

        Dim baraja As New Baraja()
        baraja.Barajar()

        Dim mano As New Mano(baraja.TomarCartas(7))
        Me.ManoPorJugador1.Init(mano)

        Dim mano2 As New Mano(baraja.TomarCartas(7))
        Me.ManoPorJugador2.Init(mano2)

        Me.VisorMazo.Carta = baraja.LastOrDefault()
    End Sub
End Class
