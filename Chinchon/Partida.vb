﻿Imports Chinchon.Entities
Imports Chinchon.Exceptions

Public Class Partida
    Public Event PartidaListaParaEmpezar As EventHandler
    Public Event EmpiezaNuevaRonda As EventHandler
    Public Event EmpiezaNuevoTurno As EventHandler

    Private Const MinimoNumeroJugadoresRequeridos As Integer = 2
    Private Const MaximoNumeroDeJugadoresPermitidos As Integer = 4

    Private ReadOnly _id As Guid
    Private ReadOnly _mazo As Baraja
    Private ReadOnly _monton As Monton
    Private ReadOnly _rondas As New List(Of Ronda)
    Private ReadOnly _jugadores As New List(Of ManoPorJugador)

    Public Sub New()
        Me.New(Guid.NewGuid(), New Baraja(), New Monton())
    End Sub

    Public Sub New(id As Guid, mazo As Baraja, monton As Monton)
        _id = id
        _mazo = mazo
        _monton = monton

        Me.PuntajeLimite = 100
    End Sub

    ''' <summary>
    ''' Devuelve el identificador de la partida
    ''' </summary>
    Public ReadOnly Property Id As Guid
        Get
            Return _id
        End Get
    End Property

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

    Public ReadOnly Property Monton As IMonton
        Get
            Return _monton
        End Get
    End Property

    Public ReadOnly Property Mazo As IBaraja
        Get
            Return _mazo
        End Get
    End Property

    Public ReadOnly Property TurnoEnCurso As Turno
        Get
            Return Me.RondaActual.TurnoActual
        End Get
    End Property

    Friend ReadOnly Property RondaActual As Ronda
        Get
            Return _rondas.Last()
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
            manoPorJugador.Mano = New Mano(_mazo.TomarCartas(7))
        Next

        Me.NuevaRonda()
    End Sub

    ''' <summary>
    ''' Crea una nueva ronda notificando que cambio el turno
    ''' </summary>
    Public Function NuevaRonda() As Ronda
        Dim ronda As Ronda = New Ronda(_jugadores)
        ronda.AvanzarTurno() 'Inicio el primer turno de la ronda
        _rondas.Add(ronda)

        AddHandler ronda.CambioTurno, AddressOf Me.NotificarQueCambioElTurno
        RaiseEvent EmpiezaNuevaRonda(ronda, EventArgs.Empty)

        Return ronda
    End Function

    Private Sub NotificarQueCambioElTurno(sender As Object, e As EventArgs)
        RaiseEvent EmpiezaNuevoTurno(Me, e)
    End Sub

    ''' <summary>
    ''' Obtengo el presentador enlazado con el jugador indicado
    ''' </summary>
    ''' <param name="jugador">Un jugador de la partida</param>
    ''' <returns>Retorna la visión de la partida desde el punto de vista de ese jugador</returns>
    Public Function VerComo(jugador As Jugador) As VistaPorJugador
        Return New VistaPorJugador(Me, jugador, Me.ObtenerManoDelJugador(jugador))
    End Function

    ''' <summary>
    ''' Devuelve la mano asignada para ese jugador
    ''' </summary>
    ''' <param name="jugador">Jugador de la partida</param>
    Private Function ObtenerManoDelJugador(jugador As Jugador) As Mano
        Dim manoPorJugador As ManoPorJugador = _jugadores.Single(Function(mpj) mpj.Jugador.Equals(jugador))
        Return manoPorJugador.Mano
    End Function

    Private ReadOnly Property PuedoComenzarPartida As Boolean
        Get
            Return _jugadores.Count >= MinimoNumeroJugadoresRequeridos
        End Get
    End Property

    Private Sub OnPartidaListaParaEmpezar()
        RaiseEvent PartidaListaParaEmpezar(Me, EventArgs.Empty)
    End Sub
End Class
