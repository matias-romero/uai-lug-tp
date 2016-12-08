
Imports Chinchon.Entities
Imports Chinchon.Entities.Exceptions

Public Class frmLoginJugador
    Private ReadOnly _jugadorRepositorio As IJugadorRepositorio

    Public Sub New(jugadorRepositorio As IJugadorRepositorio)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _jugadorRepositorio = jugadorRepositorio
    End Sub

    Public Property JugadorLogueado As Jugador

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim usuario As String = Me.UsernameTextBox.Text
        Dim password As String = Me.PasswordTextBox.Text

        Try
            Me.JugadorLogueado = _jugadorRepositorio.ValidarCredenciales(usuario, password)
            Me.DialogResult = DialogResult.OK
        Catch ex As CredencialesInvalidasException
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Public Shared Function PreguntarCredenciales(titulo As String, repositorio As IJugadorRepositorio) As Jugador
        Dim jugadorLogueado As Jugador = Nothing
        Using formLogin As New frmLoginJugador(repositorio)
            formLogin.Text = titulo
            formLogin.StartPosition = FormStartPosition.CenterScreen
            If formLogin.ShowDialog() = DialogResult.OK Then
                jugadorLogueado = formLogin.JugadorLogueado
            End If
        End Using

        Return jugadorLogueado
    End Function
End Class
