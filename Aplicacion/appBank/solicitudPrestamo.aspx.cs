using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class solicitudPrestamo : System.Web.UI.Page
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
        }
    }

    protected void boton_Click(object sender, EventArgs e)
    {
        Conexion con = new Conexion();
        try
        {
            double valor = Convert.ToDouble(monto.Text);
            Response.Write("<script>window.alert('"+ valor.ToString("N2") + "');</script>");
            if (con.Ejecutar201503984("INSERT INTO Solicitud_Prestamo VALUES(default," + valor.ToString("N2") + ",'" + descripcion.Text + "',0,1," + Session["idCuenta"].ToString() + ");"))
            {
                Response.Write("<script>window.alert('La solicitud ha sido enviada.');</script>");
            }
            else
            {
                Error.Text = "ERROR: No se ha podido enviar la solicitud";
            }
        }
        catch (Exception)
        {

            Error.Text = "ERROR: los campos no han sido llenados correstamente";
        }
        
    }
}