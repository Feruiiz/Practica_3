using System;
using appBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace appBankTest
{
    [TestClass]
    public class RegistroTest
    {
        [TestMethod]
        public void TestCrearUsuario()
        {
            //PRUEBA PARA CREAR USUARIOS
            String name = "Jefferson Linares";//nombre del usuario
            String nick = "jeff1234";  //nickname debe contener un digito
            String pass = "abcde123";  //contraseña de 8 digitos
            String email = "jefflinares@gmail.com"; //correo electronico

            Conexion c = new Conexion();

            Boolean respuesta = c.crearUsuario(name, nick, pass, email);

            Assert.IsTrue(respuesta); //si la respuesta es verdadera el metodo esta bien y si crea al usuario
        }
    }
}
