using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest_CDJ2324
{
    [TestClass]
    public class GestionBancariaTest_CDJ2324
    {
        // VALIDAR REALIZAR REINTEGRO 

        [TestMethod]
        [DataRow(1000,250,750)]
        [DataRow(1000,1000,0)]
        [DataRow(1000,1,999)]
        [DataRow(1000,500,500)]
        public void validarReintegro(double saldoInicial, double reintegro, double saldoEsperado)
        {
            
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            //Método a probar
            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }
        
        // VALIDAR REALIZAR INGRESO

        [TestMethod]
        [DataRow(1000,1,1001)]
        [DataRow(1000,500,1500)]
        [DataRow(1000,80,1080)]
        public void validarRealizarIngresoPositivo(double saldoInicial, double ingreso, double saldoEsperado)
        {//CDJ2324
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo());
        }

        
        
        // VALIDAR REALIZAR INGRESO CANTIDAD NO VALIDA CDJ2324
        [TestMethod]
        [DataRow(1000,0)]
        [DataRow(1000,-1)]
        [DataRow(1000,-50)]
        public void RealizarIngresoCantidadNoValida(double saldoInicial, double ingreso)
        {
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarIngreso(ingreso);
            }
            catch (ArgumentOutOfRangeException exception) {
                StringAssert.Contains(exception.ParamName, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");

        }
        
       
        // VALIDAR REALIZAR REINTEGRO CANTIDAD NO VALIDA CDJ2324
        [TestMethod]
        [DataRow(1000,-250)]
        [DataRow(1000, 0)]
        [DataRow(1000, -1)]

        public void RealizarReintegroCantidadNoValida(double saldoInicial, double reintegro)
        {
            
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try { 
                miApp.RealizarReintegro(reintegro);
            }catch(ArgumentOutOfRangeException exception) {
                StringAssert.Contains(exception.ParamName, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
            
        }
        // VALIDAR REALIZAR REINTEGRO SALDO INSUFICIENTE CDJ2324
        [TestMethod]
        [DataRow(1000,1500)]
        [DataRow(150,230)]
        public void RealizarReintegroSaldoInsuficiente(double saldoInicial,double reintegro)
        {
            
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.ParamName, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");

        }

    }
}

