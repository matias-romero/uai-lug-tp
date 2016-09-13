Imports Chinchon
Imports Chinchon.Data

Public Class frmLoginJugador
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Shared Function PreguntarCredenciales(titulo As String, repositorio As JugadorRepositorio) As Jugador
        Dim jugadorLogueado As Jugador = Nothing
        Using formLogin As New frmLoginJugador()
            formLogin.Text = titulo
            If formLogin.ShowDialog() = DialogResult.OK Then
                Dim usuario As String = formLogin.UsernameTextBox.Text
                Dim password As String = formLogin.PasswordTextBox.Text

                Try
                    jugadorLogueado = repositorio.ValidarCredenciales(usuario, password)
                Catch ex As CredencialesInvalidadException
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        End Using

        Return jugadorLogueado
    End Function
End Class
