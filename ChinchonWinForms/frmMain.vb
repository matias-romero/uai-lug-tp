Imports Chinchon

Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.VisorCarta1.Carta = New Carta(1, Palo.Espada)
        Me.VisorCarta2.Carta = New CartaComodin()
    End Sub
End Class
