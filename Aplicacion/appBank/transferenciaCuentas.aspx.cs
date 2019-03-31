using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class transferenciaCuentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Session["idUsu"] == null)
            {
                Response.Redirect("iniciarSesion.aspx");
            }
            if (Session["rolUsu"].ToString().Equals("1"))
            {
                Response.Redirect("iniciarSesion.aspx");
            }
            String encabezado = "No. Cuenta: " + Session["idCuenta"].ToString() + " Nombre: "+ Session["nombreUsu"].ToString()+" codigo: "+ Session["idUsu"].ToString();
            nombre_usuario.Text = encabezado;
        }
    }

    protected void boton_Click(object sender, EventArgs e)
    {

    }
}