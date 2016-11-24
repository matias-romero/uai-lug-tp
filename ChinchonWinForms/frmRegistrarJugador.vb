Imports Chinchon.Entities
Imports Chinchon.Entities.Exceptions

Public Class frmRegistrarJugador
    Private ReadOnly _jugadorRepositorio As IJugadorRepositorio

    Public Sub New(jugadorRepositorio As IJugadorRepositorio)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _jugadorRepositorio = jugadorRepositorio
    End Sub

    Public Property Apodo As String
        Get
            Return Me.txtUsername.Text
        End Get
        Set(value As String)
            Me.txtUsername.Text = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return Me.txtPassword.Text
        End Get
        Set(value As String)
            Me.txtPassword.Text = value
        End Set
    End Property

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        If Me.ValidarControles() Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Function ValidarControles() As Boolean
        Call Me.CustomErrorProvider.Clear()

        If String.IsNullOrWhiteSpace(Me.txtUsername.Text) Then
            Me.CustomErrorProvider.SetError(Me.txtUsername, "El apodo es requerido")
            Me.txtUsername.Focus()
            Return False
        End If

        If _jugadorRepositorio.ExisteApodo(Me.txtUsername.Text) Then
            Me.CustomErrorProvider.SetError(Me.txtUsername, "El apodo seleccionado ya existe")
            Me.txtUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(Me.txtPassword.Text) Then
            Me.CustomErrorProvider.SetError(Me.txtPassword, "La contraseña es requerida")
            Me.txtPassword.Focus()
            Return False
        End If

        If Not String.Equals(Me.txtPassword.Text, Me.txtPasswordRetry.Text) Then
            Me.CustomErrorProvider.SetError(Me.txtPassword, "La contraseñas no coinciden")
            Me.CustomErrorProvider.SetError(Me.txtPasswordRetry, "La contraseñas no coinciden")
            Me.txtPasswordRetry.Focus()
            Return False
        End If

        Return True
    End Function

    Public Shared Function RegistrarJugador(titulo As String, repositorio As IJugadorRepositorio) As Jugador
        Dim nuevoJugador As Jugador = Nothing
        Using formRegistrar As New frmRegistrarJugador(repositorio)
            formRegistrar.Text = titulo
            formRegistrar.StartPosition = FormStartPosition.CenterScreen
            If formRegistrar.ShowDialog() = DialogResult.OK Then
                Dim usuario As String = formRegistrar.Apodo
                Dim password As String = formRegistrar.Password
                Try
                    nuevoJugador = repositorio.RegistrarNuevo(usuario, password)
                Catch ex As ApodoJugadorExistenteException
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        End Using

        Return nuevoJugador
    End Function
End Class