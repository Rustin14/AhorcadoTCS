using MySql.Data.MySqlClient;
using ServiciosAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.DAO
{
    public class PalabraDAO
    {

        public static List<Palabra> ObtenerPalabras()
        {
            List<Palabra> palabras = new List<Palabra>();
            RespuestaLogin respuesta = new RespuestaLogin();
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();

            if (conexionDB != null)
            {
                string query = "SELECT * FROM palabra";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionDB);
                mySqlCommand.Prepare();
                MySqlDataReader respuestaBD = null;
                try
                {
                    respuestaBD = mySqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                while (respuestaBD.Read())
                {
                    Palabra palabra = new Palabra();
                    palabra.idPalabra = (respuestaBD.IsDBNull(0) ? 0 : respuestaBD.GetInt32(0));
                    palabra.categoria = (respuestaBD.IsDBNull(3) ? 0 : respuestaBD.GetInt32(3));
                    palabra.nombre = (respuestaBD.IsDBNull(1) ? "" : respuestaBD.GetString(1));
                    palabra.descripcion = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                    palabras.Add(palabra);
                }
            } else
            {
                Console.WriteLine("No es posible establecer conexión a la base de datos.");
            }
            return palabras;
        }

        public static Palabra obtenerPalabraPorID(int idPalabra)
        {
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();
            Palabra palabra = new Palabra();

            if (conexionDB != null)
            {
                string query = "SELECT * FROM palabra where idPalabra = @idPalabra";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionDB);
                mySqlCommand.Parameters.AddWithValue("@idPalabra", idPalabra);
                mySqlCommand.Prepare();
                MySqlDataReader respuestaBD = null;
                try
                {
                    respuestaBD = mySqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                while (respuestaBD.Read())
                {
                    palabra.idPalabra = (respuestaBD.IsDBNull(0) ? 0 : respuestaBD.GetInt32(0));
                    palabra.categoria = (respuestaBD.IsDBNull(3) ? 0 : respuestaBD.GetInt32(3));
                    palabra.nombre = (respuestaBD.IsDBNull(1) ? "" : respuestaBD.GetString(1));
                    palabra.descripcion = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                }
            }
            else
            {
                Console.WriteLine("No es posible establecer conexión a la base de datos.");
            }
            return palabra;
        }
    }
}