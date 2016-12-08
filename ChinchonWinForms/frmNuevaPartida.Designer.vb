<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevaPartida
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
        Me.container = New System.Windows.Forms.GroupBox()
        Me.txtPuntajeLimite = New System.Windows.Forms.NumericUpDown()
        Me.groupUsuariosConectados = New System.Windows.Forms.GroupBox()
        Me.lnkIniciarSession = New System.Windows.Forms.LinkLabel()
        Me.progressUsuariosConectados = New System.Windows.Forms.ProgressBar()
        Me.lstUsuariosConectados = New System.Windows.Forms.ListBox()
        Me.lblPuntajeLimite = New System.Windows.Forms.Label()
        Me.lblCodigoPartida = New System.Windows.Forms.Label()
        Me.btnComenzar = New System.Windows.Forms.Button()
        Me.container.SuspendLayout
        CType(Me.txtPuntajeLimite,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupUsuariosConectados.SuspendLayout
        Me.SuspendLayout
        '
        'container
        '
        Me.container.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.container.Controls.Add(Me.txtPuntajeLimite)
        Me.container.Controls.Add(Me.groupUsuariosConectados)
        Me.container.Controls.Add(Me.lblPuntajeLimite)
        Me.container.Controls.Add(Me.lblCodigoPartida)
        Me.container.Location = New System.Drawing.Point(12, 12)
        Me.container.Name = "container"
        Me.container.Size = New System.Drawing.Size(313, 294)
        Me.container.TabIndex = 0
        Me.container.TabStop = false
        '
        'txtPuntajeLimite
        '
        Me.txtPuntajeLimite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtPuntajeLimite.Location = New System.Drawing.Point(105, 69)
        Me.txtPuntajeLimite.Name = "txtPuntajeLimite"
        Me.txtPuntajeLimite.Size = New System.Drawing.Size(196, 20)
        Me.txtPuntajeLimite.TabIndex = 2
        '
        'groupUsuariosConectados
        '
        Me.groupUsuariosConectados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupUsuariosConectados.Controls.Add(Me.lnkIniciarSession)
        Me.groupUsuariosConectados.Controls.Add(Me.progressUsuariosConectados)
        Me.groupUsuariosConectados.Controls.Add(Me.lstUsuariosConectados)
        Me.groupUsuariosConectados.Location = New System.Drawing.Point(6, 105)
        Me.groupUsuariosConectados.Name = "groupUsuariosConectados"
        Me.groupUsuariosConectados.Size = New System.Drawing.Size(301, 183)
        Me.groupUsuariosConectados.TabIndex = 4
        Me.groupUsuariosConectados.TabStop = false
        '
        'lnkIniciarSession
        '
        Me.lnkIniciarSession.AutoSize = true
        Me.lnkIniciarSession.Location = New System.Drawing.Point(6, 0)
        Me.lnkIniciarSession.Name = "lnkIniciarSession"
        Me.lnkIniciarSession.Size = New System.Drawing.Size(92, 13)
        Me.lnkIniciarSession.TabIndex = 1
        Me.lnkIniciarSession.TabStop = true
        Me.lnkIniciarSession.Text = "Unirse a la partida"
        '
        'progressUsuariosConectados
        '
        Me.progressUsuariosConectados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.progressUsuariosConectados.Location = New System.Drawing.Point(6, 152)
        Me.progressUsuariosConectados.Maximum = 4
        Me.progressUsuariosConectados.Name = "progressUsuariosConectados"
        Me.progressUsuariosConectados.Size = New System.Drawing.Size(289, 23)
        Me.progressUsuariosConectados.TabIndex = 0
        '
        'lstUsuariosConectados
        '
        Me.lstUsuariosConectados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lstUsuariosConectados.FormattingEnabled = true
        Me.lstUsuariosConectados.Location = New System.Drawing.Point(6, 25)
        Me.lstUsuariosConectados.Name = "lstUsuariosConectados"
        Me.lstUsuariosConectados.Size = New System.Drawing.Size(289, 121)
        Me.lstUsuariosConectados.TabIndex = 2
        '
        'lblPuntajeLimite
        '
        Me.lblPuntajeLimite.AutoSize = true
        Me.lblPuntajeLimite.Location = New System.Drawing.Point(6, 71)
        Me.lblPuntajeLimite.Name = "lblPuntajeLimite"
        Me.lblPuntajeLimite.Size = New System.Drawing.Size(75, 13)
        Me.lblPuntajeLimite.TabIndex = 1
        Me.lblPuntajeLimite.Text = "Puntaje Límite"
        '
        'lblCodigoPartida
        '
        Me.lblCodigoPartida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblCodigoPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCodigoPartida.Location = New System.Drawing.Point(6, 16)
        Me.lblCodigoPartida.Name = "lblCodigoPartida"
        Me.lblCodigoPartida.Size = New System.Drawing.Size(301, 23)
        Me.lblCodigoPartida.TabIndex = 0
        Me.lblCodigoPartida.Text = "lblCodigoPartida"
        Me.lblCodigoPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnComenzar
        '
        Me.btnComenzar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnComenzar.Enabled = false
        Me.btnComenzar.Location = New System.Drawing.Point(122, 312)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(93, 31)
        Me.btnComenzar.TabIndex = 1
        Me.btnComenzar.Text = "&Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = true
        '
        'frmNuevaPartida
        '
        Me.AcceptButton = Me.btnComenzar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 352)
        Me.Controls.Add(Me.btnComenzar)
        Me.Controls.Add(Me.container)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNuevaPartida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNuevaPartida"
        Me.container.ResumeLayout(false)
        Me.container.PerformLayout
        CType(Me.txtPuntajeLimite,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupUsuariosConectados.ResumeLayout(false)
        Me.groupUsuariosConectados.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents groupUsuariosConectados As GroupBox
    Private WithEvents container As GroupBox
    Private WithEvents btnComenzar As Button
    Private WithEvents lblCodigoPartida As Label
    Private WithEvents lblPuntajeLimite As Label
    Private WithEvents lstUsuariosConectados As ListBox
    Private WithEvents progressUsuariosConectados As ProgressBar
    Private WithEvents lnkIniciarSession As LinkLabel
    Private WithEvents txtPuntajeLimite As NumericUpDown
End Class
