using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class Inicio : System.Web.UI.Page
    {
        Conexion con = new Conexion();
        List<Datos> cuenta;
        double valorActual;

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
                name_user.Text = Session["nombreUsu"].ToString();

            }
            this.cuenta = con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + Session["idCuenta"].ToString() + ";");
            this.valorActual = Convert.ToDouble(cuenta[0].dato2.ToString());
            saldoActual.Text = "Saldo actual: Q " + valorActual.ToString("N2");
        }
    }
}