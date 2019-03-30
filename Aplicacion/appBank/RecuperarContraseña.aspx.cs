using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecuperarContraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void boton_Click(object sender, EventArgs e)
    {
        Error2.Text = "";
        if(pass1.Text.Length == 8 && pass2.Text.Length == 8)
        {
            if (pass1.Text.Equals(pass2.Text))
            {
                if (pass1.Text.Any(char.IsDigit))
                {
                    //aca va el codigo para cambiar contraseña
                    Conexion c = new Conexion();
                    if (c.Ejecutar201503984("UPDATE Usuario SET contraseña=\""+pass1.Text+"\" WHERE correo='"+correo.Text+"';"))
                    {
                        Response.Write("<script>window.alert('La contraseña sea recuperado.');</script>");
                    }
                    else
                    {
                        Error2.Text = "ERROR: El usuario no existe.";
                    }
                    
                    
                }
                else
                {
                    Error2.Text = "ERROR: la contraseña debe de tener como minimo un numero";
                }
            }
            else
            {
                Error2.Text = "ERROR: las contraseñas no coinciden.";
            }
        }
        else
        {
            Error2.Text = "ERROR: debe de ingresar una contraseña de 8 digitos.";
        }
    }
}