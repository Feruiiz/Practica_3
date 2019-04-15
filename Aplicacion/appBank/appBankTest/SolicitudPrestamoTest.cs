using System;
using System.Collections.Generic;
using appBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class SolicitudPrestamoTest
    {
        Conexion c = new Conexion();

        [TestMethod]
        public void aprobacionCreditos()
        {
            int no_solicitud = 19; //No solicitud existente en la base de datos.
            String comando = "UPDATE Solicitud_Prestamo SET estado = 1 where idSolicitud = " + no_solicitud + ";";
            bool res = c.Ejecutar201503984(comando);
            Assert.IsTrue(res);
        }


        [TestMethod]
        public void rechazarCreditos()
        {
            int no_solicitud = 19; //No solicitud existente en la base de datos.
            String comando = "UPDATE Solicitud_Prestamo SET estado = 2 where idSolicitud = " + no_solicitud + ";";
            bool res = c.Ejecutar201503984(comando);
            Assert.IsTrue(res);
        }
    }
}
