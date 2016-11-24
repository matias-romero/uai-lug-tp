Imports Chinchon

Public Class frmResumenPartida
    Private ReadOnly _resumen As ResumenPartida

    Public sub New(resumen As ResumenPartida)
        _resumen = resumen
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lblNombreGanador.Text = _resumen.Ganador.ToString()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Call Me.Close()
    End Sub
End Class