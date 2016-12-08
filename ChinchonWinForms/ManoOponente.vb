Imports System.ComponentModel

Public Class ManoOponente
    Private _mostrarHorizontal As Boolean

    <Description("Devuelve o establece si el control se muestra de manera horizontal o vertical"), Category("Layout"),
        DefaultValue(False)>
    Public Property MostrarHorizontal As Boolean
        Get
            Return _mostrarHorizontal
        End Get
        Set
            _mostrarHorizontal = Value
            Call Me.DibujarReversoCarta(_mostrarHorizontal)
        End Set
    End Property

    Private Sub DibujarReversoCarta(rotarHorizontalmente As Boolean)
        Dim reversoDeCarta As Image = GestorDeImagenes.DibujarReversoDeCarta()
        If rotarHorizontalmente Then
            Using imagenOriginal As Image = reversoDeCarta
                Dim imagenRotada As Image = New Bitmap(imagenOriginal, imagenOriginal.Height, imagenOriginal.Width)
                imagenRotada.RotateFlip(RotateFlipType.Rotate90FlipNone)
                reversoDeCarta = imagenRotada
            End Using
        End If

        For Each pictureBox As PictureBox In Me.PictureBoxes
            If pictureBox.Image IsNot Nothing Then
                Call pictureBox.Image.Dispose()
            End If

            pictureBox.Image = reversoDeCarta
        Next
    End Sub

    Private Sub ManoOponente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call DibujarReversoCarta(false)
    End Sub

    Private ReadOnly Property PictureBoxes As IEnumerable(Of PictureBox)
        Get
            Return Me.Controls.OfType(Of PictureBox)
        End Get
    End Property

    Private Sub ManoOponente_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'Dada la complejidad de resize del control para que se visualicen en linea, capturo el evento y lo armo programaticamente
        Dim offset As double = 0
        Dim dimensionMaximaPorCarta As double = IIf(MostrarHorizontal, Me.Height, Me.Width) / 7.0

        Me.SuspendLayout()
        For Each pictureBox As PictureBox In Me.PictureBoxes
            If Me.MostrarHorizontal Then
                pictureBox.Location = New Point(0, offset)
                pictureBox.Size = New Size(me.Width, dimensionMaximaPorCarta)
            Else
                pictureBox.Location = New Point(offset, 0)
                pictureBox.Size = New Size(dimensionMaximaPorCarta, Me.Height)
            End If

            offset += dimensionMaximaPorCarta
        Next
        Me.ResumeLayout()
    End Sub
End Class
