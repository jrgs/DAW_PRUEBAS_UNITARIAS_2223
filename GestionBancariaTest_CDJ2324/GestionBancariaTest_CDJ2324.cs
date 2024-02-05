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
        public void validarReintegro()
        {
            //preparacion del caso de prueba CDJ_2324
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            //Método a probar
            miApp.RealizarReintegro(reintegro);

            //con Assert.AreEqual comprobamos que el valor saldoEsperado es igual a lo que se ha calculado con una presicion de 0.001
            //si no es así, la prueba no se superará

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }

        // VALIDAR OBTENER SALDO

        [TestMethod] //CDJ2324
        public void validarObtenerSaldo()
        {

            GestionBancariaApp miApp = new GestionBancariaApp(1000);

            double saldo = miApp.ObtenerSaldo();

            Assert.AreEqual(1000, saldo);


        }
        //VALIDAR REALIZAR INGRESO

        [TestMethod]
        
        public void validarRealizarIngresoPositivo()
        {
            //valor límite + 1 -> cantidad == 1 CDJ2324
            double saldoInicial = 1000;
            double ingreso = 1;
            double saldoEsperado = saldoInicial + ingreso;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo());
        }

        
        
        // VALIDAR REALIZAR INGRESO CANTIDAD NO VALIDA CDJ2324
        [TestMethod]
        public void RealizarIngresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingreso = -150;
            double saldoEsperado= saldoInicial + ingreso;

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
        public void RealizarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegro = -250;
            double saldoFinal = saldoInicial - reintegro;

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
        public void RealizarReintegroSaldoInsuficiente()
        {
            double saldoInicial = 500;
            double reintegro = 550;
            double saldoFinal = saldoInicial - reintegro;

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

