using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


public partial class CrearUsuario : System.Web.UI.Page
{

    Conexion c = new Conexion();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*
    public String generateCod() {
        //codigo alphanumerico que generara el random aleaotorio de 
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);

        return finalString;

    }
    */

    protected void boton_Click(object sender, EventArgs e)
    {
        String name, nick, email;
        name = nombre.Text;
        nick = nickname.Text;
        if (nick.Any(char.IsDigit)) {//validar que el nickname contenga un numero
            email = correo.Text;

            if (pass1.Text == pass2.Text)
            {
                if(c.crearUsuario(name, nick, pass1.Text, email))
                {

                    try
                    {
                        //consulta al ultimo dato registrado
                        String codigoUsu = "SELECT  last_insert_id();";
                        String output = "";
                        //Se crea el comando que ejecutaremos en SQL Server
                        MySqlConnection conn = c.getConection();
                        MySqlCommand Comando = new MySqlCommand(codigoUsu, conn);

                        output = Comando.ExecuteScalar().ToString(); //devuelve el numero de filas afectadas
                                                                     //Se crea un lector de datos, en este se almacena los resultados que nos dio sql server al momento de ejecutar el comando
                        MySqlDataReader Lector = Comando.ExecuteReader();
                        //Se repite por cada registro que haya regresado el comando de sql server, hasta que se hayan leido todos los registros
                        String cod = "";
                        while (Lector.Read())
                        {
                            cod = Lector[0].ToString();//leer el primer elemento
                            break;
                        }
                        //Se cierra la conexion, es importante cerrarla
                        conn.Close();

                        try
                        {
                            String query = "SELECT u.idUsuario, u.nombre, u.nickname, u.correo,u.contraseña,u.idrolUsuario,c.idCuenta ";
                            query += "FROM Usuario u, Cuenta c";
                            query += " WHERE u.idUsuario = c.idUsuario AND c.idCuenta = " + cod + ";";

                            List<Datos> usuario = c.Validar_Usuario(query);
                            if (usuario != null)
                            {
                                Session["idUsu"] = usuario[0].dato1;
                                Session["nombreUsu"] = usuario[0].dato2;
                                Session["nicknameUsu"] = usuario[0].dato3;
                                Session["correoUsu"] = usuario[0].dato4;
                                Session["passUsu"] = usuario[0].dato5;
                                Session["rolUsu"] = usuario[0].dato6;
                                Session["idCuenta"] = usuario[0].dato7;
                                Response.Write("<script>window.alert('Se ha registro al sistema');</script>");
                                if (Session["rolUsu"].ToString().Equals("1")) //Administrador
                                {

                                }
                                else if (Session["rolUsu"].ToString().Equals("2")) //Cliente
                                {
                                    Response.Redirect("Inicio.aspx");
                                }
                            }
                            else
                            {
                                Error.Text = "ERROR: el usuario no existe";
                            }

                        }
                        catch (Exception ex){
                            Response.Write("<script>window.alert('trono al buscar al usuario');</script>");
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>window.alert('No se obtuvo el id de la cuenta');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('Ocurrió un error al intentar agregarse a la base de datos');</script>");
                }

            }
            else
            {
                Response.Write("<script>window.alert('Las contraseñas no coinciden');</script>");
            }

        }
        else
        {
            Response.Write("<script>window.alert('Su Nickname debe contener al menos un numero');</script>");
        }
        
    }
}