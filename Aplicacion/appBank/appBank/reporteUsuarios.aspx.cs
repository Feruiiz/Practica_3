using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class reporteUsuarios : System.Web.UI.Page
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

            String query = "SELECT u.nombre, u.nickname, u.correo,u.contraseña,u.idrolUsuario,c.idtipoCuenta,c.fecha_creacion,c.saldo FROM Usuario u, Cuenta c WHERE c.idUsuario = u.idUsuario;";
            MySqlConnection conn = c.getConection();
            if (conn != null)
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    Response.Write("</br></br></br></br>");
                    Response.Write("<center><table border=3px bordercolor=white>");
                    Response.Write("<tr>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center>NOMBRE</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>NICKNAME</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>CORREO ELECTRONICO</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>CONTRASEÑA</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>TIPO DE USUARIO</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>TIPO DE CUENTA</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>FECHA Y HORA DE CREACION</center></font></td><td bgcolor=#005d8c><font color=white size=4px><center>SALDO ACTUAL</center></font></td>");
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
                            if (reader[4].ToString().Equals("1"))
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center>Administrado</center></font></td>");
                            }
                            else
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center>Cliente</center></font></td>");
                            }
                            if (reader[5].ToString().Equals("1"))
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center>Ahorro</center></font></td>");
                            }
                            else
                            {
                                Response.Write("<td bgcolor=#005d8c><font color=white><center>Monetaria</center></font></td>");
                            }
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[6].ToString() +"</center></font></td>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[7].ToString() + "</center></font></td>");
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