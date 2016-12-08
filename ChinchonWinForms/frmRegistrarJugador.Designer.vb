<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistrarJugador
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
        Me.components = New System.ComponentModel.Container()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.txtPasswordRetry = New System.Windows.Forms.TextBox()
        Me.RepeatPasswordLabel = New System.Windows.Forms.Label()
        Me.CustomErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.LogoPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CustomErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(230, 218)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "&Cancelar"
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(130, 218)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 6
        Me.OK.Text = "C&onfirmar"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(189, 108)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(220, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(189, 45)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(220, 20)
        Me.txtUsername.TabIndex = 1
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(189, 75)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(189, 12)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Usuario (Apodo)"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.ChinchonWinForms.My.Resources.Resources.ChinchonLogo
        Me.LogoPictureBox.Location = New System.Drawing.Point(12, 12)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(168, 180)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.LogoPictureBox.TabIndex = 7
        Me.LogoPictureBox.TabStop = false
        '
        'txtPasswordRetry
        '
        Me.txtPasswordRetry.Location = New System.Drawing.Point(189, 171)
        Me.txtPasswordRetry.Name = "txtPasswordRetry"
        Me.txtPasswordRetry.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordRetry.Size = New System.Drawing.Size(220, 20)
        Me.txtPasswordRetry.TabIndex = 5
        '
        'RepeatPasswordLabel
        '
        Me.RepeatPasswordLabel.Location = New System.Drawing.Point(189, 138)
        Me.RepeatPasswordLabel.Name = "RepeatPasswordLabel"
        Me.RepeatPasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.RepeatPasswordLabel.TabIndex = 4
        Me.RepeatPasswordLabel.Text = "Confirmar Contraseña"
        Me.RepeatPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomErrorProvider
        '
        Me.CustomErrorProvider.ContainerControl = Me
        '
        'frmRegistrarJugador
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(455, 258)
        Me.ControlBox = false
        Me.Controls.Add(Me.txtPasswordRetry)
        Me.Controls.Add(Me.RepeatPasswordLabel)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRegistrarJugador"
        Me.Text = "frmRegistrarJugador"
        CType(Me.LogoPictureBox,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CustomErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Private WithEvents Cancel As Button
    Private WithEvents OK As Button
    Private WithEvents txtPassword As TextBox
    Private WithEvents txtUsername As TextBox
    Private WithEvents PasswordLabel As Label
    Private WithEvents UsernameLabel As Label
    Private WithEvents LogoPictureBox As PictureBox
    Private WithEvents txtPasswordRetry As TextBox
    Private WithEvents RepeatPasswordLabel As Label
    Friend WithEvents CustomErrorProvider As ErrorProvider
End Class
