Imports Chinchon
Imports Chinchon.Combinaciones

Public Class frmPresentarCombinaciones
    Private ReadOnly _mano As Mano

    Public Sub New(mano As Mano)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _mano = mano
        VistaDeLaMano.Init(mano)
    End Sub

    Private Sub btnNuevoChinchon_Click(sender As Object, e As EventArgs) Handles btnNuevoChinchon.Click
        Call Me.PrepararNuevaCombinacion(New Combinaciones.Chinchon())
    End Sub

    Private Sub btnNuevaEscalera_Click(sender As Object, e As EventArgs) Handles btnNuevaEscalera.Click
        Call Me.PrepararNuevaCombinacion(New Combinaciones.Escalera())
    End Sub

    Private Sub btnNuevoPie_Click(sender As Object, e As EventArgs) Handles btnNuevoPie.Click
        Call Me.PrepararNuevaCombinacion(New Combinaciones.Pie())
    End Sub

    Private Sub PrepararNuevaCombinacion(nuevaCombinacion As Combinacion)
        Dim nuevoControl As VisorCombinacion = New VisorCombinacion()
        nuevoControl.Enlazar(nuevaCombinacion)
        nuevoControl.Dock = DockStyle.Fill

        tablePanel.Controls.Add(nuevoControl)
    End Sub
End Class