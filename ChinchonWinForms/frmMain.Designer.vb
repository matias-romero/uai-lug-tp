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
        Me.MainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.PartidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenarTablerosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuStrip.SuspendLayout
        Me.SuspendLayout
        '
        'MainMenuStrip
        '
        Me.MainMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12!)
        Me.MainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartidaToolStripMenuItem})
        Me.MainMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainMenuStrip.Name = "MainMenuStrip"
        Me.MainMenuStrip.Size = New System.Drawing.Size(925, 29)
        Me.MainMenuStrip.TabIndex = 1
        Me.MainMenuStrip.Text = "MenuStrip1"
        '
        'PartidaToolStripMenuItem
        '
        Me.PartidaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem, Me.OrdenarTablerosToolStripMenuItem, Me.ToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.PartidaToolStripMenuItem.Name = "PartidaToolStripMenuItem"
        Me.PartidaToolStripMenuItem.Size = New System.Drawing.Size(70, 25)
        Me.PartidaToolStripMenuItem.Text = "Partida"
        '
        'NuevaToolStripMenuItem
        '
        Me.NuevaToolStripMenuItem.Name = "NuevaToolStripMenuItem"
        Me.NuevaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N),System.Windows.Forms.Keys)
        Me.NuevaToolStripMenuItem.Size = New System.Drawing.Size(207, 26)
        Me.NuevaToolStripMenuItem.Text = "Nueva..."
        '
        'OrdenarTablerosToolStripMenuItem
        '
        Me.OrdenarTablerosToolStripMenuItem.Name = "OrdenarTablerosToolStripMenuItem"
        Me.OrdenarTablerosToolStripMenuItem.Size = New System.Drawing.Size(207, 26)
        Me.OrdenarTablerosToolStripMenuItem.Text = "Ordenar tableros..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(204, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(207, 26)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(925, 733)
        Me.Controls.Add(Me.MainMenuStrip)
        Me.IsMdiContainer = true
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.MainMenuStrip.ResumeLayout(false)
        Me.MainMenuStrip.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents MainMenuStrip As MenuStrip
    Friend WithEvents PartidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdenarTablerosToolStripMenuItem As ToolStripMenuItem
End Class
