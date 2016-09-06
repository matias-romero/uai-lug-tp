<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.VisorCarta2 = New ChinchonWinForms.VisorCarta()
        Me.VisorCarta1 = New ChinchonWinForms.VisorCarta()
        Me.SuspendLayout()
        '
        'VisorCarta2
        '
        Me.VisorCarta2.Carta = Nothing
        Me.VisorCarta2.Location = New System.Drawing.Point(222, 29)
        Me.VisorCarta2.Name = "VisorCarta2"
        Me.VisorCarta2.Size = New System.Drawing.Size(119, 167)
        Me.VisorCarta2.TabIndex = 1
        '
        'VisorCarta1
        '
        Me.VisorCarta1.Carta = Nothing
        Me.VisorCarta1.Location = New System.Drawing.Point(26, 29)
        Me.VisorCarta1.MostrarCarta = False
        Me.VisorCarta1.Name = "VisorCarta1"
        Me.VisorCarta1.Size = New System.Drawing.Size(119, 167)
        Me.VisorCarta1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 456)
        Me.Controls.Add(Me.VisorCarta2)
        Me.Controls.Add(Me.VisorCarta1)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VisorCarta1 As VisorCarta
    Friend WithEvents VisorCarta2 As VisorCarta
End Class
