using System;
using appBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class reporteNotificacionesTest
    {
        Conexion c = new Conexion();
        [TestMethod]
        public void NotificacionesTest()
        {
            // CONSULTA PARA VER LAS NOTIFICACIONES
            String query = "SELECT n.mensaje, n.fecha, u.nombre, n.estado FROM Notificacion n, Cuenta c, Usuario u WHERE n.cuentaReceptora = 1 and n.cuentaEmisora = c.idCuenta and c.idUsuario = u.idUsuario ORDER BY n.idNotificacion DESC; ";
            bool resp1 = c.Ejecutar201503984(query);
            Assert.IsTrue(resp1);
        }
    }
}
