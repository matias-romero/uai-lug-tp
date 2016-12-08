<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorMonton
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
        Me.VisorCartaMonton = New ChinchonWinForms.VisorCarta()
        Me.picRedCross = New System.Windows.Forms.PictureBox()
        Me.picCartaCerrado = New System.Windows.Forms.PictureBox()
        CType(Me.picRedCross, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCartaCerrado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VisorCartaMonton
        '
        Me.VisorCartaMonton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VisorCartaMonton.Carta = Nothing
        Me.VisorCartaMonton.HabilitarComoDestinoDeArrastre = True
        Me.VisorCartaMonton.HabilitarComoFuenteDeArrastre = True
        Me.VisorCartaMonton.Location = New System.Drawing.Point(33, 70)
        Me.VisorCartaMonton.Name = "VisorCartaMonton"
        Me.VisorCartaMonton.RolAsignado = "Monton"
        Me.VisorCartaMonton.Size = New System.Drawing.Size(133, 185)
        Me.VisorCartaMonton.TabIndex = 3
        '
        'picRedCross
        '
        Me.picRedCross.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picRedCross.Image = Global.ChinchonWinForms.My.Resources.Resources.Red_Cross_svg
        Me.picRedCross.Location = New System.Drawing.Point(33, 0)
        Me.picRedCross.Name = "picRedCross"
        Me.picRedCross.Size = New System.Drawing.Size(133, 61)
        Me.picRedCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picRedCross.TabIndex = 4
        Me.picRedCross.TabStop = False
        '
        'picCartaCerrado
        '
        Me.picCartaCerrado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCartaCerrado.Location = New System.Drawing.Point(0, 106)
        Me.picCartaCerrado.Name = "picCartaCerrado"
        Me.picCartaCerrado.Size = New System.Drawing.Size(197, 120)
        Me.picCartaCerrado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCartaCerrado.TabIndex = 5
        Me.picCartaCerrado.TabStop = False
        Me.picCartaCerrado.Visible = False
        '
        'VisorMonton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picCartaCerrado)
        Me.Controls.Add(Me.picRedCross)
        Me.Controls.Add(Me.VisorCartaMonton)
        Me.Name = "VisorMonton"
        Me.Size = New System.Drawing.Size(197, 255)
        CType(Me.picRedCross, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCartaCerrado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VisorCartaMonton As VisorCarta
    Friend WithEvents picRedCross As PictureBox
    Friend WithEvents picCartaCerrado As PictureBox
End Class
