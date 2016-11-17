Imports Chinchon.Entities
Imports ChinchonWinForms.My.Resources

Public Class frmAsignarValorComodin

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = Resources.Titulo_AsignarValorComodin

        Me.comboPalo.DataSource = [Enum].GetValues(GetType(Palo))
        Me.comboNumero.DataSource = New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
    End Sub

    ''' <summary>
    ''' Devuelve o establece el Palo seleccionado
    ''' </summary>
    Public Property PaloSeleccionado As Palo
        Get
            Return Me.comboPalo.SelectedItem
        End Get
        Set(value As Palo)
            Me.comboPalo.SelectedItem = value
        End Set
    End Property

    ''' <summary>
    ''' Devuelve o establece el Número de carta seleccionado
    ''' </summary>
    ''' <returns></returns>
    Public Property NumeroSeleccionado As Integer
        Get
            Return Me.comboNumero.SelectedItem
        End Get
        Set(value As Integer)
            Me.comboNumero.SelectedItem = value
        End Set
    End Property

    Private Sub Combo_ValueChanged(sender As Object, e As EventArgs) Handles comboNumero.SelectedValueChanged, comboPalo.SelectedValueChanged
        Me.VisorCarta1.Carta = New Carta(Me.NumeroSeleccionado, Me.PaloSeleccionado)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub
End Class