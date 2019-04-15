using System;
using appBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class reporteSolicitudesTest
    {
        Conexion c = new Conexion();
        [TestMethod]
        public void solicitudesTest()
        {
            //CONSULTA PARA OBTENER LAS SOLICITUDES
            String query = "SELECT c.idCuenta, u.nombre, c.saldo, s.monto, s.descripcion, s.estado FROM Solicitud_Prestamo s, Cuenta c, Usuario u WHERE s.idCuenta = c.idCuenta and c.idUsuario = u.idUsuario;";
            bool resp1 = c.Ejecutar201503984(query);
            Assert.IsTrue(resp1);

        }
    }
}
