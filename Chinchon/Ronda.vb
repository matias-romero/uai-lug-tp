﻿Imports Chinchon.Entities

''' <summary>
''' Una ronda representa una vuelta completa por todos los jugadores de la partida
''' </summary>
Public Class Ronda
    Public Event CambioTurno As EventHandler
    Public Event RondaFinalizada As EventHandler

    Private _turnoActual As Integer
    Private ReadOnly _numero As Integer
    Private ReadOnly _turnosJugados As New List(Of Turno)
    Private ReadOnly _jugadoresActivos As ManoPorJugador()

    Friend Sub New(numero As Integer, jugadoresActivos As IEnumerable(Of ManoPorJugador))
        _numero = numero
        _turnoActual = -1

        'Copio los jugadores activos en cada ronda ya que es posible que algunos vayan quedando descalificados
        _jugadoresActivos = jugadoresActivos.ToArray()
    End Sub

    ''' <summary>
    ''' Devuelve el numero de la ronda
    ''' </summary>
    Public ReadOnly Property Numero As Integer
        Get
            Return _numero
        End Get
    End Property

    Public ReadOnly Property TurnoActual As Turno
        Get
            Return _turnosJugados(_turnoActual)
        End Get
    End Property

    Friend Sub AvanzarTurno()
        Call Me.ComprobarRondaFinalizada()

        _turnoActual += 1
        Dim indiceJugadorActual As Integer = Me.IndiceJugadorActual()
        Dim jugadorActual As Jugador = _jugadoresActivos(indiceJugadorActual).Jugador
        Dim manoActual As Mano = _jugadoresActivos(indiceJugadorActual).Mano

        Dim turno = New Turno(jugadorActual, manoActual)
        AddHandler turno.TurnoFinalizado, AddressOf Me.NotificarQueFinalizoElTurno

        _turnosJugados.Add(turno)
    End Sub

    Protected Sub ComprobarRondaFinalizada()
        'La ronda finaliza cuando todos los jugadores tuvieron su turno o alguno realizó un cierre
        If _turnosJugados.Any() Then
            If  _turnosJugados.Count = _jugadoresActivos.Length OrElse Me.TurnoActual.RealizoUnCierre Then
                Call Me.NotificarRondaFinalizada()

            End If
        End If
    End Sub

    ''' <summary>
    ''' Devuelve el indice del jugador que tiene habilitado el turno
    ''' </summary>
    Private Function IndiceJugadorActual() As Integer
        Return _turnoActual Mod _jugadoresActivos.Count()
    End Function

    Private Sub NotificarQueFinalizoElTurno(sender As Object, e As EventArgs)
        Call Me.AvanzarTurno()
        RaiseEvent CambioTurno(Me, e)
    End Sub

    Private Sub NotificarRondaFinalizada()
        RaiseEvent RondaFinalizada(Me, EventArgs.Empty)
    End Sub
End Class
