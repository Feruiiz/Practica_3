using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using appBank;
namespace appBankTest
{
    [TestClass]
    public class reporteUsuarios
    {
        Conexion c = new Conexion();
        [TestMethod]
        public void obtenerUsuarios()
        {
            String query = "SELECT u.nombre, u.nickname, u.correo,u.contraseña,u.idrolUsuario,c.idtipoCuenta,c.fecha_creacion,c.saldo FROM Usuario u, Cuenta c WHERE c.idUsuario = u.idUsuario;";
            bool respuesta = c.Ejecutar201503984(query);
            Assert.IsTrue(respuesta);
        }
    }
}
