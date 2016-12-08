Namespace Exceptions
    Public Class ApodoJugadorExistenteException
        Inherits Exception

        Public Sub New(apodo As String)
            MyBase.New(String.Format("El apodo '{0}' se encuentra utilizado por otro jugador.", apodo))
        End Sub
    End Class
End NameSpace