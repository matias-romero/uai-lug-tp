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
        Me.groupUsuariosConectados = New System.Windows.Forms.GroupBox()
        Me.lnkIniciarSession = New System.Windows.Forms.LinkLabel()
        Me.progressUsuariosConectados = New System.Windows.Forms.ProgressBar()
        Me.lstUsuariosConectados = New System.Windows.Forms.ListBox()
        Me.lblPuntajeLimite = New System.Windows.Forms.Label()
        Me.lblCodigoPartida = New System.Windows.Forms.Label()
        Me.btnComenzar = New System.Windows.Forms.Button()
        Me.txtPuntajeLimite = New System.Windows.Forms.NumericUpDown()
        Me.container.SuspendLayout()
        Me.groupUsuariosConectados.SuspendLayout()
        CType(Me.txtPuntajeLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'container
        '
        Me.container.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.container.Controls.Add(Me.txtPuntajeLimite)
        Me.container.Controls.Add(Me.groupUsuariosConectados)
        Me.container.Controls.Add(Me.lblPuntajeLimite)
        Me.container.Controls.Add(Me.lblCodigoPartida)
        Me.container.Location = New System.Drawing.Point(12, 12)
        Me.container.Name = "container"
        Me.container.Size = New System.Drawing.Size(313, 294)
        Me.container.TabIndex = 0
        Me.container.TabStop = False
        '
        'groupUsuariosConectados
        '
        Me.groupUsuariosConectados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupUsuariosConectados.Controls.Add(Me.lnkIniciarSession)
        Me.groupUsuariosConectados.Controls.Add(Me.progressUsuariosConectados)
        Me.groupUsuariosConectados.Controls.Add(Me.lstUsuariosConectados)
        Me.groupUsuariosConectados.Location = New System.Drawing.Point(6, 105)
        Me.groupUsuariosConectados.Name = "groupUsuariosConectados"
        Me.groupUsuariosConectados.Size = New System.Drawing.Size(301, 183)
        Me.groupUsuariosConectados.TabIndex = 4
        Me.groupUsuariosConectados.TabStop = False
        '
        'lnkIniciarSession
        '
        Me.lnkIniciarSession.AutoSize = True
        Me.lnkIniciarSession.Location = New System.Drawing.Point(6, 0)
        Me.lnkIniciarSession.Name = "lnkIniciarSession"
        Me.lnkIniciarSession.Size = New System.Drawing.Size(92, 13)
        Me.lnkIniciarSession.TabIndex = 7
        Me.lnkIniciarSession.TabStop = True
        Me.lnkIniciarSession.Text = "Unirse a la partida"
        '
        'progressUsuariosConectados
        '
        Me.progressUsuariosConectados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressUsuariosConectados.Location = New System.Drawing.Point(6, 152)
        Me.progressUsuariosConectados.Maximum = 4
        Me.progressUsuariosConectados.Name = "progressUsuariosConectados"
        Me.progressUsuariosConectados.Size = New System.Drawing.Size(289, 23)
        Me.progressUsuariosConectados.TabIndex = 6
        '
        'lstUsuariosConectados
        '
        Me.lstUsuariosConectados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstUsuariosConectados.FormattingEnabled = True
        Me.lstUsuariosConectados.Location = New System.Drawing.Point(6, 25)
        Me.lstUsuariosConectados.Name = "lstUsuariosConectados"
        Me.lstUsuariosConectados.Size = New System.Drawing.Size(289, 121)
        Me.lstUsuariosConectados.TabIndex = 0
        '
        'lblPuntajeLimite
        '
        Me.lblPuntajeLimite.AutoSize = True
        Me.lblPuntajeLimite.Location = New System.Drawing.Point(6, 71)
        Me.lblPuntajeLimite.Name = "lblPuntajeLimite"
        Me.lblPuntajeLimite.Size = New System.Drawing.Size(75, 13)
        Me.lblPuntajeLimite.TabIndex = 2
        Me.lblPuntajeLimite.Text = "Puntaje Límite"
        '
        'lblCodigoPartida
        '
        Me.lblCodigoPartida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCodigoPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnComenzar.Enabled = False
        Me.btnComenzar.Location = New System.Drawing.Point(117, 312)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(93, 31)
        Me.btnComenzar.TabIndex = 1
        Me.btnComenzar.Text = "&Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = True
        '
        'txtPuntajeLimite
        '
        Me.txtPuntajeLimite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPuntajeLimite.Location = New System.Drawing.Point(105, 69)
        Me.txtPuntajeLimite.Name = "txtPuntajeLimite"
        Me.txtPuntajeLimite.Size = New System.Drawing.Size(196, 20)
        Me.txtPuntajeLimite.TabIndex = 5
        '
        'frmNuevaPartida
        '
        Me.AcceptButton = Me.btnComenzar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 352)
        Me.Controls.Add(Me.btnComenzar)
        Me.Controls.Add(Me.container)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNuevaPartida"
        Me.Text = "frmNuevaPartida"
        Me.container.ResumeLayout(False)
        Me.container.PerformLayout()
        Me.groupUsuariosConectados.ResumeLayout(False)
        Me.groupUsuariosConectados.PerformLayout()
        CType(Me.txtPuntajeLimite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents container As GroupBox
    Friend WithEvents btnComenzar As Button
    Friend WithEvents lblCodigoPartida As Label
    Friend WithEvents lblPuntajeLimite As Label
    Friend WithEvents groupUsuariosConectados As GroupBox
    Friend WithEvents lstUsuariosConectados As ListBox
    Friend WithEvents progressUsuariosConectados As ProgressBar
    Friend WithEvents lnkIniciarSession As LinkLabel
    Friend WithEvents txtPuntajeLimite As NumericUpDown
End Class
