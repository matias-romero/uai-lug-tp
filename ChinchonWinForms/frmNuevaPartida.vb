Imports Chinchon
Imports Chinchon.Entities

Public Class frmNuevaPartida
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Private Sub frmNuevaPartida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Resources.Titulo_NuevaPartida

        'Explicito la configuración que voy a utilizar con el programa
        Orquestador.UtilizarRepositoriosUsandoCadenaDeConexion(My.Settings.RepositorioPrincipal)
        Call Me.EnlazarDatosDePartida(Orquestador.PartidaActual)
    End Sub

    Private Sub EnlazarDatosDePartida(partida As Partida)
        AddHandler partida.PartidaListaParaEmpezar, AddressOf Me.PartidaActualListaParaEmpezar

        Me.lblCodigoPartida.Text = partida.Id.ToString()
        Me.txtPuntajeLimite.DataBindings.Add("Value", partida, "PuntajeLimite")
    End Sub

    Private Sub btnComenzar_Click(sender As Object, e As EventArgs) Handles btnComenzar.Click
        Orquestador.PartidaActual.Comenzar()
    End Sub

    Private Sub lnkIniciarSession_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIniciarSession.LinkClicked
        Dim nuevoJugador As Jugador = frmLoginJugador.PreguntarCredenciales(My.Resources.Titulo_IngreseSusCredenciales, Orquestador.Repositorios.Jugadores())
        If nuevoJugador IsNot Nothing Then
            Orquestador.PartidaActual.Unirse(nuevoJugador)

            Call Me.EnlazarListado()
        End If
    End Sub

    Private Sub PartidaActualListaParaEmpezar(sender As Object, e As EventArgs)
        Me.btnComenzar.Enabled = True
    End Sub

    Private Sub EnlazarListado()
        Dim listadoUsuarios As IList(Of Jugador) = Orquestador.PartidaActual.Jugadores.ToList()

        Me.lstUsuariosConectados.DataSource = Nothing
        Me.lstUsuariosConectados.DataSource = listadoUsuarios

        Me.progressUsuariosConectados.Value = listadoUsuarios.Count
    End Sub
End Class