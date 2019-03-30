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
            Conexion c = new Conexion();
            if (c.probarConexion())
            {
                Response.Write("<script>window.alert('si hay conexion con la database sos un crack');</script>");
                Console.WriteLine("si conecto");
            }
            else
            {
                Response.Write("<script>window.alert('si hay conexion con la database sos un crack');</script>");
                Console.WriteLine("fallo");
            }
        }
    }

    protected void boton_Click(object sender, EventArgs e)
    {
        Conexion c = new Conexion();
        if (c.probarConexion())
        {
            Response.Write("<script>window.alert('si hay conexion con la database sos un crack');</script>");
            Console.WriteLine("si conecto");
        }
        else
        {
            Response.Write("<script>window.alert('si hay conexion con la database sos un crack');</script>");
            Console.WriteLine("fallo");
        }
    }
}