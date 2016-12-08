Imports System.ComponentModel

Public Class VisorCartaSeleccionable

    <Description("Devuelve o establece si se muestra resaltado como parte de una selección"), Category("Focus"), DefaultValue(False)>
    Public Property EstaSeleccionada As Boolean
        Get
            Return Me.BorderStyle = BorderStyle.Fixed3D
        End Get
        Set(value As Boolean)
            If value Then
                Me.BorderStyle = BorderStyle.Fixed3D
            Else
                Me.BorderStyle = BorderStyle.None
            End If
        End Set
    End Property

    Protected Overrides Sub VisorCarta_MouseDown(sender As Object, e As MouseEventArgs)
        If (ModifierKeys And Keys.Control) = Keys.Control Then
            Me.EstaSeleccionada = Not Me.EstaSeleccionada
        Else 'Sin la tecla Ctrl, respesta al control base
            MyBase.VisorCarta_MouseDown(sender, e)
        End If
    End Sub
End Class
