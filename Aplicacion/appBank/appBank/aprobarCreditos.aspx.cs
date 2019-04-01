using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBank
{
    public partial class aprobarCreditos : System.Web.UI.Page
    {
        Conexion c = new Conexion();
        LinkedList<Solicitud> l_s = null;

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

                l_s = c.getSolicitudes();
                foreach (Solicitud s in l_s)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = s.nombre_cliente + ";" + s.monto + ";" + s.id_solicitud;
                    listaPrestamos.Items.Add(listItem);
                }
            }

        }
        protected void acept_credito_click(object sender, EventArgs e)
        {
            if (no_solicitud.Text.Length > 0)
            {
                l_s = c.getSolicitudes();
                String monto = "";
                foreach (Solicitud s in l_s)
                {
                    if (s.id_solicitud == int.Parse(no_solicitud.Text.ToString()))
                    {
                        monto = s.monto;
                        break;
                    }
                }
                String comando = "UPDATE Solicitud_Prestamo SET estado = 1 where idSolicitud = " + no_solicitud.Text + ";";
                if (c.Ejecutar201503984(comando))
                {
                    String id_cuenta = "select u.idUsuario from Usuario u, Solicitud_Prestamo s, Cuenta c where s.idSolicitud = " + no_solicitud.Text + " and u.idUsuario = c.idUsuario and c.idCuenta = s.idCuenta;";
                    MySqlConnection conn = c.getConection();
                    if (conn != null)
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        try
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = id_cuenta;
                            String idUsuario = "";
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    idUsuario = reader["idUsuario"].ToString();
                                    break;
                                }
                            }
                            conn.Close();
                            String actualizar = "update Cuenta set saldo = saldo + " + monto + " where idUsuario = " + idUsuario + ";";
                            if (c.Ejecutar201503984(actualizar))
                            {
                                Response.Write("<script>window.alert('Crédito aprobado');</script>");
                                Response.Redirect("aprobarCreditos.aspx");
                            }
                            else
                            {
                                Response.Write("<script>window.alert('Fallo a querer actualizar el credito');</script>");
                            }

                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
                            conn.Close();
                        }
                    }

                }
                else
                {
                    Response.Write("<script>window.alert('Fallo al cambiar la solicitud del prestamo');</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('No ha seleccionado ningun crédito');</script>");
            }
        }

        protected void verSolicitud_click(object sender, EventArgs e)
        {
            String sol = listaPrestamos.SelectedItem.Text;
            String[] words = sol.Split(';');
            int id = int.Parse(words[2].Trim());
            l_s = c.getSolicitudes();
            if (l_s != null)
            {
                foreach (Solicitud s in l_s)
                {
                    if (s.id_solicitud == id)
                    {
                        no_solicitud.Text = id.ToString();
                        cliente.Text = cliente.Text + " " + s.nombre_cliente;
                        descripcion.Text = s.descripcion;
                        monto.Text = monto.Text + " Q." + s.monto;
                        break;
                    }
                }

            }
            else
            {
                Response.Write("<script>window.alert('Lista de solicitudes vacia');</script>");
            }
        }
        protected void rech_credito_click(object sender, EventArgs e)
        {
            if (no_solicitud.Text.Length > 0)
            {
                //estado 2 -> rechazado
                String comando = "UPDATE Solicitud_Prestamo SET estado = 2 where idSolicitud = " + no_solicitud.Text + ";";
                if (c.Ejecutar201503984(comando))
                {
                    Response.Write("<script>window.alert('Se ha rechazado el credito');</script>");
                    Response.Redirect("aprobarCreditos.aspx");
                }
                else
                {
                    Response.Write("<script>window.alert('Fallo al intentar rechazar el credito');</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('No ha seleccionado ningun credito');</script>");
            }
        }

    }
}