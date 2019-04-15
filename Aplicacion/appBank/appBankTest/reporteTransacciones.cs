using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using appBank;

namespace appBankTest
{
    [TestClass]
    public class reporteTransacciones
    {
        Conexion c = new Conexion();
        [TestMethod]
        public void obtenerTransacciones()
        {
            int idCuenta = 1;
            String query = "SELECT b.nombre,a.monto,a.fecha,a.cuentaEmisor,a.cuentaReceptor, u.nombre FROM Transaccion a, Tipo_Transaccion b, Cuenta c, Usuario u WHERE b.idtipoTransaccion = a.tipoTransaccion and a.cuentaReceptor = c.idCuenta and c.idUsuario = u.idUsuario and cuentaEmisor = " + idCuenta + ";";
            bool resp = c.Ejecutar201503984(query);
            Assert.IsTrue(resp);
        }
    }
}
