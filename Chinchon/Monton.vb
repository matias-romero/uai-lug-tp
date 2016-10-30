Imports Chinchon.Entities

''' <summary>
''' Modela el montón de cartas que queda hacia arriba (LIFO)
''' </summary>
Public Class Monton
    Implements IMonton

    Public Event CambioColeccion As EventHandler Implements IMonton.CambioColeccion

    Private ReadOnly _pila As New Stack(Of Carta)

    ''' <summary>
    ''' Devuelve la carta actual visible del montón
    ''' </summary>
    Public ReadOnly Property Cara As Carta Implements IMonton.Cara
        Get
            If Me.EstaVacio Then 'Para evitar la InvalidOperationException cuando la pila esta vacia
                Return Nothing
            End If

            Return _pila.Peek()
        End Get
    End Property

    Private ReadOnly Property EstaVacio As Boolean
        Get
            Return _pila.Count = 0
        End Get
    End Property

    ''' <summary>
    ''' Coloca una carta en el montón
    ''' </summary>
    ''' <param name="carta">Carta seleccionada</param>
    Public Sub Poner(carta As Carta) Implements IMonton.Poner
        _pila.Push(carta)
        Me.OnCambioColeccion()
    End Sub

    ''' <summary>
    ''' Toma la carta superior del montón y retorna su referencia
    ''' </summary>
    Public Function Sacar() As Carta Implements IMonton.Sacar
        Dim carta As Carta = _pila.Pop()
        Me.OnCambioColeccion()
        Return carta
    End Function

    Private Sub OnCambioColeccion()
        RaiseEvent CambioColeccion(Me, EventArgs.Empty)
    End Sub
End Class
