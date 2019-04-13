using appBank;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class TransferenciaTest
    {
        Conexion con = new Conexion();
        [TestMethod]
        public void obtenerCuenta()
        {
            int idCuenta = 2;
            Assert.IsNotNull(con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + idCuenta.ToString() + ";"));
        }

        [TestMethod]
        public void Retiro()
        {
            double valorActual = 2000;
            int idCuenta = 2;
            Assert.IsTrue(con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + valorActual + " WHERE idCuenta = " + idCuenta.ToString() + ";"));
        }

        [TestMethod]
        public void Deposito()
        {
            double valorActual = 100;
            int idCuenta = 2;
            Assert.IsTrue(con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + valorActual + " WHERE idCuenta = " + idCuenta.ToString() + ";"));
        }

        [TestMethod]
        public void Transferencia_entre_cuentas()
        {
            int idCuenta1 = 2;
            int idCuenta2 = 3;
            double valorActual = 200;
            double montoAumenta = 400;
            Boolean respuesta = con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + valorActual + " WHERE idCuenta = " + idCuenta1 + ";") && con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + montoAumenta + " WHERE idCuenta = " + idCuenta2 + ";");
            Assert.IsTrue(respuesta);
        }
    }
}
