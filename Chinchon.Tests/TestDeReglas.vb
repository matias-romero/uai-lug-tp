Imports Chinchon.Combinaciones
Imports Chinchon.Entities
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class TestDeReglas

    <TestMethod()>
    Public Sub UnPieConTresCartasSinComodinDebeSerValido()
        Dim combinacion As New Pie()
        Dim cartasPorCombinar As Carta() = New Carta() {New Carta(1, Palo.Espada), New Carta(1, Palo.Basto), New Carta(1, Palo.Copa)}

        combinacion.AgregarCartas(cartasPorCombinar)
        Assert.IsTrue(combinacion.EsValida())

        'Agregando la 4 carta del mismo numero debe seguir siendo válido
        combinacion.AgregarCarta(New Carta(1, Palo.Oro))
        Assert.IsTrue(combinacion.EsValida(), "Cuatro cartas del mismo número también deben formar un pie válido")
    End Sub

    <TestMethod()>
    Public Sub UnaEscaleraSiNoSonTodasDelMismoPaloNoDebeSerValido()
        Dim combinacion As New Escalera()
        Dim cartasPorCombinar As Carta() = New Carta() {New Carta(1, Palo.Espada), New Carta(2, Palo.Espada), New Carta(3, Palo.Espada), New Carta(4, Palo.Copa)}

        combinacion.AgregarCartas(cartasPorCombinar)
        Assert.IsFalse(combinacion.EsValida(), "La escalera debe tener cartas al menos tres cartas de número consecutivo del mismo palo")
    End Sub

    <TestMethod()>
    Public Sub UnaEscaleraConTodasDelMismoPaloDebeSerValido()
        Dim combinacion As New Escalera()
        Dim cartasPorCombinar As Carta() = New Carta() {New Carta(1, Palo.Espada), New Carta(2, Palo.Espada), New Carta(3, Palo.Espada), New Carta(4, Palo.Espada)}

        combinacion.AgregarCartas(cartasPorCombinar.Take(2))
        Assert.IsFalse(combinacion.EsValida(), "La escalera requiere un mínimo de tres cartas para ser válida")

        combinacion.AgregarCarta(cartasPorCombinar(2))
        Assert.IsTrue(combinacion.EsValida(), "La escalera con tres cartas consecutivas del mismo palo debe ser válida")

        combinacion.AgregarCarta(cartasPorCombinar(3))
        Assert.IsTrue(combinacion.EsValida(), "La escalera con cuatro cartas consecutivas del mismo palo también debe ser válida")
    End Sub

    <TestMethod()>
    Public Sub UnChinchonSinComodinesDebeTenerSieteCartasEnEscaleraParaSerValido()
        Dim combinacion As New Combinaciones.Chinchon()
        Dim cartasPorCombinar As Carta() = New Carta() {New Carta(3, Palo.Espada), New Carta(4, Palo.Espada), New Carta(5, Palo.Espada), New Carta(6, Palo.Espada), New Carta(7, Palo.Espada), New Carta(8, Palo.Espada), New Carta(9, Palo.Espada)}

        combinacion.AgregarCartas(cartasPorCombinar.Take(5))
        Assert.IsFalse(combinacion.EsValida(), "El chinchón debe tener al menos 7 cartas")

        combinacion.AgregarCartas(cartasPorCombinar.Skip(5)) 'Agrego las restantes
        Assert.IsTrue(combinacion.EsValida(), "El chinchón formando la escalera de 7 debe ser válido")
    End Sub

    <TestMethod()>
    Public Sub UnChinchonConComodinDebeSerValido()
        Dim cartaComodin As New CartaComodin()
        Assert.IsFalse(cartaComodin.TieneValorAsignado, "El comodin no puede tener valor asignado cuando lo creo")

        Dim cartasPorCombinar As Carta() = New Carta() {New Carta(3, Palo.Espada), New Carta(4, Palo.Espada), cartaComodin, New Carta(6, Palo.Espada), New Carta(7, Palo.Espada), New Carta(8, Palo.Espada), New Carta(9, Palo.Espada)}
        Dim combinacion As New Combinaciones.Chinchon()

        combinacion.AgregarCartas(cartasPorCombinar.Take(5))
        Assert.IsFalse(combinacion.EsValida(), "El chinchón debe tener al menos 7 cartas")

        combinacion.AgregarCartas(cartasPorCombinar.Skip(5)) 'Agrego las restantes
        Assert.IsFalse(combinacion.EsValida(), "El chinchón no puede ser válido hasta que el comodín asuma su valor")

        cartaComodin.NumeroAsignadoPorUsuario = 5
        cartaComodin.PaloAsignadoPorUsuario = Palo.Espada
        Assert.IsTrue(combinacion.EsValida(), "El chinchón formando la escalera de 7 debe ser válido")
    End Sub

End Class