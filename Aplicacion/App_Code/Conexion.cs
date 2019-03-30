using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySqlX.XDevAPI;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    public Conexion()
    {
        
    }

    public bool probarConexion()
    {
        MySqlConnection con;
        String servidor = "ayd1db.c1nkrylvqoo0.us-east-2.rds.amazonaws.com";
        String puerto = "3306";
        String usuario = "ayd1db";
        String password = "ayd12345678";
        String database = "ayd1db";

        //Cadena de conexion
        
        String cadenaConexion = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", servidor, puerto, usuario, password, database);

        try
        {
            con = new MySqlConnection(cadenaConexion);
            con.Open();//se abre la conexion
            if (con.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("conexion establecida");
                return true;
            }
            else
            {
                Console.WriteLine("Fallo conexion");
                return false;
            }

        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            return false;
        }

    }


    //este metodo es reutilizable, ya que solo son para consultas que no devuelven valores
    //codigo 201503984
    //este metodo servira para ejecutar una consulta
    // como parametro recibira la consulta insert, alter table, etc

    public bool Ejecutar201503984(String sql)
    {
        MySqlConnection conn;
        String servidor = "ayd1db.c1nkrylvqoo0.us-east-2.rds.amazonaws.com";
        String puerto = "3306";
        String usuario = "ayd1db";
        String password = "ayd12345678";
        String database = "ayd1db";

        //Cadena de conexion

        String cadenaConexion = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", servidor, puerto, usuario, password, database);

        try
        {
            conn = new MySqlConnection(cadenaConexion);

            String output = null;
            try
            {
                //abrimos nuestra conexion a la base de datos
                conn.Open();

                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

                //Ejecutamos nuestro sql
                sqlAdapter.InsertCommand = new MySqlCommand(sql, conn);
                sqlAdapter.InsertCommand.ExecuteNonQuery();
                output = "si lo realizo"; //bandera si lo realizo o no

                //cerramos nuestra base de datos
                conn.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
                //error
            }
            if (output != null) // si es nulo fue porque no se realizo la consulta correctamente
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}