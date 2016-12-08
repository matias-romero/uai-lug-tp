<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notificador
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.timerAnimacion = New System.Windows.Forms.Timer(Me.components)
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.lblSugerencia = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'timerAnimacion
        '
        Me.timerAnimacion.Interval = 500
        '
        'lblMensaje
        '
        Me.lblMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(-3, 0)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(246, 45)
        Me.lblMensaje.TabIndex = 0
        Me.lblMensaje.Text = "<Mensaje>"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSugerencia
        '
        Me.lblSugerencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblSugerencia.Location = New System.Drawing.Point(-3, 45)
        Me.lblSugerencia.Name = "lblSugerencia"
        Me.lblSugerencia.Size = New System.Drawing.Size(246, 17)
        Me.lblSugerencia.TabIndex = 1
        Me.lblSugerencia.Text = "<Sugerencia>"
        Me.lblSugerencia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Notificador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblSugerencia)
        Me.Controls.Add(Me.lblMensaje)
        Me.Name = "Notificador"
        Me.Size = New System.Drawing.Size(243, 62)
        Me.ResumeLayout(false)

End Sub

    Private WithEvents timerAnimacion As Timer
    Private WithEvents lblMensaje As Label
    Private WithEvents lblSugerencia As Label
End Class
