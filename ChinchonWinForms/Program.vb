Imports Chinchon
Imports Chinchon.Entities

Public Module Program

    Public Sub Main()
        Dim orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

        'TODO: Remover inicialización para pruebas directas
        '**************************************************
        orquestador.CambiarPartidaActual(New Partida())
        Dim nuevoJugador  = New Jugador() With {.Id = 1, .Apodo = "Matias"}
        nuevoJugador.ParticipacionesRegistradasEnPartidas.Add(new ParticipacionJugadorEnPartida() With { .FueGanador = True, .TiempoDeJuegoNeto = TimeSpan.FromHours(1) })
        nuevoJugador.ParticipacionesRegistradasEnPartidas.Add(new ParticipacionJugadorEnPartida() With { .FueGanador = True, .TiempoDeJuegoNeto = TimeSpan.FromMinutes(15) })
        nuevoJugador.ParticipacionesRegistradasEnPartidas.Add(new ParticipacionJugadorEnPartida() With { .FueGanador = False, .TiempoDeJuegoNeto = TimeSpan.FromMinutes(30) })
        orquestador.PartidaActual.Unirse(nuevoJugador)
        orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 2, .Apodo = "Rival A"})
        'orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 3, .Apodo = "Rival B"})
        'orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 4, .Apodo = "Rival C"})

        orquestador.PartidaActual.Comenzar()
        '**************************************************

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain())
    End Sub
End Module
