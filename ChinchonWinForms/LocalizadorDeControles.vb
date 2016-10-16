''' <summary>
''' Ofrece utilidades propias de WindowsForms para obtener referencias a los controles unívocamente
''' </summary>
Public Class LocalizadorDeControles
    ''' <summary>
    ''' Obtiene un identificador unívoco para el control indicado
    ''' </summary>
    ''' <param name="unControl">Control cuyo nombre se quiere resolver</param>
    ''' <returns>Devuelve una cadena de texto que representa una forma única para referenciar al control</returns>
    Public Shared Function ResolveFullyQualifiedName(unControl As Control) As String
        Dim nestedNamesStack As New Stack(Of String)
        nestedNamesStack.Push(unControl.Name)

        Dim contenedorPadre As Control = unControl.Parent
        While contenedorPadre IsNot Nothing
            Dim frm As Form = TryCast(contenedorPadre, Form) 'Los Form a su vez son Controles
            If frm IsNot Nothing Then
                'Corto el algoritmo si alcance al Formulario Contenedor registrando su nombre
                nestedNamesStack.Push(frm.Name)
                contenedorPadre = Nothing
            Else
                Dim ctl As Control = contenedorPadre
                If ctl IsNot Nothing Then
                    nestedNamesStack.Push(ctl.Name)
                    contenedorPadre = ctl.Parent
                End If
            End If
        End While

        Return String.Join(".", nestedNamesStack.ToArray())
    End Function

    ''' <summary>
    ''' Devuelve el control unívocamente referenciado por ese nombre
    ''' </summary>
    ''' <param name="fullyQualifiedName">Nombre unívoco del control que desea buscar</param>
    ''' <returns>Retorna el control correspondiente</returns>
    Public Shared Function RecoverOriginalControl(fullyQualifiedName As String) As Control
        Dim nameSlices As String() = fullyQualifiedName.Split(".")
        Dim formName As String = nameSlices(0) 'El primero siempre es el nombre del form
        Dim ctl As Control = FindFormByName(formName) 'Todos los Form son controles
        For Each nameSlice As String In nameSlices.Skip(1) 'Evito 
            ctl = ctl.Controls.Item(nameSlice)
            If ctl Is Nothing Then Return Nothing
        Next
        Return ctl
    End Function

    'Busco el formulario entre todos los formularios instanciados en la aplicación
    Private Shared Function FindFormByName(formName As String) As Form
        Return Application.OpenForms.OfType(Of Form).SingleOrDefault(Function(f) String.Equals(formName, f.Name))
    End Function
End Class
