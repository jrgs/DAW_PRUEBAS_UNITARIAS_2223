using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionBancariaAppNS;
using System.Threading;

namespace Practica_4._2_Julian_Perez_Pereña
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        [DataRow(1000, 250, 750)]
        public void ValidarReintegro(double saldoInicial, double reintegro, double saldoEsperado)
        {
            
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Julian Perez 2023/2024
            miApp.RealizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegro = 0;
            double saldoEsperado = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            throw new ArgumentOutOfRangeException("Cantidad no válida");
            // julian Perez Perena 2023-2024
            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message,
               GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
           
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroSaldoInsuficiente()
        {
            double saldoInicial = 0;
            double reintegro = 250;
            double saldoEsperado = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            throw new ArgumentOutOfRangeException("saldo insuficiente");

            try //JULIAN Perez 2023/2024
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message,
               GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
                  
        }
        [TestMethod]
        [DataRow(1000, 250, 1250)]
        public void ValidarIngreso(double saldoInicial, double ingreso,double saldoEsperado)
        {
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarIngreso(ingreso);
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001);
                  
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingreso = 0;
            double saldoEsperado = saldoInicial + ingreso;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
             throw new ArgumentOutOfRangeException("Cantidad no válida");
            try
            {
                miApp.RealizarIngreso(ingreso);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message,
               GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
          

        }
    }
}
