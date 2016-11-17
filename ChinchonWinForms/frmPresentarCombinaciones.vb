Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports Chinchon
Imports Chinchon.Combinaciones
Imports Chinchon.Entities

Public Class frmPresentarCombinaciones
    Private ReadOnly _cartasSinCombinar As ObservableCollection(Of Carta)

    Public Sub New(mano As Mano)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = My.Resources.Titulo_PresentarCombinaciones

        _cartasSinCombinar = New ObservableCollection(Of Carta)(mano.Cartas)
        AddHandler _cartasSinCombinar.CollectionChanged, AddressOf Me.ColeccionCartasSinCombinarModificada
        Call Me.VistaDeLaMano.Init(_cartasSinCombinar)
    End Sub

    Private Sub ColeccionCartasSinCombinarModificada(sender As Object, e As NotifyCollectionChangedEventArgs)
        Call Me.VistaDeLaMano.Init(_cartasSinCombinar)
    End Sub

    Private Sub btnNuevoChinchon_Click(sender As Object, e As EventArgs) Handles btnNuevoChinchon.Click
        Call Me.PrepararNuevaCombinacion(New Combinaciones.Chinchon())
    End Sub

    Private Sub btnNuevaEscalera_Click(sender As Object, e As EventArgs) Handles btnNuevaEscalera.Click
        Call Me.PrepararNuevaCombinacion(New Combinaciones.Escalera())
    End Sub

    Private Sub btnNuevoPie_Click(sender As Object, e As EventArgs) Handles btnNuevoPie.Click
        Call Me.PrepararNuevaCombinacion(New Combinaciones.Pie())
    End Sub

    'Creo dinámicamente un nuevo control para armar la combinación solicitada
    Private Sub PrepararNuevaCombinacion(nuevaCombinacion As Combinacion)
        Dim nuevoControl As New VisorCombinacion()
        nuevoControl.Enlazar(nuevaCombinacion)
        nuevoControl.Dock = DockStyle.Fill

        AddHandler nuevoControl.NuevaCartaDetectada, AddressOf Me.OnNuevaCartaDectectadaHandler
        AddHandler nuevoControl.CombinacionDescartada, AddressOf Me.OnCombinacionDescartada

        tablePanel.Controls.Add(nuevoControl)
    End Sub

    Private Sub OnCombinacionDescartada(sender As Object, e As EventArgs)
        Dim visorDestino As VisorCombinacion = DirectCast(sender, VisorCombinacion)
        'Devuelvo cada carta de la combinación descartada al listado inicial
        Dim combinacionPorDescartar = visorDestino.CombinacionEnlazada
        For Each cartaDescartada As Object In combinacionPorDescartar.Cartas
            _cartasSinCombinar.Add(cartaDescartada)
        Next

        'Elimino el panel de combinación visual
        tablePanel.Controls.Remove(visorDestino)
        visorDestino.Dispose()
    End Sub

    Private Sub OnNuevaCartaDectectadaHandler(sender As Object, e As AccionConCartaRelacionadaEventArgs)
        Dim cartaIntercambio As Carta = e.Carta
        Dim visorDestino As VisorCombinacion = DirectCast(sender, VisorCombinacion)
        
        'Remuevo la carta arrastrada de la mano original y la agrego en la combinación elegida
        _cartasSinCombinar.Remove(cartaIntercambio)
        visorDestino.CombinacionEnlazada.AgregarCarta(cartaIntercambio)
    End Sub

    Private Sub VistaDeLaMano_DobleClickSobreCartaDetectado(sender As Object, e As AccionConCartaRelacionadaEventArgs) Handles VistaDeLaMano.DobleClickSobreCartaDetectado
        'Solo me interesan los comodines a los que pueden asignarles un valor
        dim cartaComodin As CartaComodin = TryCast(e.Carta, CartaComodin)
        if cartaComodin IsNot Nothing Then
            Using formularioAsignarValorComodin As New frmAsignarValorComodin()
                formularioAsignarValorComodin.NumeroSeleccionado = cartaComodin.NumeroAsignadoPorUsuario
                formularioAsignarValorComodin.PaloSeleccionado = cartaComodin.PaloAsignadoPorUsuario
                If formularioAsignarValorComodin.ShowDialog(me) = DialogResult.OK Then
                    'TODO: Llamar a la accion de asignarvalor
                    cartaComodin.PaloAsignadoPorUsuario = formularioAsignarValorComodin.PaloSeleccionado
                    cartaComodin.NumeroAsignadoPorUsuario = formularioAsignarValorComodin.NumeroSeleccionado

                End If

            End Using

        End If
    End Sub
End Class