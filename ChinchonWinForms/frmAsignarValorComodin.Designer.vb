<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarValorComodin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.comboPalo = New System.Windows.Forms.ComboBox()
        Me.comboNumero = New System.Windows.Forms.ComboBox()
        Me.lblPalo = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.VisorCarta1 = New ChinchonWinForms.VisorCarta()
        Me.SuspendLayout
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOk.Location = New System.Drawing.Point(50, 310)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Aceptar"
        Me.btnOk.UseVisualStyleBackColor = true
        '
        'comboPalo
        '
        Me.comboPalo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPalo.FormattingEnabled = true
        Me.comboPalo.Location = New System.Drawing.Point(17, 36)
        Me.comboPalo.Name = "comboPalo"
        Me.comboPalo.Size = New System.Drawing.Size(143, 21)
        Me.comboPalo.TabIndex = 1
        '
        'comboNumero
        '
        Me.comboNumero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboNumero.FormattingEnabled = true
        Me.comboNumero.Location = New System.Drawing.Point(17, 94)
        Me.comboNumero.Name = "comboNumero"
        Me.comboNumero.Size = New System.Drawing.Size(143, 21)
        Me.comboNumero.TabIndex = 2
        '
        'lblPalo
        '
        Me.lblPalo.AutoSize = true
        Me.lblPalo.Location = New System.Drawing.Point(14, 20)
        Me.lblPalo.Name = "lblPalo"
        Me.lblPalo.Size = New System.Drawing.Size(28, 13)
        Me.lblPalo.TabIndex = 3
        Me.lblPalo.Text = "Palo"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = true
        Me.lblNumero.Location = New System.Drawing.Point(14, 78)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(44, 13)
        Me.lblNumero.TabIndex = 4
        Me.lblNumero.Text = "Numero"
        '
        'VisorCarta1
        '
        Me.VisorCarta1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VisorCarta1.Carta = Nothing
        Me.VisorCarta1.Location = New System.Drawing.Point(27, 140)
        Me.VisorCarta1.Name = "VisorCarta1"
        Me.VisorCarta1.Size = New System.Drawing.Size(120, 150)
        Me.VisorCarta1.TabIndex = 5
        '
        'frmAsignarValorComodin
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(174, 345)
        Me.Controls.Add(Me.VisorCarta1)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.lblPalo)
        Me.Controls.Add(Me.comboNumero)
        Me.Controls.Add(Me.comboPalo)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmAsignarValorComodin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAsignarValorComodin"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents btnOk As Button
    Private WithEvents comboPalo As ComboBox
    Private WithEvents comboNumero As ComboBox
    Private WithEvents lblPalo As Label
    Private WithEvents lblNumero As Label
    Private WithEvents VisorCarta1 As VisorCarta
End Class
