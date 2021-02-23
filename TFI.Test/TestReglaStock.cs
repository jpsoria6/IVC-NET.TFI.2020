using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TFI.Dominio;
using TFI.Dominio.Dominio;

namespace TFI.Test
{
    [TestClass]
    public class TestReglaStock
    {

        [TestMethod]
        public void IngresarCantidadMayorMax()
        {
            Assert.ThrowsException<Exception>(() => {
                ReglaStock.Instance.VerificarCantidad(70);
            });
        }

        [TestMethod]
        public void IngresarCantidadExitosa()
        {

        }

        [TestMethod]
        public void IngresarCantidadNegativa()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                ReglaStock.Instance.VerificarCantidad(-5);
            });
        }

        [TestMethod]
        public void IngresarCantidadCero()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                ReglaStock.Instance.VerificarCantidad(0);
            });
        }

    }
}
