Imports Chinchon
Imports Chinchon.Entities

Public Delegate Sub EventoConCartaRelacionada(sender As Object, e As AccionConCartaRelacionadaEventArgs)

Public Class AccionConCartaRelacionadaEventArgs
    Inherits EventArgs

    Public Sub New(carta As Carta)
        Me.Carta = carta
    End Sub

    Public Property Carta As Carta
End Class

Public Delegate Sub EventoConMovimientoCartasAsociado(sender As Object, e As MovimientoCartasEventArgs)

Public Class MovimientoCartasEventArgs
    Inherits EventArgs

    Public Property Carta As Carta
    Public Property Origen As Object
    Public Property Destino As Object

    Public Sub New(carta As Carta, origen As Object, destino As Object)
        Me.Carta = carta
        Me.Origen = origen
        Me.Destino = destino
    End Sub
End Class