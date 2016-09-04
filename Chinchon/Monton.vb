''' <summary>
''' Modela el montón de cartas que queda hacia arriba (LIFO)
''' </summary>
Public Class Monton
    Private _pila As New Stack(Of Carta)

    ''' <summary>
    ''' Devuelve la carta actual visible del montón
    ''' </summary>
    Public ReadOnly Property Cara As Carta
        Get
            If _pila.Count = 0 Then 'Para evitar la InvalidOperationException cuando la pila esta vacia
                Return Nothing
            End If

            Return _pila.Peek()
        End Get
    End Property

    ''' <summary>
    ''' Coloca una carta en el montón
    ''' </summary>
    ''' <param name="carta">Carta seleccionada</param>
    Public Sub Poner(carta As Carta)
        _pila.Push(carta)
    End Sub

    ''' <summary>
    ''' Toma la carta superior del montón y retorna su referencia
    ''' </summary>
    Public Function Sacar() As Carta
        Return _pila.Pop()
    End Function
End Class
