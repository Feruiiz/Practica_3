using appBank;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class DebitacionTest
    {
        Conexion c = new Conexion();
        [TestMethod]
        public void Debitacion()
        {
            double saldoActual = 2000;
            double saldoActual2 = 300;
            double monto = 200;
            int cuenta = 1;
            int cuenta2 = 2;
            Double newSaldo = Convert.ToDouble(saldoActual) - Convert.ToDouble(monto);
            Boolean resp1 = c.Ejecutar201503984("UPDATE Cuenta SET saldo = " + newSaldo.ToString() + " WHERE idCuenta = " + cuenta.ToString() + ";");
            newSaldo = Convert.ToDouble(saldoActual2) - Convert.ToDouble(monto.ToString());
            Boolean resp2 = c.Ejecutar201503984("UPDATE Solicitud_Prestamo SET monto = " + newSaldo.ToString() + " WHERE idSolicitud = " + cuenta2.ToString() + ";");
            Assert.IsNotNull(resp1 && resp2);
        }
    }
}
