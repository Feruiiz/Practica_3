﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


public partial class CrearUsuario : System.Web.UI.Page
{

    Conexion c = new Conexion();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*
    public String generateCod() {
        //codigo alphanumerico que generara el random aleaotorio de 
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);

        return finalString;

    }
    */

    protected void boton_Click(object sender, EventArgs e)
    {
        String name, nick, email;
        name = nombre.Text;
        nick = nickname.Text;
        if (nick.Any(char.IsDigit)) {//validar que el nickname contenga un numero
            email = correo.Text;

            if (pass1.Text == pass2.Text)
            {
                if(c.crearUsuario(name, nick, pass1.Text, email))
                {
                   Response.Write("<script>window.alert('Se ha registro al sistema');</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Ocurrió un error al intentar agregarse a la base de datos');</script>");
                }

            }
            else
            {
                Response.Write("<script>window.alert('Las contraseñas no coinciden');</script>");
            }

        }
        else
        {
            Response.Write("<script>window.alert('Su Nickname debe contener al menos un numero');</script>");
        }
        
    }
}