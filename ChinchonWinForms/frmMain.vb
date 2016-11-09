Imports Chinchon
Imports Chinchon.Entities

Public Class frmMain
    Private ReadOnly Orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each jugador As Jugador In Orquestador.PartidaActual.Jugadores
            Dim vistaPorJugador As VistaPorJugador = new VistaPorJugador(Orquestador.PartidaActual, jugador)
            Dim formTablero As frmTablero = new frmTablero(vistaPorJugador)
            formTablero.MdiParent = me
            formTablero.Show()
        Next
    End Sub
End Class
