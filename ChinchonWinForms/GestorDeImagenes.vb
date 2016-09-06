Imports Chinchon
Imports System.Drawing

''' <summary>
''' Utilitario para encapsular los dibujos de cada carta
''' </summary>
Public Class GestorDeImagenes
    Private Const AnchoSpritePx As Integer = 208
    Private Const AltoSpritePx As Integer = 319

    Private Shared ReadOnly FullSizeBitmap As Image = My.Resources.Baraja_española_completa

    ''' <summary>
    ''' Devuelve la imagen de la carta mostrando su cara
    ''' </summary>
    ''' <param name="unaCarta">Carta por dibujar</param>
    Public Shared Function DibujarCarta(unaCarta As Carta) As Image
        Dim offset As Point
        If unaCarta Is Nothing Then 'Espacio de carta en blanco
            offset = New Point(0 * AnchoSpritePx, 4 * AltoSpritePx)
        ElseIf TypeOf unaCarta Is CartaComodin Then 'Caso especial del comodin que no estaba incluido en la imagen
            Return My.Resources.Comodin_Solo
        Else 'El resto de las cartas sale como sprite
            offset = New Point(GetOffsetXFor(unaCarta.Numero), GetOffsetYFor(unaCarta.Palo))
        End If

        Return LoadSpriteFromImage(offset)
    End Function

    ''' <summary>
    ''' Devuelve una carta vista desde la contracara
    ''' </summary>
    Public Shared Function DibujarReversoDeCarta() As Image
        Dim offset As Point = New Point(1 * AnchoSpritePx, 4 * AltoSpritePx)
        Return LoadSpriteFromImage(offset)
    End Function

    ''' <summary>
    ''' Devuelve la representación de un slot vacio para colocar una carta
    ''' </summary>
    Public Shared Function DibujarCartaEnBlanco() As Image
        Return DibujarCarta(Nothing)
    End Function

    Private Shared Function GetOffsetXFor(numero As Integer)
        Return AnchoSpritePx * (numero - 1)
    End Function

    Private Shared Function GetOffsetYFor(palo As Palo)
        Select Case palo
            Case Palo.Oro
                Return 0 * AltoSpritePx
            Case Palo.Copa
                Return 1 * AltoSpritePx
            Case Palo.Espada
                Return 2 * AltoSpritePx
            Case Palo.Basto
                Return 3 * AltoSpritePx
        End Select
    End Function

    'Sprite de 205px x 320px
    Private Shared Function LoadSpriteFromImage(spriteOffset As Point) As Image
        Dim cropRect As New Rectangle(spriteOffset.X, spriteOffset.Y, AnchoSpritePx, AltoSpritePx)
        Dim src As Bitmap = FullSizeBitmap
        Dim target As Bitmap = New Bitmap(cropRect.Width, cropRect.Height)

        Using g = Graphics.FromImage(target)
            g.DrawImage(src, New Rectangle(0, 0, target.Width, target.Height),
                    cropRect,
                    GraphicsUnit.Pixel)
        End Using

        Return target
    End Function
End Class
