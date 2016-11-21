Imports Chinchon.Entities
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
    Private ReadOnly _jugadoresActivos As New List(Of ManoPorJugador)
    Private ReadOnly _jugadoresRegistrados As New List(Of ManoPorJugador)

    Public Sub New()
        Me.New(Guid.NewGuid(), New Baraja())
    End Sub

    Public Sub New(id As Guid, mazo As Baraja)
        Me.New(id, mazo, New Monton())
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

    ''' <summary>
    ''' Enumera los jugadores que siguen jugando actualmente
    ''' </summary>
    Public ReadOnly Property JugadoresActivos As IEnumerable(Of Jugador)
        Get
            Return _jugadoresActivos.Select(Function(mpj) mpj.Jugador)
        End Get
    End Property

    ''' <summary>
    ''' Devuelve la referencia al montón utilizado en esta partida
    ''' </summary>
    Public ReadOnly Property Monton As IMonton
        Get
            Return _monton
        End Get
    End Property

    ''' <summary>
    ''' Devuelve la referencia al mazo utilizado en esta partida
    ''' </summary>
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
        If _jugadoresActivos.Count >= MaximoNumeroDeJugadoresPermitidos Then
            Throw New LimiteJugadoresPorAlcanzadoException()
        End If

        Dim nuevaManoPorJugador As New ManoPorJugador(nuevoJugador)
        _jugadoresActivos.Add(nuevaManoPorJugador)
        _jugadoresRegistrados.Add(nuevaManoPorJugador)

        'Notifico si la partida ya puede comenzar
        If Me.PuedoComenzarPartida Then
            Me.OnPartidaListaParaEmpezar()
        End If
    End Sub

    ''' <summary>
    ''' Registra que un jugador abandona la partida
    ''' </summary>
    ''' <param name="jugador">Jugador que abandona</param>
    Public Sub Abandonar(jugador As Jugador)
        'TODO: Computarle una derrota
        'Lo borro de los jugadores activos
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
        For Each manoPorJugador In _jugadoresActivos
            manoPorJugador.Mano = New Mano(_mazo.TomarCartas(7))
        Next

        Me.NuevaRonda()
    End Sub

    ''' <summary>
    ''' Crea una nueva ronda notificando que cambio el turno
    ''' </summary>
    Public Sub NuevaRonda()
        Dim numeroProximaRonda As Integer = _rondas.Count + 1
        Dim ronda As Ronda = New Ronda(numeroProximaRonda, _jugadoresActivos)
        AddHandler ronda.CambioTurno, AddressOf Me.NotificarQueCambioElTurno
        AddHandler ronda.RondaFinalizada, AddressOf Me.FinDeRondaDetectado
        _rondas.Add(ronda)

        ronda.AvanzarTurno() 'Inicio el primer turno de la ronda
        Call Me.NotificarQueComienzaUnaNuevaRonda(ronda)
    End Sub

    ''' <summary>
    ''' Crea una nueva ronda notificando que cambio el turno
    ''' </summary>
    Private Sub NuevaRondaDeCierre()
        Dim numeroProximaRonda As Integer = _rondas.Count + 1
        Dim ronda As Ronda = New RondaDeCierre(numeroProximaRonda, _jugadoresActivos)
        AddHandler ronda.CambioTurno, AddressOf Me.NotificarQueCambioElTurno
        AddHandler ronda.RondaFinalizada, AddressOf Me.FinDeRondaDetectado
        _rondas.Add(ronda)

        ronda.AvanzarTurno() 'Inicio el primer turno de la ronda
        Call Me.NotificarQueComienzaUnaNuevaRonda(ronda)
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
    ''' Devuelve el puntaje acumulado de un jugador en esta partida
    ''' </summary>
    ''' <param name="jugador">Jugador de la partida</param>
    Public Function ObtenerPuntajePorJugador(jugador As Jugador) As Integer
        Dim manoPorJugador As ManoPorJugador = _jugadoresActivos.Single(Function(mpj) mpj.Jugador.Equals(jugador))
        Return manoPorJugador.PuntajeAcumulado
    End Function

    ''' <summary>
    ''' Devuelve la mano asignada para ese jugador
    ''' </summary>
    ''' <param name="jugador">Jugador de la partida</param>
    Private Function ObtenerManoDelJugador(jugador As Jugador) As Mano
        Dim manoPorJugador As ManoPorJugador = _jugadoresActivos.Single(Function(mpj) mpj.Jugador.Equals(jugador))
        Return manoPorJugador.Mano
    End Function

    Private ReadOnly Property PuedoComenzarPartida As Boolean
        Get
            Return _jugadoresActivos.Count >= MinimoNumeroJugadoresRequeridos
        End Get
    End Property

    Private Sub OnPartidaListaParaEmpezar()
        RaiseEvent PartidaListaParaEmpezar(Me, EventArgs.Empty)
    End Sub

    Private Sub NotificarQueCambioElTurno(sender As Object, e As EventArgs)
        RaiseEvent EmpiezaNuevoTurno(Me, e)
    End Sub

    Private Sub NotificarQueComienzaUnaNuevaRonda(ronda As Ronda)
        RaiseEvent EmpiezaNuevaRonda(ronda, EventArgs.Empty)
    End Sub

    Private Sub FinDeRondaDetectado(sender As Object, e As EventArgs)
        Dim ronda As Ronda = DirectCast(sender, Ronda)
        If ronda.TurnoActual.RealizoUnCierre Then
            'TODO: Ver como pedir que muestren todos sus combinaciones y calculen los puntos
        Else
            'Si no hubo un cierre, sigo jugando otra ronda
            Call Me.NuevaRonda()
        End If
    End Sub
End Class
