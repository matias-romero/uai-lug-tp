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
    Public Sub ProbarIgualdadEntreCartaYUnComodinEspecializado()
        Dim comodin As CartaComodin = New CartaComodin()
        Dim otroComodin As Carta = New CartaComodin()
        Dim anchoBasto As Carta = New Carta(1, Palo.Basto)

        Assert.AreEqual(otroComodin, comodin, "Un comodin sin asignar valor debe ser igual a otro comodin")

        'Asigno al comodín valor de Ancho de basto y comparo la igualdad
        comodin.NumeroAsignadoPorUsuario = 1
        comodin.PaloAsignadoPorUsuario = Palo.Basto
        Assert.AreEqual(anchoBasto, comodin, "El comodin una vez especializado debe comportarse como tal carta")
    End Sub

    <TestMethod()>
    Public Sub ProbarQueSePuedanOrdenarLasCartas()
        Dim cartasDePrueba As Carta() = New Carta() {New Carta(10, Palo.Basto), New Carta(2, Palo.Espada), New Carta(1, Palo.Oro), New Carta(1, Palo.Espada), New Carta(10, Palo.Espada)}
        Dim cartasEsperadasAlOrdenar As Carta() = New Carta() {New Carta(1, Palo.Oro), New Carta(1, Palo.Espada), New Carta(2, Palo.Espada), New Carta(10, Palo.Espada), New Carta(10, Palo.Basto)}

        Assert.IsFalse(cartasDePrueba.SequenceEqual(cartasEsperadasAlOrdenar))
        Call Array.Sort(cartasDePrueba)

        Assert.IsTrue(cartasDePrueba.SequenceEqual(cartasEsperadasAlOrdenar), "Las cartas no se encuentran en el orden esperado")
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

    <TestMethod()>
    Public Sub UnComodinNoDebeTenerUnValorAsignadoHastaQueElUsuarioLoDefine()
        Dim comodin As New CartaComodin()
        Assert.IsFalse(comodin.TieneValorAsignado, "El comodín no debe tener un valor asignado como  estado inicial")

        'Asigno valores de prueba
        comodin.NumeroAsignadoPorUsuario = 9
        comodin.PaloAsignadoPorUsuario = Palo.Oro

        Assert.IsTrue(comodin.TieneValorAsignado, "Si explicité un valor, debe tenerlo asignado")
        Assert.AreEqual(9, comodin.Numero, "El comodín no respeta el número asignado por el usuario")
        Assert.AreEqual(Palo.Oro, comodin.Palo, "El comodín no respeta el palo asignado por el usuario")
    End Sub

End Class