Imports System.Runtime.CompilerServices
Imports Chinchon.Entities

Public Module PartidaExtensions

    ''' <summary>
    ''' Comienza una partida directamente con los dos jugadores indicados
    ''' </summary>
    <Extension()>
    Public Sub Comenzar(unaPartida As Partida, jugadorUno As Jugador, jugadorDos As Jugador)  
        unaPartida.Unirse(jugadorUno)
        unaPartida.Unirse(jugadorDos)
        unaPartida.Comenzar()
    End Sub
End Module
