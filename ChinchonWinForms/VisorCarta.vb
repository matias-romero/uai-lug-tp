﻿Imports Chinchon
Imports System.ComponentModel
Imports Chinchon.Entities

<DefaultBindingProperty("Carta")>
Public Class VisorCarta
    Public Event OperacionArrastreIniciada As EventoConCartaRelacionada
    Public Event OperacionDeSoltarCartaDetectada As EventoConMovimientoCartasAsociado

    Private _carta As Carta
    Private _cartaRenderizada As Image
    Private _mostrarCaraDeCarta As Boolean = True
    Private _habilitarComoFuenteDeArrastre As Boolean = False

    <Description("Devuelve o establece si se ve la cara de la carta o su reverso"), Category("Data"), DefaultValue(True)>
    Public Property MostrarCarta As Boolean
        Get
            Return _mostrarCaraDeCarta
        End Get
        Set
            _mostrarCaraDeCarta = Value
            Call Me.RenderizarCarta()
        End Set
    End Property

    <Description("Devuelve o establece la carta a visualizar"), Category("Data")>
    Public Property Carta As Carta
        Get
            Return _carta
        End Get
        Set
            _carta = Value
            Call Me.RenderizarCarta()
        End Set
    End Property

    <Description("Devuelve o establece si el control permite tomar la carta para ser arrastrarda"), Category("Data"), DefaultValue(False)>
    Public Property HabilitarComoFuenteDeArrastre As Boolean
        Get
            Return _habilitarComoFuenteDeArrastre
        End Get
        Set
            _habilitarComoFuenteDeArrastre = Value
        End Set
    End Property

    <Description("Devuelve o establece si el control permite aceptar una carta arrastrada desde otro control"), Category("Data"), DefaultValue(False)>
    Public Property HabilitarComoDestinoDeArrastre As Boolean
        Get
            Return Me.AllowDrop
        End Get
        Set
            Me.AllowDrop = Value
        End Set
    End Property

    Private Sub RenderizarCarta()
        'Libero los recursos no manejados GDI del bitmap
        If _cartaRenderizada IsNot Nothing Then
            _cartaRenderizada.Dispose()
            _cartaRenderizada = Nothing
        End If

        If _carta Is Nothing Then
            _cartaRenderizada = GestorDeImagenes.DibujarCartaEnBlanco()
        Else
            If Me.MostrarCarta Then
                _cartaRenderizada = GestorDeImagenes.DibujarCarta(_carta)
            Else
                _cartaRenderizada = GestorDeImagenes.DibujarReversoDeCarta()
            End If
        End If

        'Cambio la carta dibujada
        _picture.Image = _cartaRenderizada
    End Sub

    Private Sub OnOperacionArrastreIniciada(laCarta As Carta)
        RaiseEvent OperacionArrastreIniciada(Me, New AccionConCartaRelacionadaEventArgs(laCarta))
    End Sub

    Private Sub VisorCarta_MouseDown(sender As Object, e As MouseEventArgs)
        If Me.HabilitarComoFuenteDeArrastre AndAlso Me.Carta IsNot Nothing Then
            Call Me.OnOperacionArrastreIniciada(Me.Carta)
            Call Me.DoDragDrop(Me.Carta, DragDropEffects.Move)
        End If
    End Sub

    Private Sub VisorCarta_DragDrop(sender As Object, e As DragEventArgs)

    End Sub

    Private Sub VisorCarta_DragEnter(sender As Object, e As DragEventArgs)

    End Sub

    Private Sub VisorCarta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Me.MouseDown, AddressOf Me.VisorCarta_MouseDown
        AddHandler Me.picture.MouseDown, AddressOf Me.VisorCarta_MouseDown

        AddHandler Me.DragEnter, AddressOf Me.VisorCarta_DragEnter
        AddHandler Me.picture.DragEnter, AddressOf Me.VisorCarta_DragEnter

        AddHandler Me.DragDrop, AddressOf Me.VisorCarta_DragDrop
        AddHandler Me.picture.DragDrop, AddressOf Me.VisorCarta_DragDrop
    End Sub
End Class
