<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfilJugador
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
        Me.groupEstadisticas = New System.Windows.Forms.GroupBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblPromedioVictorias = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalPartidas = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalJugado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDerrotas = New System.Windows.Forms.Label()
        Me.lblVictorias = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.groupEstadisticas.SuspendLayout
        Me.SuspendLayout
        '
        'groupEstadisticas
        '
        Me.groupEstadisticas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupEstadisticas.Controls.Add(Me.lblNombre)
        Me.groupEstadisticas.Controls.Add(Me.lblPromedioVictorias)
        Me.groupEstadisticas.Controls.Add(Me.Label8)
        Me.groupEstadisticas.Controls.Add(Me.lblTotalPartidas)
        Me.groupEstadisticas.Controls.Add(Me.Label7)
        Me.groupEstadisticas.Controls.Add(Me.lblTotalJugado)
        Me.groupEstadisticas.Controls.Add(Me.Label5)
        Me.groupEstadisticas.Controls.Add(Me.Label4)
        Me.groupEstadisticas.Controls.Add(Me.Label3)
        Me.groupEstadisticas.Controls.Add(Me.Label2)
        Me.groupEstadisticas.Controls.Add(Me.lblDerrotas)
        Me.groupEstadisticas.Controls.Add(Me.lblVictorias)
        Me.groupEstadisticas.Location = New System.Drawing.Point(13, 13)
        Me.groupEstadisticas.Name = "groupEstadisticas"
        Me.groupEstadisticas.Size = New System.Drawing.Size(791, 467)
        Me.groupEstadisticas.TabIndex = 0
        Me.groupEstadisticas.TabStop = false
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 48!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblNombre.Location = New System.Drawing.Point(6, 16)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(779, 73)
        Me.lblNombre.TabIndex = 11
        Me.lblNombre.Text = "<Nombre>"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPromedioVictorias
        '
        Me.lblPromedioVictorias.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPromedioVictorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblPromedioVictorias.Location = New System.Drawing.Point(339, 297)
        Me.lblPromedioVictorias.Name = "lblPromedioVictorias"
        Me.lblPromedioVictorias.Size = New System.Drawing.Size(112, 38)
        Me.lblPromedioVictorias.TabIndex = 10
        Me.lblPromedioVictorias.Text = "100%"
        Me.lblPromedioVictorias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(298, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(195, 24)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Promedio de Victorias"
        '
        'lblTotalPartidas
        '
        Me.lblTotalPartidas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblTotalPartidas.AutoSize = true
        Me.lblTotalPartidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTotalPartidas.Location = New System.Drawing.Point(249, 424)
        Me.lblTotalPartidas.Name = "lblTotalPartidas"
        Me.lblTotalPartidas.Size = New System.Drawing.Size(20, 24)
        Me.lblTotalPartidas.TabIndex = 8
        Me.lblTotalPartidas.Text = "0"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 372)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 24)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Total Jugado:"
        '
        'lblTotalJugado
        '
        Me.lblTotalJugado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblTotalJugado.AutoSize = true
        Me.lblTotalJugado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTotalJugado.Location = New System.Drawing.Point(249, 372)
        Me.lblTotalJugado.Name = "lblTotalJugado"
        Me.lblTotalJugado.Size = New System.Drawing.Size(112, 24)
        Me.lblTotalJugado.TabIndex = 6
        Me.lblTotalJugado.Text = "0d 0h 0m 0s"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(436, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 24)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Derrotas"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(278, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 24)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Victorias"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Total Partidas Jugadas:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 48!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(376, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 100)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "/"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDerrotas
        '
        Me.lblDerrotas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDerrotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 24!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDerrotas.Location = New System.Drawing.Point(416, 141)
        Me.lblDerrotas.Name = "lblDerrotas"
        Me.lblDerrotas.Size = New System.Drawing.Size(100, 100)
        Me.lblDerrotas.TabIndex = 1
        Me.lblDerrotas.Text = "00"
        Me.lblDerrotas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVictorias
        '
        Me.lblVictorias.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVictorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 24!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVictorias.Location = New System.Drawing.Point(275, 141)
        Me.lblVictorias.Name = "lblVictorias"
        Me.lblVictorias.Size = New System.Drawing.Size(100, 100)
        Me.lblVictorias.TabIndex = 0
        Me.lblVictorias.Text = "00"
        Me.lblVictorias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(358, 497)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 30)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = true
        '
        'frmPerfilJugador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(816, 541)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.groupEstadisticas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPerfilJugador"
        Me.Text = "Estadísticas del jugador"
        Me.groupEstadisticas.ResumeLayout(false)
        Me.groupEstadisticas.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents groupEstadisticas As GroupBox
    Private WithEvents lblDerrotas As Label
    Private WithEvents lblVictorias As Label
    Private WithEvents Label2 As Label
    Private WithEvents Label5 As Label
    Private WithEvents Label4 As Label
    Private WithEvents Label3 As Label
    Private WithEvents lblTotalJugado As Label
    Private WithEvents lblTotalPartidas As Label
    Private WithEvents Label7 As Label
    Private WithEvents lblPromedioVictorias As Label
    Private WithEvents Label8 As Label
    Private WithEvents btnCerrar As Button
    Private WithEvents lblNombre As Label
End Class
