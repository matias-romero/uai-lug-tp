<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorCombinacion
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
        Me.grupoContenedor = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.grupoContenedor.SuspendLayout
        Me.SuspendLayout
        '
        'grupoContenedor
        '
        Me.grupoContenedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grupoContenedor.Controls.Add(Me.flowPanel)
        Me.grupoContenedor.Controls.Add(Me.btnEliminar)
        Me.grupoContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grupoContenedor.Location = New System.Drawing.Point(3, 3)
        Me.grupoContenedor.Name = "grupoContenedor"
        Me.grupoContenedor.Size = New System.Drawing.Size(546, 241)
        Me.grupoContenedor.TabIndex = 0
        Me.grupoContenedor.TabStop = false
        Me.grupoContenedor.Text = "Nombre_Combinacion"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = Global.ChinchonWinForms.My.Resources.Resources.Red_Cross_svg
        Me.btnEliminar.Location = New System.Drawing.Point(511, -1)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(35, 23)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.UseVisualStyleBackColor = true
        '
        'flowPanel
        '
        Me.flowPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.flowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flowPanel.Location = New System.Drawing.Point(6, 29)
        Me.flowPanel.Name = "flowPanel"
        Me.flowPanel.Size = New System.Drawing.Size(534, 206)
        Me.flowPanel.TabIndex = 1
        '
        'VisorCombinacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grupoContenedor)
        Me.Name = "VisorCombinacion"
        Me.Size = New System.Drawing.Size(552, 247)
        Me.grupoContenedor.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Private WithEvents grupoContenedor As GroupBox
    Private WithEvents btnEliminar As Button
    Private WithEvents flowPanel As FlowLayoutPanel
End Class
