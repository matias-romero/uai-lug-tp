Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports Chinchon
Imports Chinchon.Combinaciones
Imports Chinchon.Entities

Public Class frmPresentarCombinaciones
    Private ReadOnly _cartasSinCombinar As ObservableCollection(Of Carta)

    Public Sub New(cartas As IEnumerable(Of Carta))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = My.Resources.Titulo_PresentarCombinaciones

        _cartasSinCombinar = New ObservableCollection(Of Carta)(cartas)
        AddHandler _cartasSinCombinar.CollectionChanged, AddressOf Me.ColeccionCartasSinCombinarModificada

        Call Me.VistaDeLaMano.Init(_cartasSinCombinar)
    End Sub

    ''' <summary>
    ''' Devuelve todas las combinaciones válidas preparadas por el jugador
    ''' </summary>
    Public ReadOnly Property CombinacionesPreparadas As IEnumerable(Of Combinacion)
        Get
            Return Me.ObtenerCombinacionesPreparadas().Where(Function(c) c.EsValida())
        End Get
    End Property

    Private Iterator Function ObtenerCombinacionesPreparadas() As IEnumerable(Of Combinacion)
        For Each control As VisorCombinacion In tablePanel.Controls
            Yield control.CombinacionEnlazada
        Next
    End Function

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
        Dim cartaComodin As CartaComodin = TryCast(e.Carta, CartaComodin)
        If cartaComodin IsNot Nothing Then
            Using formularioAsignarValorComodin As New frmAsignarValorComodin()
                formularioAsignarValorComodin.NumeroSeleccionado = cartaComodin.NumeroAsignadoPorUsuario
                formularioAsignarValorComodin.PaloSeleccionado = cartaComodin.PaloAsignadoPorUsuario
                If formularioAsignarValorComodin.ShowDialog(Me) = DialogResult.OK Then
                    'TODO: Llamar a la accion de asignarvalor
                    cartaComodin.PaloAsignadoPorUsuario = formularioAsignarValorComodin.PaloSeleccionado
                    cartaComodin.NumeroAsignadoPorUsuario = formularioAsignarValorComodin.NumeroSeleccionado

                End If

            End Using

        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        'Analizo que todas las combinaciones sean validas a fin de dejarlo salir
        Dim combinacionesRegistradas As Combinacion() = Me.ObtenerCombinacionesPreparadas().ToArray()
        If combinacionesRegistradas.All(Function(c) c.EsValida()) Then
            Me.DialogResult = DialogResult.OK
            Call Me.Hide()
        Else
            'Informo que debe preparar combinaciones válidas para seguir
            Messagebox.Show(Me, "Por favor revise que no queden combinaciones inválidas para continuar")
        End If
    End Sub

    ''' <summary>
    ''' Muestra un Pop-Up ofreciendo al jugador que prepare un listado de combinaciones posibles para armar la jugada
    ''' </summary>
    ''' <param name="contenedor">Formulario contenedor del dialogo modal</param>
    ''' <param name="mano">Mano del jugador</param>
    ''' <returns>Retorna el listado de combinaciones válidas preparadas</returns>
    Public Shared Function CombinarCartasEnMano(contenedor As Form, mano As Mano) As Combinacion()
        Dim combinaciones As New List(Of Combinacion)()
        Using formulario As New frmPresentarCombinaciones(mano.Cartas)
            If formulario.ShowDialog(contenedor) = DialogResult.OK Then
                combinaciones.AddRange(formulario.CombinacionesPreparadas)
            End If

            formulario.Close()
        End Using

        Return combinaciones.ToArray()
    End Function

End Class