Imports Chinchon.Combinaciones

Public Class VisorCombinacion
    Private _combinacion As Combinacion

    Public Event CombinacionDescartada as EventHandler

    Public Property CombinacionEnlazada As Combinacion
        Get
            Return _combinacion
        End Get
        Set(value As Combinacion)
            _combinacion = value
            If _combinacion isnot Nothing then
                me.grupoContenedor.Text = _combinacion.ToString()
            End If
        End Set
    End Property

    Public Sub Enlazar(unaCombinacion As Combinacion)
        Me.CombinacionEnlazada = unaCombinacion
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        RaiseEvent CombinacionDescartada(me, EventArgs.Empty)
    End Sub
End Class
