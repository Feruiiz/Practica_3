using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class iniciarSesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["idUsu"] = null;
            Session["nombreUsu"] = null;
            Session["nicknameUsu"] = null;
            Session["correoUsu"] = null;
            Session["passUsu"] = null;
            Session["rolUsu"] = null;
            Session["idCuenta"] = null;
        }
    }

    protected void boton_Click(object sender, EventArgs e)
    {
        Conexion c = new Conexion();
        String query = "SELECT u.idUsuario, u.nombre, u.nickname, u.correo,u.contraseña,u.idrolUsuario,c.idCuenta ";
        query += "FROM Usuario u, Cuenta c";
        query += " WHERE u.idUsuario = c.idUsuario AND c.idCuenta = "+codigoUsu.Text+" AND u.nickname ='"+nicknameUsu.Text+"' AND u.contraseña='"+passUsu.Text+"';";

        List<Datos> usuario = c.Validar_Usuario(query);
        if ( usuario != null)
        {
            Session["idUsu"] = usuario[0].dato1;
            Session["nombreUsu"] = usuario[0].dato2;
            Session["nicknameUsu"] = usuario[0].dato3;
            Session["correoUsu"] = usuario[0].dato4;
            Session["passUsu"] = usuario[0].dato5;
            Session["rolUsu"] = usuario[0].dato6;
            Session["idCuenta"] = usuario[0].dato7;
            Response.Redirect("transferenciaCuentas.aspx");
            
        }
        else
        {
            Error.Text = "ERROR: el usuario no existe";
        }

    }
}