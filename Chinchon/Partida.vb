Imports Chinchon.Exceptions

Public Class Partida
    Public Event PartidaListaParaEmpezar As EventHandler

    Private Const MinimoNumeroJugadoresRequeridos As Integer = 2
    Private Const MaximoNumeroDeJugadoresPermitidos As Integer = 4

    Private ReadOnly _mazo As New Baraja()
    Private ReadOnly _monton As New Monton()
    Private ReadOnly _rondas As New List(Of Ronda)
    Private ReadOnly _jugadores As New List(Of ManoPorJugador)

    ''' <summary>
    ''' Devuelve o establece el identificador de la partida
    ''' </summary>
    Public Property Id As Guid

    ''' <summary>
    ''' Devuelve o establece el puntaje limite definido para quedarse dentro de la partida
    ''' </summary>
    Public Property PuntajeLimite As Integer

    'Solo permito enumerar los jugadores registrados en la partida
    Public ReadOnly Property Jugadores As IEnumerable(Of Jugador)
        Get
            Return _jugadores.Select(Function(mpj) mpj.Jugador)
        End Get
    End Property

    ''' <summary>
    ''' Permite que un jugador se una a la partida
    ''' </summary>
    ''' <param name="nuevoJugador">Nuevo jugador</param>
    Public Sub Unirse(nuevoJugador As Jugador)
        'Valido que no supere el máximo de jugadores permitidos por partida
        If _jugadores.Count >= MaximoNumeroDeJugadoresPermitidos Then
            Throw New LimiteJugadoresPorAlcanzadoException()
        End If

        Dim nuevaManoPorJugador As New ManoPorJugador(nuevoJugador)
        _jugadores.Add(nuevaManoPorJugador)

        'Notifico si la partida ya puede comenzar
        If Me.PuedoComenzarPartida Then
            Me.OnPartidaListaParaEmpezar()
        End If
    End Sub

    ''' <summary>
    ''' Comienza una nueva partida desde que se reparten las cartas
    ''' </summary>
    Public Sub Comenzar()
        If Not Me.PuedoComenzarPartida Then
            Throw New InvalidOperationException("Se necesitan al menos dos jugadores para comenzar una partida")
        End If

        'Mezclo el mazo y reparto la mano de cada jugador
        _mazo.Barajar()
        For Each manoPorJugador In _jugadores
            manoPorJugador.Mano = New Mano(Nothing)
        Next
    End Sub

    Public Function NuevaRonda() As Ronda
        Return New Ronda(Me.Jugadores)
    End Function

    ''' <summary>
    ''' El jugador cierra la partida, validando las combinaciones armadas para calcular puntaje
    ''' </summary>
    ''' <param name="jugador">Jugador que realiza el cierre</param>
    ''' ''' <param name="carta">Carta utilizada para el cierre</param>
    Public Sub Cerrar(jugador As Jugador, carta As Carta)
        'TODO
    End Sub

    Private ReadOnly Property PuedoComenzarPartida As Boolean
        Get
            Return _jugadores.Count >= MinimoNumeroJugadoresRequeridos
        End Get
    End Property

    Private Sub OnPartidaListaParaEmpezar()
        RaiseEvent PartidaListaParaEmpezar(Me, EventArgs.Empty)
    End Sub
End Class
