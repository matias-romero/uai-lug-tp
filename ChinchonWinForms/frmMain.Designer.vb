<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.VisorMonton = New ChinchonWinForms.VisorMonton()
        Me.ManoPorJugador2 = New ChinchonWinForms.ManoPorJugador()
        Me.VisorMazo = New ChinchonWinForms.VisorCarta()
        Me.ManoPorJugador1 = New ChinchonWinForms.ManoPorJugador()
        Me.SuspendLayout()
        '
        'VisorMonton
        '
        Me.VisorMonton.AllowDrop = True
        Me.VisorMonton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VisorMonton.CartaVisible = Nothing
        Me.VisorMonton.Location = New System.Drawing.Point(299, 228)
        Me.VisorMonton.Name = "VisorMonton"
        Me.VisorMonton.Size = New System.Drawing.Size(197, 255)
        Me.VisorMonton.TabIndex = 4
        '
        'ManoPorJugador2
        '
        Me.ManoPorJugador2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ManoPorJugador2.BackColor = System.Drawing.Color.Transparent
        Me.ManoPorJugador2.Location = New System.Drawing.Point(158, 0)
        Me.ManoPorJugador2.Name = "ManoPorJugador2"
        Me.ManoPorJugador2.Size = New System.Drawing.Size(628, 124)
        Me.ManoPorJugador2.TabIndex = 3
        '
        'VisorMazo
        '
        Me.VisorMazo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VisorMazo.Carta = Nothing
        Me.VisorMazo.HabilitarComoFuenteDeArrastre = True
        Me.VisorMazo.Location = New System.Drawing.Point(529, 298)
        Me.VisorMazo.MostrarCarta = False
        Me.VisorMazo.Name = "VisorMazo"
        Me.VisorMazo.RolAsignado = "Mazo"
        Me.VisorMazo.Size = New System.Drawing.Size(133, 185)
        Me.VisorMazo.TabIndex = 1
        '
        'ManoPorJugador1
        '
        Me.ManoPorJugador1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ManoPorJugador1.BackColor = System.Drawing.Color.Transparent
        Me.ManoPorJugador1.Location = New System.Drawing.Point(158, 606)
        Me.ManoPorJugador1.Name = "ManoPorJugador1"
        Me.ManoPorJugador1.Size = New System.Drawing.Size(628, 124)
        Me.ManoPorJugador1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(925, 733)
        Me.Controls.Add(Me.VisorMonton)
        Me.Controls.Add(Me.ManoPorJugador2)
        Me.Controls.Add(Me.VisorMazo)
        Me.Controls.Add(Me.ManoPorJugador1)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ManoPorJugador1 As ManoPorJugador
    Friend WithEvents VisorMazo As VisorCarta
    Friend WithEvents ManoPorJugador2 As ManoPorJugador
    Friend WithEvents VisorMonton As VisorMonton
End Class
