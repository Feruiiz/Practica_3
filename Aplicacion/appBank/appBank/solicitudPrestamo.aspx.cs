using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
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
                MySqlConnection conn = con.getConection();
                if (conn != null)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Solicitud_Prestamo(monto, descripcion, estado, idAdmin, idCuenta) VALUES(" + valor + ",'" + descripcion.Text + "',0,1," + Session["idCuenta"].ToString() + ");";
                        cmd.ExecuteNonQuery();
                        
                        //----------------insertar transaccion 
                        cmd.CommandText = "INSERT INTO Transaccion(monto, cuentaEmisor, cuentaReceptor, tipoTransaccion) values (" + valor + ",1," + Session["idCuenta"].ToString() + ",5);";
                        cmd.ExecuteNonQuery();

                        //---       INSERTAR NOTIFICACION A ADMINISTRADOR
                        cmd.CommandText = "INSERT INTO Notificacion(mensaje, fecha, cuentaEmisora, cuentaReceptora, estado) values (\"Solicitud de Crédito Pendiente por un valor de: Q. " + valor + " \", default," + Session["idCuenta"].ToString() + ",1,0) ;";
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        Response.Redirect("Inicio.aspx");

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Response.Write("<script>window.alert('La solicitud no ha sido enviada.');</script>");
                        Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
                        conn.Close();
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('No se pudo conectar con la base de datos.');</script>");
                }

            }
            catch (Exception)
            {

                Error.Text = "ERROR: los campos no han sido llenados correstamente";
            }

        }
    }
}