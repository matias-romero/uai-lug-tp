Namespace Acciones

    Public Class TraductorDeAcciones
        Public Function DeterminarAccion() As IAccion

        End Function

        Private Function AccionDePonerCartaEnElMonton() As IAccion
            Return New PonerCartaEnElMonton()
        End Function
    End Class
End Namespace