Imports Chinchon.Entities

Namespace Combinaciones

    Public MustInherit Class Combinacion
        Private ReadOnly _cartas As New List(Of Carta)

        public Event ColeccionModificada as EventHandler

        ''' <summary>
        ''' Enumera las cartas incluidas en la combinación
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Cartas As IEnumerable(Of Carta)
            Get
                Return _cartas
            End Get
        End Property

        ''' <summary>
        ''' Agrega una carta específica a la combinación
        ''' </summary>
        ''' <param name="carta">La carta que agrega</param>
        Public Sub AgregarCarta(carta As Carta)
            _cartas.Add(carta)

            Call Me.OnColeccionModificada()
        End Sub

        ''' <summary>
        ''' Agrega un listado de cartas a la combinación
        ''' </summary>
        ''' <param name="listadoCartas">Listado de cartas por agregar</param>
        Public Sub AgregarCartas(listadoCartas As IEnumerable(Of Carta))
            _cartas.AddRange(listadoCartas)

            Call Me.OnColeccionModificada()
        End Sub

        ''' <summary>
        ''' Elimina una carta de la combinación
        ''' </summary>
        ''' <param name="unaCarta">Carta que desea eliminar de la combinación</param>
        ''' <returns>Retorna verdadero en caso de haberla encontrado y removido de la colección</returns>
        Public Function RemoverCarta(unaCarta As Carta) As Boolean
            Dim fueRemovida As Boolean = _cartas.Remove(unaCarta)
            If fueRemovida Then Call Me.OnColeccionModificada()
            Return fueRemovida
        End Function

        ''' <summary>
        ''' Determina si la carta consultada está incluida en la combinación
        ''' </summary>
        ''' <param name="carta"></param>
        ''' <returns></returns>
        public Function TieneLaCarta(carta As carta) As Boolean
            Return Me.Cartas.Contains(carta)
        End Function

        ''' <summary>
        ''' Determina el número mínimo de cartas permitidas para poder hacer la combinación
        ''' </summary>
        Public Overridable ReadOnly Property MinimoCartasNecesarias As Integer
            Get
                Return 3
            End Get
        End Property

        ''' <summary>
        ''' Determina el máximo número de cartas posibles para hacer la combinación
        ''' </summary>
        Public MustOverride ReadOnly Property MaximoCartasPermitidas As Integer

        ''' <summary>
        ''' Comprueba que la combinación elegida de cartas cumpla la regla de juego
        ''' </summary>
        Public MustOverride Function EsValida() As Boolean

        Public Overrides Function ToString() As String
            'Utilizo el nombre de la clase como dato representativo
            Return Me.GetType().Name
        End Function

        Private sub OnColeccionModificada()
            RaiseEvent ColeccionModificada(me, EventArgs.Empty)
        End sub
    End Class

End Namespace
