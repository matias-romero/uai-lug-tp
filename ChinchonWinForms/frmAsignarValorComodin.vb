Imports Chinchon.Entities
Imports ChinchonWinForms.My.Resources

Public Class frmAsignarValorComodin
    Private Sub frmAsignarValorComodin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Resources.Titulo_AsignarValorComodin

        Me.comboPalo.DataSource = [Enum].GetValues(GetType(Palo))
        Me.comboNumero.DataSource = New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
    End Sub

    Private Sub Combo_ValueChanged(sender As Object, e As EventArgs) Handles comboNumero.SelectedValueChanged, comboPalo.SelectedValueChanged
        Dim palo As Palo = Me.comboPalo.SelectedItem
        Dim numero As Integer = Me.comboNumero.SelectedItem

        Me.VisorCarta1.Carta = New Carta(numero, palo)
    End Sub
End Class