using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class reporteSolicitudes : System.Web.UI.Page
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
                if (Session["rolUsu"].ToString().Equals("2"))
                {
                    Response.Redirect("iniciarSesion.aspx");
                }
                String encabezado = "Administrador: " + Session["nombreUsu"].ToString() + " codigo: " + Session["idUsu"].ToString();
                nombre_usuario.Text = encabezado;
                mostrarSolicitudes();
            }
        }

        public void mostrarSolicitudes()
        {

            String query = "SELECT c.idCuenta, u.nombre, c.saldo, s.monto, s.descripcion, s.estado FROM Solicitud_Prestamo s, Cuenta c, Usuario u WHERE s.idCuenta = c.idCuenta and c.idUsuario = u.idUsuario;";
            MySqlConnection conn = c.getConection();
            if (conn != null)
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    Response.Write("</br></br></br></br>");
                    Response.Write("<center><table border=3px bordercolor=white>");
                    Response.Write("<tr>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center> No. CUENTA </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> CLIENTE </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> SALDO DE LA CUENTA </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> MONTO SOLICITADO </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> DESCRIPCION </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> ESTADO </center></font></td>");
                    Response.Write("</tr>");
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Response.Write("<tr>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[0].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[1].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[2].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[3].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[4].ToString() + "</center></font></td>");
                            if (reader[5].ToString().Equals("0"))
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center> Pendiente </center></font></td>");
                            }
                            else if(reader[5].ToString().Equals("2"))
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center> Rechazado </center></font></td>");
                            }
                            else
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center>Aceptada</center></font></td>");
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
    }
}