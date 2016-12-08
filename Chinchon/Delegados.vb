Public Class MensajeSistemaEventArgs
    Private ReadOnly _mensaje As String
    Private ReadOnly _sugerencia As String

    Public Sub New(mensaje As String, sugerencia As String)
        _mensaje = mensaje
        _sugerencia = sugerencia
    End Sub

    Public ReadOnly Property Mensaje As String
        Get
            Return _mensaje
        End Get
    End Property

    Public ReadOnly Property Sugerencia As String
        Get
            Return _sugerencia
        End Get
    End Property

End Class

Public Delegate Sub NotificacionConMensajeEventHandler(sender As Object, e As MensajeSistemaEventArgs)