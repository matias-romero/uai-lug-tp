Imports System.Drawing
Imports Chinchon

''' <summary>
''' Utilitario para encapsular los dibujos de cada carta
''' </summary>
Public Class GestorDeImagenes
    Private Const AnchoSpritePx As Integer = 208
    Private Const AltoSpritePx As Integer = 319

    Private Shared FullSizeBitmap As Image = My.Resources.Baraja_española_completa

    Public Shared Function DibujarCarta(unaCarta As Carta) As Image
        Return LoadSpriteFromImage(New Point(GetOffsetXFor(unaCarta.Numero), GetOffsetYFor(unaCarta.Palo)))
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
