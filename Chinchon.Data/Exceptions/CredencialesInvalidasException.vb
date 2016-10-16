Namespace Exceptions
    Public Class CredencialesInvalidasException
        Inherits Exception

        Public Sub New()
            MyBase.New("El apodo o la contraseña indicada no coinciden con nuestros registros")
        End Sub
    End Class
End Namespace