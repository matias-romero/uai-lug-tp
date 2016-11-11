﻿Imports Chinchon.Entities

''' <summary>
''' Una ronda representa una vuelta completa por todos los jugadores de la partida
''' </summary>
Public Class Ronda
    Public Event CambioTurno As EventHandler

    Private _turnoActual As Integer
    Private ReadOnly _turnosJugados As New List(Of Turno)
    Private ReadOnly _jugadoresActivos As ManoPorJugador()
   
    Friend Sub New(jugadoresActivos As IEnumerable(Of ManoPorJugador))
        _turnoActual = -1
        'Copio los jugadores activos en cada ronda ya que es posible que algunos vayan quedando descalificados
        _jugadoresActivos = jugadoresActivos.ToArray()
    End Sub

    Public ReadOnly Property TurnoActual As Turno
        Get
            Return _turnosJugados(_turnoActual)
        End Get
    End Property

    Public Sub AvanzarTurno()
        _turnoActual += 1
        Dim indiceJugadorActual As Integer = Me.IndiceJugadorActual()
        Dim jugadorActual As Jugador = _jugadoresActivos(indiceJugadorActual).Jugador
        Dim manoActual As Mano = _jugadoresActivos(indiceJugadorActual).Mano

        Dim turno  = New Turno(jugadorActual, manoActual)
        AddHandler turno.TurnoFinalizado, AddressOf Me.NotificarQueFinalizoElTurno
        _turnosJugados.Add(turno)
    End Sub

    Private Sub NotificarQueFinalizoElTurno(sender As Object, e As EventArgs)
        Call Me.AvanzarTurno()
        RaiseEvent CambioTurno(Me, e)
    End Sub

    ''' <summary>
    ''' El jugador cierra la partida, validando las combinaciones armadas para calcular puntaje
    ''' </summary>
    ''' <param name="jugador">Jugador que realiza el cierre</param>
    ''' ''' <param name="carta">Carta utilizada para el cierre</param>
    Public Sub Cerrar(jugador As Jugador, carta As Carta)
        'TODO
    End Sub

    ''' <summary>
    ''' Devuelve el indice del jugador que tiene habilitado el turno
    ''' </summary>
    Private Function IndiceJugadorActual() As Integer

        Return _turnoActual Mod _jugadoresActivos.Count()
    End Function
End Class
