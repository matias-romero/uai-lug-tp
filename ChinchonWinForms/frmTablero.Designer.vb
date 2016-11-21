<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTablero
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.groupMano = New System.Windows.Forms.GroupBox()
        Me.lblPuntaje = New System.Windows.Forms.Label()
        Me.lblPuntajeAcumulado = New System.Windows.Forms.Label()
        Me.ManoPorJugador1 = New ChinchonWinForms.ManoPorJugador()
        Me.panelNotificador = New ChinchonWinForms.Notificador()
        Me.ManoOponente3 = New ChinchonWinForms.ManoOponente()
        Me.ManoOponente2 = New ChinchonWinForms.ManoOponente()
        Me.ManoOponente1 = New ChinchonWinForms.ManoOponente()
        Me.VisorMonton = New ChinchonWinForms.VisorMonton()
        Me.VisorMazo = New ChinchonWinForms.VisorCarta()
        Me.groupMano.SuspendLayout
        Me.SuspendLayout
        '
        'groupMano
        '
        Me.groupMano.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupMano.Controls.Add(Me.lblPuntajeAcumulado)
        Me.groupMano.Controls.Add(Me.lblPuntaje)
        Me.groupMano.Controls.Add(Me.ManoPorJugador1)
        Me.groupMano.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.groupMano.Location = New System.Drawing.Point(12, 548)
        Me.groupMano.Name = "groupMano"
        Me.groupMano.Size = New System.Drawing.Size(901, 173)
        Me.groupMano.TabIndex = 9
        Me.groupMano.TabStop = false
        Me.groupMano.Text = "<Name>"
        '
        'lblPuntaje
        '
        Me.lblPuntaje.AutoSize = true
        Me.lblPuntaje.Location = New System.Drawing.Point(24, 31)
        Me.lblPuntaje.Name = "lblPuntaje"
        Me.lblPuntaje.Size = New System.Drawing.Size(70, 20)
        Me.lblPuntaje.TabIndex = 1
        Me.lblPuntaje.Text = "Puntaje"
        '
        'lblPuntajeAcumulado
        '
        Me.lblPuntajeAcumulado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblPuntajeAcumulado.Font = New System.Drawing.Font("Calisto MT", 36!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblPuntajeAcumulado.Location = New System.Drawing.Point(6, 51)
        Me.lblPuntajeAcumulado.Name = "lblPuntajeAcumulado"
        Me.lblPuntajeAcumulado.Size = New System.Drawing.Size(101, 108)
        Me.lblPuntajeAcumulado.TabIndex = 2
        Me.lblPuntajeAcumulado.Text = "100"
        Me.lblPuntajeAcumulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ManoPorJugador1
        '
        Me.ManoPorJugador1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ManoPorJugador1.BackColor = System.Drawing.Color.Transparent
        Me.ManoPorJugador1.Location = New System.Drawing.Point(132, 9)
        Me.ManoPorJugador1.Margin = New System.Windows.Forms.Padding(5)
        Me.ManoPorJugador1.Name = "ManoPorJugador1"
        Me.ManoPorJugador1.Size = New System.Drawing.Size(770, 165)
        Me.ManoPorJugador1.TabIndex = 0
        '
        'panelNotificador
        '
        Me.panelNotificador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.panelNotificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelNotificador.Location = New System.Drawing.Point(168, 192)
        Me.panelNotificador.Mensaje = ""
        Me.panelNotificador.Name = "panelNotificador"
        Me.panelNotificador.Size = New System.Drawing.Size(574, 54)
        Me.panelNotificador.Sugerencia = ""
        Me.panelNotificador.TabIndex = 8
        '
        'ManoOponente3
        '
        Me.ManoOponente3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ManoOponente3.Location = New System.Drawing.Point(748, 192)
        Me.ManoOponente3.MostrarHorizontal = true
        Me.ManoOponente3.Name = "ManoOponente3"
        Me.ManoOponente3.Size = New System.Drawing.Size(150, 350)
        Me.ManoOponente3.TabIndex = 7
        Me.ManoOponente3.Visible = false
        '
        'ManoOponente2
        '
        Me.ManoOponente2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.ManoOponente2.Location = New System.Drawing.Point(12, 192)
        Me.ManoOponente2.MostrarHorizontal = true
        Me.ManoOponente2.Name = "ManoOponente2"
        Me.ManoOponente2.Size = New System.Drawing.Size(150, 350)
        Me.ManoOponente2.TabIndex = 6
        Me.ManoOponente2.Visible = false
        '
        'ManoOponente1
        '
        Me.ManoOponente1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ManoOponente1.Location = New System.Drawing.Point(127, 12)
        Me.ManoOponente1.Name = "ManoOponente1"
        Me.ManoOponente1.Size = New System.Drawing.Size(700, 165)
        Me.ManoOponente1.TabIndex = 5
        '
        'VisorMonton
        '
        Me.VisorMonton.AllowDrop = true
        Me.VisorMonton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VisorMonton.CartaVisible = Nothing
        Me.VisorMonton.Location = New System.Drawing.Point(269, 252)
        Me.VisorMonton.Name = "VisorMonton"
        Me.VisorMonton.Size = New System.Drawing.Size(197, 255)
        Me.VisorMonton.TabIndex = 4
        '
        'VisorMazo
        '
        Me.VisorMazo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VisorMazo.Carta = Nothing
        Me.VisorMazo.HabilitarComoFuenteDeArrastre = true
        Me.VisorMazo.Location = New System.Drawing.Point(527, 322)
        Me.VisorMazo.MostrarCarta = false
        Me.VisorMazo.Name = "VisorMazo"
        Me.VisorMazo.RolAsignado = "Mazo"
        Me.VisorMazo.Size = New System.Drawing.Size(133, 185)
        Me.VisorMazo.TabIndex = 1
        '
        'frmTablero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(925, 733)
        Me.Controls.Add(Me.groupMano)
        Me.Controls.Add(Me.panelNotificador)
        Me.Controls.Add(Me.ManoOponente3)
        Me.Controls.Add(Me.ManoOponente2)
        Me.Controls.Add(Me.ManoOponente1)
        Me.Controls.Add(Me.VisorMonton)
        Me.Controls.Add(Me.VisorMazo)
        Me.Name = "frmTablero"
        Me.Text = "frmTablero"
        Me.groupMano.ResumeLayout(false)
        Me.groupMano.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Private WithEvents ManoPorJugador1 As ManoPorJugador
    Private WithEvents VisorMazo As VisorCarta
    Private WithEvents VisorMonton As VisorMonton
    Private WithEvents ManoOponente1 As ManoOponente
    Private WithEvents ManoOponente2 As ManoOponente
    Private WithEvents ManoOponente3 As ManoOponente
    Private WithEvents panelNotificador As Notificador
    Private WithEvents groupMano As GroupBox
    Private WithEvents lblPuntajeAcumulado As Label
    Private WithEvents lblPuntaje As Label
End Class
