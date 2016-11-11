
Imports Chinchon.Entities

Public Interface IMonton
    Event CambioColeccion As EventHandler

    ''' <summary>
    ''' Devuelve la carta actual visible del montón
    ''' </summary>
    ReadOnly Property Cara As Carta

    ''' <summary>
    ''' Coloca una carta en el montón
    ''' </summary>
    ''' <param name="carta">Carta seleccionada</param>
    Sub Poner(carta As Carta)

    ''' <summary>
    ''' Toma la carta superior del montón y retorna su referencia
    ''' </summary>
    Function Sacar() As Carta
End Interface