Public Class Notificador
    Private _momentoEmpiezaParpadeo As Date

    Public Sub Notificar(msg As String, suggest As String)
        Me.Mensaje = msg
        Me.Sugerencia = suggest
        Call Me.Blink()
    End Sub

    Public Property Mensaje As String
        Get
            Return Me.lblMensaje.Text
        End Get
        Set(value As String)
            Me.lblMensaje.Text = value
        End Set
    End Property

    Public Property Sugerencia As String
        Get
            Return Me.lblSugerencia.Text
        End Get
        Set(value As String)
            Me.lblSugerencia.Text = value
        End Set
    End Property

    Public Sub Blink()
        _momentoEmpiezaParpadeo = DateTime.Now
        timerAnimacion.Start()
    End Sub

    public sub Clear()
        timerAnimacion.Stop()
        Me.Mensaje = String.Empty
        Me.Sugerencia = String.Empty
    End sub

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        If (DateTime.Now - _momentoEmpiezaParpadeo).Seconds > 3 Then
            Me.Clear()
            Return
        End If

        'Simplemente cambio el color de la fuente para jugar un poco
        Dim control As Control = Me.lblMensaje
        Dim color As Color = IIf(control.ForeColor = Control.DefaultForeColor, Color.DarkRed, Control.DefaultForeColor)
        control.ForeColor = color
    End Sub
End Class
