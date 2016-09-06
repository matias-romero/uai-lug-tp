Namespace Combinaciones

    ''' <summary>
    ''' Una escalera es cuando tengo más de tres cartas con números consecutivos y del mismo palo
    ''' </summary>
    Public Class Escalera
        Inherits Combinacion

        Public Overrides ReadOnly Property MaximoCartasPermitidas As Integer
            Get
                Return 7
            End Get
        End Property

        Public Overrides Function EsValida() As Boolean
            'Me aseguro de analizarlas ordenadas
            Dim cartasCombinadas As Carta() = Me.Cartas.ToArray()
            Array.Sort(cartasCombinadas)

            If cartasCombinadas.Length >= MinimoCartasNecesarias AndAlso cartasCombinadas.Length <= MaximoCartasPermitidas Then
                Dim esValido As Boolean = True
                Dim primeraCarta As Carta = cartasCombinadas(0)
                Dim menorNumero As Integer = primeraCarta.Numero

                For Each cartaCombinada As Carta In cartasCombinadas.Skip(1)
                    menorNumero += 1
                    esValido = esValido AndAlso cartaCombinada.Numero.Equals(menorNumero)
                Next

                Return esValido
            End If

            Return False
        End Function
    End Class

End Namespace
