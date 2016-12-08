Imports Chinchon.Combinaciones
Imports Chinchon.Entities

Public Class VisorCombinacion
    Private _combinacion As Combinacion

    Public Event CombinacionDescartada As EventHandler
    Public Event NuevaCartaDetectada As EventoConCartaRelacionada

    Public Property CombinacionEnlazada As Combinacion
        Get
            Return _combinacion
        End Get
        Set(value As Combinacion)
            _combinacion = value
            If _combinacion IsNot Nothing Then
                Me.grupoContenedor.Text = _combinacion.ToString()
            End If
        End Set
    End Property

    Public Sub Enlazar(unaCombinacion As Combinacion)
        If Me.CombinacionEnlazada IsNot Nothing Then
            RemoveHandler Me.CombinacionEnlazada.ColeccionModificada, AddressOf Me.OnCombinacionModificadaHandler
        End If

        Me.CombinacionEnlazada = unaCombinacion
        AddHandler Me.CombinacionEnlazada.ColeccionModificada, AddressOf Me.OnCombinacionModificadaHandler
    End Sub

    Private Sub OnCombinacionModificadaHandler(sender As Object, e As EventArgs)
        Dim combinacion As Combinacion = DirectCast(sender, Combinacion)
        Call Me.DibujarCartasCombinadas(combinacion)
        Call Me.ValidarCombinacion(combinacion)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        RaiseEvent CombinacionDescartada(Me, EventArgs.Empty)
    End Sub

    Private Sub flowPanel_DragDrop(sender As Object, e As DragEventArgs) Handles flowPanel.DragDrop
        Dim origen As Control = VisorCarta.GetOrigenDragDrop(e)
        Dim cartaSoltada As Carta = DirectCast(origen, VisorCarta).Carta
        RaiseEvent NuevaCartaDetectada(Me, New AccionConCartaRelacionadaEventArgs(cartaSoltada))
    End Sub

    Private Sub flowPanel_DragEnter(sender As Object, e As DragEventArgs) Handles flowPanel.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    'Pinta el color de fondo de acuerdo a la validez de la combinación indicada
    Private Sub ValidarCombinacion(combinacion As Combinacion)
        me.flowPanel.BackColor = IIF(combinacion.EsValida(), Color.DarkSeaGreen, Color.Red)
    End Sub

    'Redibuja las cartas que se encuentran combinadas
    Private Sub DibujarCartasCombinadas(combinacion As Combinacion)
        Call Me.SuspendLayout()

        'Primero debo liberar todos los recursos gráficos ya renderizados por Windows
        Dim controlesDibujados As New List(Of Control)(Me.flowPanel.Controls.Cast(Of Control)())
        Call Me.flowPanel.Controls.Clear()
        For Each controlDibujado As Control In controlesDibujados
            Call controlDibujado.Dispose()
        Next
        
        'Ahora dibujo cada una de las cartas en la combinacion
        Dim anchoPromedio as Integer =  ME.flowPanel.Width / 7
        For Each carta As Object In combinacion.Cartas
            Dim nuevoVisor As New VisorCarta()
            nuevoVisor.Size = new Size(anchoPromedio, 200)
            nuevoVisor.Carta = carta
            nuevoVisor.MostrarCarta = true

            me.flowPanel.Controls.Add(nuevoVisor)
        Next

        Call Me.ResumeLayout(True)
    End Sub
End Class
