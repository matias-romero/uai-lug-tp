Imports System.ComponentModel
Imports Chinchon.Entities

Public Class VisorMonton
    Public Event OperacionDeCerrarRondaDetectada As EventoConMovimientoCartasAsociado
    Public Event OperacionDeSoltarCartaDetectada As EventoConMovimientoCartasAsociado

    Private Sub VisorMonton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using imagenOriginal As Image = GestorDeImagenes.DibujarReversoDeCarta()
            Dim imagenRotada As Image = New Bitmap(imagenOriginal, imagenOriginal.Height, imagenOriginal.Width)
            imagenRotada.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Me.picCartaCerrado.Image = imagenRotada
        End Using
    End Sub

    <Description("Devuelve o establece si se puede realizar un Cierre de ronda"), Category("Data"), DefaultValue(True)>
    Public Property PermiteCerrar As Boolean
        Get
            Return Me.picRedCross.Visible
        End Get
        Set
            Me.picRedCross.Visible = Value
        End Set
    End Property

    <Description("Devuelve o establece si se muestra el monton cerrado o no"), Category("Data"), DefaultValue(False)>
    Public Property EstaCerrado As Boolean
        Get
            Return Me.picCartaCerrado.Visible
        End Get
        Set
            Me.picCartaCerrado.Visible = Value
            Me.PermiteCerrar = Not Value
            Me.AllowDrop = Not Value
        End Set
    End Property

    <Description("Devuelve o establece la carta a visualizar"), Category("Data")>
    Public Property CartaVisible As Carta
        Get
            Return Me.VisorCartaMonton.Carta
        End Get
        Set
            Me.VisorCartaMonton.Carta = Value
        End Set
    End Property

    Public Overrides Property AllowDrop As Boolean
        Get
            Return Me.VisorCartaMonton.AllowDrop
        End Get
        Set(value As Boolean)
            Me.VisorCartaMonton.HabilitarComoFuenteDeArrastre = value
            Me.VisorCartaMonton.HabilitarComoDestinoDeArrastre = value
            Me.picRedCross.AllowDrop = value
        End Set
    End Property

    Private Sub picRedCross_DragEnter(sender As Object, e As DragEventArgs) Handles picRedCross.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub picRedCross_DragDrop(sender As Object, e As DragEventArgs) Handles picRedCross.DragDrop
        Dim origen As Control = VisorCarta.GetOrigenDragDrop(e)
        Dim cartaCierre As Carta = DirectCast(origen, VisorCarta).Carta
        RaiseEvent OperacionDeCerrarRondaDetectada(Me, New MovimientoCartasEventArgs(cartaCierre, origen, Me))
    End Sub

    Private Sub VisorCartaMonton_OperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs) Handles VisorCartaMonton.OperacionDeSoltarCartaDetectada
        RaiseEvent OperacionDeSoltarCartaDetectada(Me, e)
    End Sub
End Class
