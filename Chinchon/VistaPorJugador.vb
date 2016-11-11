Imports Chinchon.Acciones
Imports Chinchon.Entities

''' <summary>
''' Actúa como un Model-View-Presenter ocupandose de la perspectiva de la partida según un jugador en particular
''' </summary>
Public Class VistaPorJugador
    Public Event CambioEstadoPartida As EventHandler
    Public Event ComenzoMiTurno As EventHandler
    Public Event FinalizoMiTurno As EventHandler

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

    #Region "Defino las acciones soportadas por el jugador"
    public sub TomarCartaDesdeElMonton()
        Dim accion As IAccion = new TomarCartaDesdeElMonton(_partidaEnCurso)
        Call Me.RegistrarAccionDelJugador(accion)
    End sub

    public sub TomarCartaDesdeElMazo()
        Dim accion As IAccion = new TomarCartaDesdeLaBaraja(_partidaEnCurso)
        Call Me.RegistrarAccionDelJugador(accion)
    End sub

    public sub DescartarCarta(carta As Carta)
        Dim accion As IAccion = new PonerCartaEnElMonton(_partidaEnCurso, carta)
        Call Me.RegistrarAccionDelJugador(accion)
    End sub

    public sub CerrarRonda(cartaDeCierre As Carta)
        Dim accion As IAccion = new CerrarRonda(_partidaEnCurso, cartaDeCierre)
        Call Me.RegistrarAccionDelJugador(accion)
    End sub

    Private sub RegistrarAccionDelJugador(accion As IAccion)
        accion.Ejecutar()
        'TODO: Guardarlas en el registro de la partida
    End sub
    #End Region
End Class
