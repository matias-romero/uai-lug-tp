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

    ''' <summary>
    ''' Reordena la lista de jugadores empezando por en quien se centra, siguiendo el orden original
    ''' </summary>
    ''' <param name="jugadores">Listado de jugadores activos</param>
    ''' <param name="jugadorCentral">Jugador que se utilizara como centro para reordenar el listado</param>
    ''' <returns></returns>
    <Extension()>
    Friend Function ReordenarJugadoresActivosCentrandoEn(jugadores As IEnumerable(Of ManoPorJugador), jugadorCentral As Jugador) As IEnumerable(Of ManoPorJugador)
        Dim jugadoresActivos As ManoPorJugador() = jugadores.ToArray()
        Dim posicionCentral As Integer = Array.FindIndex(jugadoresActivos, Function(mpj) mpj.Jugador.Equals(jugadorCentral))
        If (posicionCentral.Equals(0)) Then
            Return jugadoresActivos 'Si ya está al principio, omito el trabajo extra
        End If

        Dim jugadoresAntes As IEnumerable(Of ManoPorJugador) = jugadoresActivos.Take(posicionCentral)
        Dim jugadoresDespues As IEnumerable(Of ManoPorJugador) = jugadoresActivos.Skip(posicionCentral + 1)
        Dim listadoOrdenado As New List(Of ManoPorJugador)(jugadoresActivos.Length)
        listadoOrdenado.Add(jugadores(posicionCentral))
        listadoOrdenado.AddRange(jugadoresDespues)
        listadoOrdenado.AddRange(jugadoresAntes)
        Return listadoOrdenado
    End Function
End Module
