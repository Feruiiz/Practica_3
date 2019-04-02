using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class Debitos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["idUsu"] == null)
                {
                    Response.Redirect("iniciarSesion.aspx");
                }
                if (Session["rolUsu"].ToString().Equals("2"))
                {
                    Response.Redirect("iniciarSesion.aspx");
                }
                String encabezado = "Administrador: " + Session["nombreUsu"].ToString() + " codigo: " + Session["idUsu"].ToString();
                nombre_usuario.Text = encabezado;
            }
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            Error.Text = "";
            Conexion c = new Conexion();
            String consulta = "SELECT a.idSolicitud,a.monto,a.estado,a.idAdmin,a.idCuenta FROM Solicitud_Prestamo a, Cuenta b WHERE a.idCuenta = b.idCuenta and b.idCuenta = " + cuenta.Text + " AND a.monto > 0 AND a.estado = 1 AND (a.monto IS NOT NULL) AND a.monto >= " + monto.Text + " Order BY a.monto DESC;";
            List<Datos> datos = c.datosCuenta(consulta);

            if (datos != null)
            {
                if (datos.Count > 0)
                {
                    String consultaCuenta = "SELECT * FROM Cuenta WHERE idCuenta = " + cuenta.Text + " AND saldo >= " + monto.Text + ";";
                    List<Datos> cuentas = c.datosCuenta(consultaCuenta);
                    if (cuentas != null)
                    {
                        if (cuentas.Count >= 0)
                        {
                            Double newSaldo = Convert.ToDouble(cuentas[0].dato2) - Convert.ToDouble(monto.Text);
                            c.Ejecutar201503984("UPDATE Cuenta SET saldo = " + newSaldo.ToString() + " WHERE idCuenta = " + cuenta.Text + ";");
                            newSaldo = Convert.ToDouble(datos[0].dato2) - Convert.ToDouble(monto.Text);
                            c.Ejecutar201503984("UPDATE Solicitud_Prestamo SET monto = " + newSaldo.ToString() + " WHERE idSolicitud = " + datos[0].dato1 + ";");
                            Response.Write("<script>window.alert('El debito se realizo con exito.');</script>");
                        }
                        else
                        {
                            Error.Text = "ERROR: La cuenta no cuenta con esa cantidad de dinero para debitar";
                        }
                    }
                    else
                    {
                        Error.Text = "ERROR: la cuenta no tiene prestamos.";
                    }
                }
                else
                {
                    Error.Text = "ERROR: no se puede realizar la debitacion del monto";
                }
            }
            else
            {
                Error.Text = "ERROR: no se puede realizar la debitacion del monto";
            }
        }
    }
}