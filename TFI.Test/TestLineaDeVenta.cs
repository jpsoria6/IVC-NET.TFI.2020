using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TFI.Dominio;

namespace TFI.Test
{
    [TestClass]
    public class TestLineaDeVenta
    {

        [TestMethod]
        public void AgregarCantidadLineaDeVentaMayorMax()
        {
            Venta venta = new Venta();
            Indumentaria indumentariaDePrueba = new Indumentaria();


            Assert.ThrowsException<Exception>(() => {
                venta.AgregarLineaDeVenta(indumentariaDePrueba, 70);
            });
        }

        [TestMethod]
        public void AgregarLineaDeVentaExitosa()
        {
            Venta venta = new Venta();
            Indumentaria indumentariaDePrueba = new Indumentaria();
            Venta ventaEsperada = new Venta()
            {
                LineaDeVentas = new List<LineaDeVenta>()
                {
                    new LineaDeVenta(indumentariaDePrueba,5)
                }
            };

            venta.AgregarLineaDeVenta(indumentariaDePrueba, 5);

            Assert.AreEqual(ventaEsperada,venta);
        }

        [TestMethod]
        public void AgregarLineaDeVentaCantidadNegativa()
        {
            Venta venta = new Venta();
            Indumentaria indumentariaDePrueba = new Indumentaria();

            Assert.ThrowsException<Exception>(() =>
            {
                venta.AgregarLineaDeVenta(indumentariaDePrueba, -5);
            });
        }

        [TestMethod]
        public void AgregarLineaDeVentaCantidadCero()
        {
            Venta venta = new Venta();
            Indumentaria indumentariaDePrueba = new Indumentaria();

            Assert.ThrowsException<Exception>(() =>
            {
                venta.AgregarLineaDeVenta(indumentariaDePrueba, 0);
            });
        }

        //Testear AgregarLineaDeVenta if en el metodo ?
        //Con cantidad mayor a cant maxima no estariamos Testeando metodo reglastock.cantidadMaxima o hay que
        //agregar la referencia de venta a Reglastock
    }
}
