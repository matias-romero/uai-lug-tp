Namespace Exceptions
    ''' <summary>
    ''' Lanzada cuando el jugador trata de realizar un movimiento no permitido para el estado actual de la partida
    ''' </summary>
    Public Class AccionNoPermitidaException
        Inherits Exception

        Public Sub New(mensaje As String)
            Me.New(mensaje, string.Empty)
        End Sub

        Public Sub New(mensaje As String, sugerencia As String)
            MyBase.New(mensaje)
            Me.Sugerencia = sugerencia
        End Sub

        Public Property Sugerencia As String
    End Class
End NameSpace