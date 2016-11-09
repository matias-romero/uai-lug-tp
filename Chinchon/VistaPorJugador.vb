Imports Chinchon.Entities

Public Class VistaPorJugador
    Public Event CambioEstadoPartida As EventHandler
    Public Event ComenzoMiTurno As EventHandler
    Public Event FinalizoMiTurno As EventHandler

    Private ReadOnly _jugador As Jugador
    Private ReadOnly _partidaEnCurso As Partida

    Public Sub New(partidaEnCurso As Partida, jugador As Jugador)
        _partidaEnCurso = partidaEnCurso
        AddHandler _partidaEnCurso.EmpiezaNuevoTurno, AddressOf CambioTurnoActual

        _jugador = jugador
    End Sub

    ''' <summary>
    ''' Devuelve verdadero si es el turno del jugador que modelo la vista
    ''' </summary>
    Public ReadOnly Property EsMiTurno As Boolean
        Get
            Return _partidaEnCurso.TurnoEnCurso.Jugador.Equals(_jugador)
        End Get
    End Property

    Public ReadOnly Property Jugador As Jugador
        Get
            Return _jugador
        End Get
    End Property

    Public ReadOnly Property Mano As Mano
        Get
            Return _partidaEnCurso.TurnoEnCurso.Mano
        End Get
    End Property

    Public ReadOnly Property CartaVisibleMonton As Carta
        Get
            Return _partidaEnCurso.Monton.Cara
        End Get
    End Property

    Private Sub CambioTurnoActual(sender As Object, e As EventArgs)
        If Me.EsMiTurno Then
            RaiseEvent ComenzoMiTurno(Me, EventArgs.Empty)
        Else
            RaiseEvent FinalizoMiTurno(Me, EventArgs.Empty)
        End If

        Call Me.OnCambioEstadoPartida()
    End Sub

    Private Sub OnCambioEstadoPartida()
        RaiseEvent CambioEstadoPartida(Me, EventArgs.Empty)
    End Sub
End Class
