using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class perfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["idUsu"] == null)
                {
                    Response.Redirect("iniciarSesion.aspx");
                }
                if (Session["rolUsu"].ToString().Equals("1"))
                {
                    Response.Redirect("iniciarSesion.aspx");
                }
                String encabezado = "No. Cuenta: " + Session["idCuenta"].ToString() + " Nombre: " + Session["nombreUsu"].ToString() + " codigo: " + Session["idUsu"].ToString();
                nombre_usuario.Text = encabezado;

                nombre.Text = Session["nombreUsu"].ToString();
                nickname.Text = Session["nicknameUsu"].ToString();
                correo.Text = Session["correoUsu"].ToString();
            }


        }

        protected void boton_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            if (nombre.Text != "" && nickname.Text != "" && correo.Text != "")
            {
                if (pass.Text.Equals(Session["passUsu"].ToString()))
                {
                    if (c.Ejecutar201503984("UPDATE Usuario SET nombre='" + nombre.Text + "',nickname='" + nickname.Text + "',correo='" + correo.Text + "' WHERE idUsuario = " + Session["idUsu"].ToString() + " and contraseña = '" + Session["passUsu"].ToString() + "';"))
                    {
                        pass.Text = "";
                        Response.Write("<script>window.alert('Se guardaron las cambios correctamente.');</script>");
                    }
                    else
                    {
                        Error.Text = "ERROR: No se pudieron guardar los cambios.";
                    }
                }
                else
                {
                    Error.Text = "ERROR: la contraseña no coincide.";
                }
            }
            else
            {
                Error.Text = "ERROR: Debe de llenar todos lo campos.";
            }
        }
    }
}