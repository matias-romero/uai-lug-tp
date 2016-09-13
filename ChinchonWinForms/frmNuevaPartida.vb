Imports Chinchon

Public Class frmNuevaPartida
    Private _partida As Partida
    Private ReadOnly _sesionActual As Sesion = Sesion.DefaultInstance

    Private Sub frmNuevaPartida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Bienvenido! Presione comenzar cuando esté listo"

        _partida = New Partida()
        AddHandler _partida.PartidaListaParaEmpezar, AddressOf Me.PartidaActualListaParaEmpezar
    End Sub

    Private Sub btnComenzar_Click(sender As Object, e As EventArgs) Handles btnComenzar.Click
        _partida.Comenzar()
    End Sub

    Private Sub lnkIniciarSession_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIniciarSession.LinkClicked
        Dim nuevoJugador As Jugador = frmLoginJugador.PreguntarCredenciales("Ingrese sus credenciales para poder jugar", _sesionActual.RepositorioJugadores())
        If nuevoJugador IsNot Nothing Then
            _partida.Unirse(nuevoJugador)

            Call Me.EnlazarListado()
        End If
    End Sub

    Private Sub PartidaActualListaParaEmpezar(sender As Object, e As EventArgs)
        Me.btnComenzar.Enabled = True
    End Sub

    Private Sub EnlazarListado()
        Dim listadoUsuarios As IList(Of Jugador) = _partida.Jugadores.ToList()
        Me.lstUsuariosConectados.DataSource = Nothing
        Me.lstUsuariosConectados.DataSource = listadoUsuarios

        Me.progressUsuariosConectados.Value = listadoUsuarios.Count
    End Sub
End Class