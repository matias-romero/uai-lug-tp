Imports Chinchon
Imports Chinchon.Entities

Public Module Program

    Public Sub Main()
        Dim orquestador As OrquestadorDelJuego = OrquestadorDelJuego.InstanciaPorDefecto

        'TODO: Remover inicialización para pruebas directas
        '**************************************************
        'AddHandler orquestador.PartidaActual.EmpiezaNuevaRonda, AddressOf Me.EmpiezaNuevoTurno
        'AddHandler orquestador.PartidaActual.EmpiezaNuevoTurno, AddressOf Me.EmpiezaNuevoTurno

        orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 1, .Apodo = "Matias"})
        orquestador.PartidaActual.Unirse(New Jugador() With {.Id = 2, .Apodo = "Rival"})

        orquestador.PartidaActual.Comenzar()
        '**************************************************

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain())
    End Sub
End Module
