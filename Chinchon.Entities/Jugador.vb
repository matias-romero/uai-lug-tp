''' <summary>
''' Modela a un jugador ofreciendo una identidad clara durante los juegos
''' </summary>
Public Class Jugador
    Private ReadOnly _participacionesEnPartidas as New List(Of ParticipacionJugadorEnPartida)

    Public Property Id As Integer

    Public Property Apodo As String

    Public ReadOnly Property ParticipacionesRegistradasEnPartidas As List(Of ParticipacionJugadorEnPartida)
        Get
            Return _participacionesEnPartidas
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.Apodo
    End Function
End Class
