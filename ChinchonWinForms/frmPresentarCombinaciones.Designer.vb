<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresentarCombinaciones
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tablePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnNuevoChinchon = New System.Windows.Forms.Button()
        Me.btnNuevoPie = New System.Windows.Forms.Button()
        Me.btnNuevaEscalera = New System.Windows.Forms.Button()
        Me.VistaDeLaMano = New ChinchonWinForms.ManoPorJugador()
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.VistaDeLaMano)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(894, 215)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Cartas en Mano"
        '
        'tablePanel
        '
        Me.tablePanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tablePanel.AutoScroll = true
        Me.tablePanel.ColumnCount = 1
        Me.tablePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tablePanel.Location = New System.Drawing.Point(12, 268)
        Me.tablePanel.Name = "tablePanel"
        Me.tablePanel.RowCount = 1
        Me.tablePanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tablePanel.Size = New System.Drawing.Size(894, 283)
        Me.tablePanel.TabIndex = 1
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConfirmar.Location = New System.Drawing.Point(348, 567)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(100, 30)
        Me.btnConfirmar.TabIndex = 2
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = true
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(470, 567)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = true
        '
        'btnNuevoChinchon
        '
        Me.btnNuevoChinchon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNuevoChinchon.Location = New System.Drawing.Point(214, 232)
        Me.btnNuevoChinchon.Name = "btnNuevoChinchon"
        Me.btnNuevoChinchon.Size = New System.Drawing.Size(100, 30)
        Me.btnNuevoChinchon.TabIndex = 4
        Me.btnNuevoChinchon.Text = "Chinchón"
        Me.btnNuevoChinchon.UseVisualStyleBackColor = true
        '
        'btnNuevoPie
        '
        Me.btnNuevoPie.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNuevoPie.Location = New System.Drawing.Point(604, 232)
        Me.btnNuevoPie.Name = "btnNuevoPie"
        Me.btnNuevoPie.Size = New System.Drawing.Size(100, 30)
        Me.btnNuevoPie.TabIndex = 5
        Me.btnNuevoPie.Text = "Pie"
        Me.btnNuevoPie.UseVisualStyleBackColor = true
        '
        'btnNuevaEscalera
        '
        Me.btnNuevaEscalera.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNuevaEscalera.Location = New System.Drawing.Point(409, 234)
        Me.btnNuevaEscalera.Name = "btnNuevaEscalera"
        Me.btnNuevaEscalera.Size = New System.Drawing.Size(100, 30)
        Me.btnNuevaEscalera.TabIndex = 6
        Me.btnNuevaEscalera.Text = "Escalera"
        Me.btnNuevaEscalera.UseVisualStyleBackColor = true
        '
        'VistaDeLaMano
        '
        Me.VistaDeLaMano.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.VistaDeLaMano.BackColor = System.Drawing.Color.Transparent
        Me.VistaDeLaMano.Location = New System.Drawing.Point(6, 19)
        Me.VistaDeLaMano.Name = "VistaDeLaMano"
        Me.VistaDeLaMano.Size = New System.Drawing.Size(882, 190)
        Me.VistaDeLaMano.TabIndex = 0
        '
        'frmPresentarCombinaciones
        '
        Me.AcceptButton = Me.btnConfirmar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(919, 609)
        Me.Controls.Add(Me.btnNuevaEscalera)
        Me.Controls.Add(Me.btnNuevoPie)
        Me.Controls.Add(Me.btnNuevoChinchon)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.tablePanel)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimizeBox = false
        Me.Name = "frmPresentarCombinaciones"
        Me.Text = "frmPresentarCombinaciones"
        Me.GroupBox1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents tablePanel As TableLayoutPanel
    Private WithEvents btnConfirmar As Button
    Private WithEvents btnCancelar As Button
    Private WithEvents VistaDeLaMano As ManoPorJugador
    Private WithEvents btnNuevoChinchon As Button
    Private WithEvents btnNuevoPie As Button
    Private WithEvents btnNuevaEscalera As Button
End Class
