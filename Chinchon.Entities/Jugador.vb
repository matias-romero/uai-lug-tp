''' <summary>
''' Modela a un jugador ofreciendo una identidad clara durante los juegos
''' </summary>
Public Class Jugador
    Private ReadOnly _participacionesEnPartidas As New List(Of ParticipacionJugadorEnPartida)

    Public Property Id As Integer

    Public Property Apodo As String

    Public ReadOnly Property ParticipacionesRegistradasEnPartidas As IList(Of ParticipacionJugadorEnPartida)
        Get
            Return _participacionesEnPartidas
        End Get
    End Property

    ''' <summary>
    ''' Devuelve el total de tiempo jugado
    ''' </summary>
    Public ReadOnly Property TotalTiempoJugado As TimeSpan
        Get
            Dim total As TimeSpan = TimeSpan.Zero
            For Each participacion In Me.ParticipacionesRegistradasEnPartidas
                total = total.Add(participacion.TiempoDeJuegoNeto)
            Next

            Return total
        End Get
    End Property

    ''' <summary>
    ''' Retorna el número de victorias obtenidas en las jugadas
    ''' </summary>
    Public ReadOnly Property TotalVictorias As Integer
        Get
            Return Me.ParticipacionesRegistradasEnPartidas.LongCount(Function(p) p.FueGanador)
        End Get
    End Property

    ''' <summary>
    ''' Retorna el número de derrotas obtenidas en las jugadas
    ''' </summary>
    Public ReadOnly Property TotalDerrotas As Integer
        Get
            Return Me.ParticipacionesRegistradasEnPartidas.LongCount(Function(p) Not p.FueGanador)
        End Get
    End Property

    ''' <summary>
    ''' Retorna el porcentaje con el promedio de victorias
    ''' </summary>
    Public ReadOnly Property PromedioVictorias As Integer
        Get
            Dim partidasJugadas As Double = Math.Max(Me.ParticipacionesRegistradasEnPartidas.Count, 1)
            Return Me.TotalVictorias * 100 / partidasJugadas
        End Get
    End Property

    Public Overrides Function GetHashCode() As Integer
        Return Me.Id.GetHashCode()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim other As Jugador = TryCast(obj, Jugador)
        If other Is Nothing Then
            Return False
        End If

        Return Object.ReferenceEquals(other, Me) OrElse other.Id.Equals(me.Id)
    End Function

    Public Overrides Function ToString() As String
        Return Me.Apodo
    End Function
End Class
