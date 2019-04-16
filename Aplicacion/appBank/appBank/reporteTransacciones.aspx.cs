using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;

namespace appBank
{
    public partial class reporteTransacciones : System.Web.UI.Page
    {
        Conexion c = new Conexion();
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
            }
            this.cuenta = c.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + Session["idCuenta"].ToString() + ";");
            this.valorActual = Convert.ToDouble(cuenta[0].dato2.ToString());
            saldoActual.Text = "Saldo actual: Q " + valorActual.ToString("N2");
            mostrarTransacciones();
        }

        public void mostrarTransacciones()
        {

            String query = "SELECT b.nombre,a.monto,a.fecha,a.cuentaEmisor,a.cuentaReceptor, u.nombre FROM Transaccion a, Tipo_Transaccion b, Cuenta c, Usuario u WHERE b.idtipoTransaccion = a.tipoTransaccion and a.cuentaReceptor = c.idCuenta and c.idUsuario = u.idUsuario and cuentaEmisor = " + Session["idCuenta"].ToString() + ";";
            MySqlConnection conn = c.getConection();
            if (conn != null)
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    Response.Write("</br></br></br></br>");
                    Response.Write("<center><table border=3px bordercolor=white>");
                    Response.Write("<tr>");
                    Response.Write("<td bgcolor=#005d8c><font color=white size=4px><center> DESCRIPCION </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> MONTO </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> FECHA Y HORA </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> No. CUENTA INVOLUCRADA </center></font></td><td bgcolor=#005d8c><font color=white size=4px><center> Del Usuario </center></font></td>");
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
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[4].ToString() + "</center></font></td>");
                            Response.Write("<td bgcolor=#005d8c><font color=white><center>" + reader[5].ToString() + "</center></font></td>");
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

        protected void boton_Click(object sender, EventArgs e)
        {
            CrearPDF();
        }

        public void CrearPDF()
        {
            try
            {
                StreamWriter escribir = new StreamWriter("C:/PDF/Transacciones.report", false);

                String query = "SELECT b.nombre,a.monto,a.fecha,a.cuentaEmisor,a.cuentaReceptor, u.nombre FROM Transaccion a, Tipo_Transaccion b, Cuenta c, Usuario u WHERE b.idtipoTransaccion = a.tipoTransaccion and a.cuentaReceptor = c.idCuenta and c.idUsuario = u.idUsuario and cuentaEmisor = " + Session["idCuenta"].ToString() + ";";
                MySqlConnection conn = c.getConection();
                if (conn != null)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    try
                    {
                        escribir.WriteLine("DESCRIPCION                   MONTO        FECHA Y HORA             No. CUENTA INVOLUCRADA     Del Usuario");
                        cmd.Connection = conn;
                        cmd.CommandText = query;
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                escribir.Write(reader[0].ToString());
                                for (int i = reader[0].ToString().Count(); i < 30; i++)
                                {
                                    escribir.Write(" ");
                                }
                                double monto = Convert.ToDouble(reader[1].ToString());
                                escribir.Write(monto.ToString("N2"));
                                for (int i = reader[1].ToString().Count(); i < 10; i++)
                                {
                                    escribir.Write(" ");
                                }
                                escribir.Write(reader[2].ToString());
                                for (int i = reader[2].ToString().Count(); i < 35; i++)
                                {
                                    escribir.Write(" ");
                                }
                                escribir.Write(reader[4].ToString());
                                for (int i = reader[4].ToString().Count(); i < 17; i++)
                                {
                                    escribir.Write(" ");
                                }
                                escribir.Write(reader[5].ToString() + "\n");
                            }
                            escribir.Write("\n\n" + saldoActual.Text);
                        }
                        conn.Close();


                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
                        conn.Close();
                    }
                }

                escribir.Close();
                Response.Write("<script>window.alert('Se ha creado el archivo con exito.');</script>");
            }
            catch (Exception)
            {

                Response.Write("<script>window.alert('ERROR: debe de crear una carpeta llamada: PDF en el disco C.');</script>");
            }
        }
    }
}