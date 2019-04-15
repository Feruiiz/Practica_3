using appBank;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class LoginTest
    {
        //----Este metodo verificara si devuelve un Usuario al iniciar sesion-------
        //---- null significa que los datos del usuario son erroneos
        //---- not null significa que los datos coinciden con un usuario
        [TestMethod]
        public void TestIniciarSesion()
        {
            String codigo = "4";
            String nickname = "marito12";
            String password = "abcde123";
            String query = "SELECT u.idUsuario, u.nombre, u.nickname, u.correo,u.contraseña,u.idrolUsuario,c.idCuenta FROM Usuario u, Cuenta c WHERE u.idUsuario = c.idUsuario AND c.idCuenta = " + codigo + " AND u.nickname ='" + nickname + "' AND u.contraseña='" + password + "';";
            Conexion c = new Conexion();
            int respuesta = c.Validar_Usuario(query).Count;
            Assert.IsNotNull(Convert.ToBoolean(respuesta));
        }


        //Este Test es para verificar si se cambio o no bien la contraseña
        [TestMethod]
        public void TestRecuperarContraseña()
        {
            String correo = "fer@gmail.com";
            String password = "123fffff";
            Conexion c = new Conexion();
            Boolean respuesta = c.Ejecutar201503984("UPDATE Usuario SET contraseña=\"" + password + "\" WHERE correo='" + correo + "';");
            Assert.IsTrue(respuesta);
        }

        

    }
}


