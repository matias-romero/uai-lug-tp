<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorCarta
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
        Me.picture = New System.Windows.Forms.PictureBox()
        CType(Me.picture,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'picture
        '
        Me.picture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picture.Location = New System.Drawing.Point(0, 0)
        Me.picture.Name = "picture"
        Me.picture.Size = New System.Drawing.Size(315, 369)
        Me.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picture.TabIndex = 0
        Me.picture.TabStop = false
        '
        'VisorCarta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picture)
        Me.Name = "VisorCarta"
        Me.Size = New System.Drawing.Size(315, 369)
        CType(Me.picture,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Private WithEvents picture As PictureBox
End Class
