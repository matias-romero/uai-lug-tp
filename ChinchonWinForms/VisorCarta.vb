Imports Chinchon.Entities
Imports System.ComponentModel

<DefaultBindingProperty("Carta")>
Public Class VisorCarta
    <Serializable()>
    Public Class DragDropData
        Public Property NombreControl As String
        Public Property RolAsociado As String
    End Class

    Public Event DobleClickDetectado As EventoConCartaRelacionada
    Public Event OperacionArrastreIniciada As EventoConCartaRelacionada
    Public Event OperacionDeSoltarCartaDetectada As EventoConMovimientoCartasAsociado

    Private _carta As Carta
    Private _cartaRenderizada As Image
    Private _mostrarCaraDeCarta As Boolean = True
    Private _habilitarComoFuenteDeArrastre As Boolean = False
    Private _rolAsignado As String = String.Empty

    <Description("Devuelve o establece si se ve la cara de la carta o su reverso"), Category("Data"), DefaultValue(True)>
    Public Property MostrarCarta As Boolean
        Get
            Return _mostrarCaraDeCarta
        End Get
        Set
            _mostrarCaraDeCarta = Value
            Call Me.RenderizarCarta()
        End Set
    End Property

    <Description("Devuelve o establece la carta a visualizar"), Category("Data")>
    Public Property Carta As Carta
        Get
            Return _carta
        End Get
        Set
            _carta = Value
            Call Me.RenderizarCarta()
        End Set
    End Property

    <Description("Devuelve o establece si el control permite tomar la carta para ser arrastrarda"), Category("Data"), DefaultValue(False)>
    Public Property HabilitarComoFuenteDeArrastre As Boolean
        Get
            Return _habilitarComoFuenteDeArrastre
        End Get
        Set
            _habilitarComoFuenteDeArrastre = Value
        End Set
    End Property

    <Description("Devuelve o establece si el control permite aceptar una carta arrastrada desde otro control"), Category("Data"), DefaultValue(False)>
    Public Property HabilitarComoDestinoDeArrastre As Boolean
        Get
            Return Me.AllowDrop
        End Get
        Set
            Me.AllowDrop = Value
        End Set
    End Property

    <Description("Devuelve o establece el rol asignado al control utilizado como referencia para las acciones de Drag&Drop"), Category("Data"), DefaultValue("")>
    Public Property RolAsignado As String
        Get
            Return _rolAsignado
        End Get
        Set(value As String)
            _rolAsignado = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene el control que inicio el origen de la operacion de arrastrar/soltar carta
    ''' </summary>
    ''' <param name="e">Parametro del evento</param>
    ''' <returns>Retorna el control que inicio el Drag o bien Nothing si es otro tipo de arrastre</returns>
    Public Shared Function GetOrigenDragDrop(e As DragEventArgs) As Control

        If Not e.Data.GetDataPresent(GetType(DragDropData)) Then
            e.Effect = DragDropEffects.None
            Return Nothing
        End If

        Dim data As DragDropData = e.Data.GetData(GetType(DragDropData))
        Return LocalizadorDeControles.RecoverOriginalControl(data.NombreControl)
    End Function

    Private Sub RenderizarCarta()
        'Libero los recursos no manejados GDI del bitmap
        If _cartaRenderizada IsNot Nothing Then
            _cartaRenderizada.Dispose()
            _cartaRenderizada = Nothing
        End If

        If _carta Is Nothing Then
            _cartaRenderizada = GestorDeImagenes.DibujarCartaEnBlanco()
        Else
            If Me.MostrarCarta Then
                _cartaRenderizada = GestorDeImagenes.DibujarCarta(_carta)
            Else
                _cartaRenderizada = GestorDeImagenes.DibujarReversoDeCarta()
            End If
        End If

        'Cambio la carta dibujada
        _picture.Image = _cartaRenderizada
    End Sub

    Private Sub OnDobleClickDetectado(carta As Carta)
        RaiseEvent DobleClickDetectado(Me, New AccionConCartaRelacionadaEventArgs(carta))
    End Sub

    Private Sub OnOperacionArrastreIniciada(laCarta As Carta)
        RaiseEvent OperacionArrastreIniciada(Me, New AccionConCartaRelacionadaEventArgs(laCarta))
    End Sub

    Private Sub OnOperacionDeSoltarCartaDetectada(origen As VisorCarta, destino As VisorCarta)
        RaiseEvent OperacionDeSoltarCartaDetectada(Me, New MovimientoCartasEventArgs(origen.Carta, origen, destino))
    End Sub

    Protected Overridable Sub VisorCarta_MouseDown(sender As Object, e As MouseEventArgs)
        'Dado que los eventos de Drag & Drop dificultan el capturar DoubleClick utilizo el botón derecho como alternativa
        If e.Button = MouseButtons.Right Then
            Call Me.OnDobleClickDetectado(Me.Carta)
            Return
        End If

        If Me.HabilitarComoFuenteDeArrastre AndAlso Me.Carta IsNot Nothing Then
            Call Me.OnOperacionArrastreIniciada(Me.Carta)

            Dim dataObject As New DragDropData()
            dataObject.RolAsociado = Me.RolAsignado
            dataObject.NombreControl = LocalizadorDeControles.ResolveFullyQualifiedName(Me)
            Call Me.DoDragDrop(dataObject, DragDropEffects.Move)
        End If
    End Sub

    Private Sub VisorCarta_DragDrop(sender As Object, e As DragEventArgs)
        Dim origen As Control = GetOrigenDragDrop(e)
        If origen IsNot Nothing Then
            'Notificó un evento de desplazamiento solicitado por el usuario
            Call Me.OnOperacionDeSoltarCartaDetectada(origen, Me)
        End If
    End Sub

    Private Sub VisorCarta_DragEnter(sender As Object, e As DragEventArgs)
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub VisorCarta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Me.MouseDown, AddressOf Me.VisorCarta_MouseDown
        AddHandler Me.picture.MouseDown, AddressOf Me.VisorCarta_MouseDown

        AddHandler Me.DragEnter, AddressOf Me.VisorCarta_DragEnter
        AddHandler Me.picture.DragEnter, AddressOf Me.VisorCarta_DragEnter

        AddHandler Me.DragDrop, AddressOf Me.VisorCarta_DragDrop
        AddHandler Me.picture.DragDrop, AddressOf Me.VisorCarta_DragDrop
    End Sub
End Class
