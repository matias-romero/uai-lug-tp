﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.VisorMonton = New ChinchonWinForms.VisorMonton()
        Me.VisorMazo = New ChinchonWinForms.VisorCarta()
        Me.ManoPorJugador1 = New ChinchonWinForms.ManoPorJugador()
        Me.ManoOponente1 = New ChinchonWinForms.ManoOponente()
        Me.ManoOponente2 = New ChinchonWinForms.ManoOponente()
        Me.ManoOponente3 = New ChinchonWinForms.ManoOponente()
        Me.SuspendLayout
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
        'ManoPorJugador1
        '
        Me.ManoPorJugador1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ManoPorJugador1.BackColor = System.Drawing.Color.Transparent
        Me.ManoPorJugador1.Location = New System.Drawing.Point(127, 597)
        Me.ManoPorJugador1.Name = "ManoPorJugador1"
        Me.ManoPorJugador1.Size = New System.Drawing.Size(700, 124)
        Me.ManoPorJugador1.TabIndex = 0
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
        'ManoOponente2
        '
        Me.ManoOponente2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.ManoOponente2.Location = New System.Drawing.Point(12, 192)
        Me.ManoOponente2.MostrarHorizontal = true
        Me.ManoOponente2.Name = "ManoOponente2"
        Me.ManoOponente2.Size = New System.Drawing.Size(165, 392)
        Me.ManoOponente2.TabIndex = 6
        '
        'ManoOponente3
        '
        Me.ManoOponente3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ManoOponente3.Location = New System.Drawing.Point(748, 192)
        Me.ManoOponente3.MostrarHorizontal = true
        Me.ManoOponente3.Name = "ManoOponente3"
        Me.ManoOponente3.Size = New System.Drawing.Size(165, 392)
        Me.ManoOponente3.TabIndex = 7
        '
        'frmTablero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(925, 733)
        Me.Controls.Add(Me.ManoOponente3)
        Me.Controls.Add(Me.ManoOponente2)
        Me.Controls.Add(Me.ManoOponente1)
        Me.Controls.Add(Me.VisorMonton)
        Me.Controls.Add(Me.VisorMazo)
        Me.Controls.Add(Me.ManoPorJugador1)
        Me.Name = "frmTablero"
        Me.Text = "frmTablero"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents ManoPorJugador1 As ManoPorJugador
    Friend WithEvents VisorMazo As VisorCarta
    Friend WithEvents VisorMonton As VisorMonton
    Friend WithEvents ManoOponente1 As ManoOponente
    Friend WithEvents ManoOponente2 As ManoOponente
    Friend WithEvents ManoOponente3 As ManoOponente
End Class
