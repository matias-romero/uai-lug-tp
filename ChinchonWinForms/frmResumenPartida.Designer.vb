<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumenPartida
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
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFelicitaciones = New System.Windows.Forms.Label()
        Me.lblNombreGanador = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSalir.Location = New System.Drawing.Point(284, 697)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(133, 37)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 187)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(673, 490)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Resumen de la partida"
        '
        'lblFelicitaciones
        '
        Me.lblFelicitaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblFelicitaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 30!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblFelicitaciones.Location = New System.Drawing.Point(17, 16)
        Me.lblFelicitaciones.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFelicitaciones.Name = "lblFelicitaciones"
        Me.lblFelicitaciones.Size = New System.Drawing.Size(673, 71)
        Me.lblFelicitaciones.TabIndex = 2
        Me.lblFelicitaciones.Text = "¡Felicitaciones!"
        Me.lblFelicitaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreGanador
        '
        Me.lblNombreGanador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblNombreGanador.Font = New System.Drawing.Font("Microsoft Sans Serif", 30!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblNombreGanador.Location = New System.Drawing.Point(17, 102)
        Me.lblNombreGanador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreGanador.Name = "lblNombreGanador"
        Me.lblNombreGanador.Size = New System.Drawing.Size(673, 71)
        Me.lblNombreGanador.TabIndex = 3
        Me.lblNombreGanador.Text = "<Nombre>"
        Me.lblNombreGanador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmResumenPartida
        '
        Me.AcceptButton = Me.btnSalir
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 748)
        Me.Controls.Add(Me.lblNombreGanador)
        Me.Controls.Add(Me.lblFelicitaciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmResumenPartida"
        Me.Text = "frmResumenPartida"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents btnSalir As Button
    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents lblFelicitaciones As Label
    Private WithEvents lblNombreGanador As Label
End Class
