Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class TestDeBaraja

    <TestMethod()>
    Public Sub ProbarIgualdadEntreCartas()
        Dim anchoEspada As Carta = New Carta(1, Palo.Espada)
        Dim otroAnchoEspada As Carta = New Carta(1, Palo.Espada)
        Dim anchoBasto As Carta = New Carta(1, Palo.Basto)

        Assert.AreEqual(anchoEspada, otroAnchoEspada)
        Assert.AreNotEqual(anchoEspada, anchoBasto)
    End Sub

    <TestMethod()>
    Public Sub MezclarLaBarajaDebeAlterarElOrdenDeLasCartas()
        Dim baraja As New Baraja()
        Dim secuenciaPorDefecto As Carta() = baraja.ToArray()

        baraja.Barajar()

        Dim secuenciaMezcladaUnaVez As Carta() = baraja.ToArray()
        Assert.IsFalse(secuenciaPorDefecto.SequenceEqual(secuenciaMezcladaUnaVez), "Debe cambiar el orden luego de ser mezclado")

        baraja.Barajar()

        Dim secuenciaMezcladaDosVeces As Carta() = baraja.ToArray()
        Assert.IsFalse(secuenciaMezcladaUnaVez.SequenceEqual(secuenciaMezcladaDosVeces), "Debe cambiar el orden luego de ser mezclado otra vez")
    End Sub

End Class