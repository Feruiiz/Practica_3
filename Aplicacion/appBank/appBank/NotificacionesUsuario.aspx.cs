using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class NotificacionesUsuario : System.Web.UI.Page
    {

        Conexion c = new Conexion();
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
                mostrarNotificaciones();

            }
        }

        private void mostrarNotificaciones()
        {
            String query = "SELECT n.mensaje, n.fecha, u.nombre, n.estado FROM Notificacion n, Cuenta c, Usuario u WHERE n.cuentaReceptora = " + Session["idCuenta"].ToString() + " and n.cuentaEmisora = c.idCuenta and c.idUsuario = u.idUsuario ORDER BY n.idNotificacion DESC; ";
            MySqlConnection conn = c.getConection();
            if (conn != null)
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    Response.Write("</br></br></br></br>");
                    Response.Write("<center><table border=3px bordercolor=white>");
                    Response.Write("<tr>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center>NOTIFICACION</center></font></td>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center>FECHA</center></font></td>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center>DE</center></font></td>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center>ESTADO</center></font></td>");
                    Response.Write("</tr>");
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Response.Write("<tr>");
                            Response.Write("<td bgcolor=#FFFFFF border-bottom = 1pt><font color=black><center>" + reader[0].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#FFFFFF border-bottom = 1pt><font color=black><center>" + reader[1].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#FFFFFF border-bottom = 1pt><font color=black><center>" + reader[2].ToString() + "</center></font></td>");
                            if (reader[3].ToString().Equals("0"))
                            {
                                Response.Write("<td bgcolor=#FFFFFF border-bottom = 1pt><font color=black><center> SIN LEER </center></font></td>");
                            }
                            else
                            {
                                Response.Write("<td bgcolor=#FFFFFF border-bottom = 1pt><font color=black><center> LEIDA </center></font></td>");
                            }
                            Response.Write("</tr>");
                        }
                    }
                    Response.Write("</table><center>");
                    conn.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
                    conn.Close();
                }
            }
        }

        protected void marcar_leidas(object sender, EventArgs e)
        {
            String comando = "UPDATE Notificacion set estado = 1 where cuentaReceptora =" + Session["idCuenta"].ToString() + ";";
            c.Ejecutar201503984(comando);
            Response.Redirect("NotificacionesUsuario.aspx");
        }

    }
}