using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosAhorcado.Modelo.Poco;
using MySql.Data.MySqlClient;

namespace ServiciosAhorcado.Modelo.DAO {
    public class PuntajeGlobalDAO 
    {
       public static List<PuntajeGlobal> ObtenerPuntajeGlobal(int idUsuario) {
            List<PuntajeGlobal> puntajes = new List<PuntajeGlobal>();
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();
            if (conexionDB != null) 
            {
                string query = "SELECT * FROM puntaje_global WHERE idUsuario = @idUsuario";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionDB);
                mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                mySqlCommand.Prepare();
                MySqlDataReader respuestaBD = null;
                try {
                    respuestaBD = mySqlCommand.ExecuteReader();
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                if (respuestaBD.Read()) {
                    PuntajeGlobal puntaje = new PuntajeGlobal();
                    puntaje.idPuntaje = (respuestaBD.IsDBNull(0) ? 0 : respuestaBD.GetInt32(0));
                    puntaje.puntos = (respuestaBD.IsDBNull(1) ? 0 : respuestaBD.GetInt32(1));
                    puntaje.idPartida = (respuestaBD.IsDBNull(2) ? 0 : respuestaBD.GetInt32(2));
                    puntaje.idUsuarioRetador = (respuestaBD.IsDBNull(3) ? 0 : respuestaBD.GetInt32(3));
                    puntaje.idUsuario = (respuestaBD.IsDBNull(4) ? 0 : respuestaBD.GetInt32(4));
                    puntaje.idCategoria = (respuestaBD.IsDBNull(5) ? 0 : respuestaBD.GetInt32(5));
                    puntajes.Add(puntaje);  
                } else 
                {
                    Console.WriteLine("No es posible establecer conexión a la base de datos.");

                }
            }
            return puntajes;
        }

       
    }
}