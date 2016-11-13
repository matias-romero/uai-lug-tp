Imports Chinchon
Imports Chinchon.Entities

Public Class ManoPorJugador
    Public Event DobleClickSobreCartaDetectado As EventoConCartaRelacionada
    Public Event OperacionDeSoltarCartaDetectada As EventoConMovimientoCartasAsociado

    Private _manoDelJugador As Mano
    Private _visoresPorCarta As VisorCarta()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _visoresPorCarta = New VisorCarta() {Me.VisorCarta1, Me.VisorCarta2, Me.VisorCarta3, Me.VisorCarta4, Me.VisorCarta5, Me.VisorCarta6, Me.VisorCarta7}
        For Each visor As VisorCarta In _visoresPorCarta 'Escucho los eventos de drop de cada visor y propago el mismo al consumidor
            AddHandler visor.OperacionDeSoltarCartaDetectada, AddressOf Me.OnOperacionDeSoltarCartaDetectada
            AddHandler visor.DobleClickDetectado, AddressOf Me.OnDobleClickSobreCartaDetectado
        Next
    End Sub

    Public Sub Init(manoDelJugador As Mano)
        _manoDelJugador = manoDelJugador
        Dim indiceControl As Integer = 0
        For Each carta As Carta In _manoDelJugador.Cartas
            _visoresPorCarta(indiceControl).Carta = carta
            _visoresPorCarta(indiceControl).RolAsignado = String.Concat("Mano_Indice=", indiceControl)
            indiceControl += 1
        Next

        'Disparo el resize para que se acomoden las cartas
        Me.OnResize(EventArgs.Empty)
    End Sub

    Private Sub ManoPorJugador_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If _visoresPorCarta Is Nothing Then Return

        'Dada la complejidad de resize del control para que se visualicen en linea, capturo el evento y lo armo programaticamente
        Dim izq As Integer = 0
        Dim anchoMaximoPorCarta As Integer = Me.Width / 7

        Me.SuspendLayout()
        For Each visorPorCarta As Control In _visoresPorCarta
            visorPorCarta.Location = New Point(izq, 0)
            visorPorCarta.Size = New Size(anchoMaximoPorCarta, Me.Height)
            izq += anchoMaximoPorCarta
        Next
        Me.ResumeLayout()
    End Sub

    Private Sub OnOperacionDeSoltarCartaDetectada(sender As Object, e As MovimientoCartasEventArgs)
        RaiseEvent OperacionDeSoltarCartaDetectada(Me, e)
    End Sub

    Private Sub OnDobleClickSobreCartaDetectado(sender As Object, e As AccionConCartaRelacionadaEventArgs)
        RaiseEvent DobleClickSobreCartaDetectado(Me, e)
    End Sub
End Class
