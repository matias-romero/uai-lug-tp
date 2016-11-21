Imports Chinchon.Acciones
Imports Chinchon.Entities
Imports Chinchon.Exceptions

''' <summary>
''' Actúa como un Model-View-Presenter ocupandose de la perspectiva de la partida según un jugador en particular
''' </summary>
Public Class VistaPorJugador
    Public Event ComenzoMiTurno As EventHandler
    Public Event FinalizoMiTurno As EventHandler
    Public Event CambioEstadoPartida As EventHandler
    Public Event MensajeEntranteDelSistema As NotificacionConMensajeEventHandler

    Private ReadOnly _mano As Mano
    Private ReadOnly _jugador As Jugador
    Private ReadOnly _partidaEnCurso As Partida

    Public Sub New(partidaEnCurso As Partida, jugador As Jugador, mano As Mano)
        _mano = mano
        _jugador = jugador
        _partidaEnCurso = partidaEnCurso

        AddHandler _partidaEnCurso.EmpiezaNuevoTurno, AddressOf CambioTurnoActual
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
            Return _mano
        End Get
    End Property

    Public ReadOnly Property PuntajeAcumulado As Integer
        Get
            Return _partidaEnCurso.ObtenerPuntajePorJugador(_jugador)
        End Get
    End Property

    Public ReadOnly Property CartaVisibleMonton As Carta
        Get
            Return _partidaEnCurso.Monton.Cara
        End Get
    End Property

    Public ReadOnly Property ProximaCartaDelMazo As Carta
        Get
            Return _partidaEnCurso.Mazo.ProximaCarta
        End Get
    End Property

    Public ReadOnly Property CantidadRivales As Integer
        Get
            Return _partidaEnCurso.JugadoresActivos.Count() - 1
        End Get
    End Property

    Public ReadOnly Property EstaCerradaLaRonda As Boolean
        Get
            Return TypeOf _partidaEnCurso.RondaActual Is RondaDeCierre
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

    Private Sub OnMensajeEntranteDelSistema(mensaje As String, sugerencia As String)
        RaiseEvent MensajeEntranteDelSistema(Me, New MensajeSistemaEventArgs(mensaje, sugerencia))
    End Sub

#Region "Defino las acciones soportadas por el jugador"
    Public Sub TomarCartaDesdeElMonton()
        Dim accion As IAccion = New TomarCartaDesdeElMonton(_partidaEnCurso)
        Call Me.RegistrarAccionDelJugador(accion)
    End Sub

    Public Sub TomarCartaDesdeElMazo()
        Dim accion As IAccion = New TomarCartaDesdeLaBaraja(_partidaEnCurso)
        Call Me.RegistrarAccionDelJugador(accion)
    End Sub

    Public Sub DescartarCarta(carta As Carta)
        Dim accion As IAccion = New PonerCartaEnElMonton(_partidaEnCurso, carta)
        Call Me.RegistrarAccionDelJugador(accion)
    End Sub

    Public Sub CerrarRonda(cartaDeCierre As Carta)
        Dim accion As IAccion = New CerrarRonda(_partidaEnCurso, cartaDeCierre)
        Call Me.RegistrarAccionDelJugador(accion)
    End Sub

    Public Sub ReordenarMano(cartaA As Carta, cartaB As Carta)
        Dim accion As IAccion = New CambiarPosicionCartaEnMano(_mano, cartaA, cartaB)
        Call Me.RegistrarAccionDelJugador(accion)

        Call Me.OnCambioEstadoPartida()
    End Sub

    Public Sub Abandonar()

    End Sub

    Private Sub RegistrarAccionDelJugador(accion As IAccion)
        Try
            accion.Ejecutar()
            'TODO: Guardarlas en el registro de la partida
        Catch ex As AccionNoPermitidaException
            Call Me.OnMensajeEntranteDelSistema(ex.Message, ex.Sugerencia)
        End Try
    End Sub
#End Region
End Class
