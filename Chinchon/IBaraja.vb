Imports Chinchon.Entities

Public interface IBaraja
    Function TomarCarta() As Carta

    ''' <summary>
    ''' Devuelve la última carta de la baraja (Proxima para tomar)
    ''' </summary>
    ReadOnly Property ProximaCarta As Carta
end interface