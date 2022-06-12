using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosAhorcado.Modelo.Poco;
using MySql.Data.MySqlClient;

namespace ServiciosAhorcado.Modelo.DAO
{
    public class PartidaDAO
    {

        public static List<Partida> obtenerPartidasDisponibles()
        {
            List<Partida> partidas= new List<Partida>();
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();

            if (conexionDB != null)
            {
                string query = "SELECT * FROM partida";
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
                if (respuestaBD.Read())
                {
                    Partida partida= new Partida();
                    partida.idPartida = (respuestaBD.IsDBNull(0) ? 0 : respuestaBD.GetInt32(0));
                    partida.oportunidades = (respuestaBD.IsDBNull(1) ? 0 : respuestaBD.GetInt32(1));
                    partida.Fecha = DateTime.Parse((respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2)));
                    partida.idUsuarioRetador = (respuestaBD.IsDBNull(3) ? 0 : respuestaBD.GetInt32(3));
                    partida.idUsuario = (respuestaBD.IsDBNull(4) ? 0 : respuestaBD.GetInt32(4));
                    partida.palabraId = (respuestaBD.IsDBNull(5) ? 0 : respuestaBD.GetInt32(5));
                    partida.categoriaId = (respuestaBD.IsDBNull(6) ? 0 : respuestaBD.GetInt32(6));
                    partidas.Add(partida);
                }
            }
            else
            {
                Console.WriteLine("No es posible establecer conexión a la base de datos.");
            }
            return partidas;
        }

        public static Mensaje actualizarEstadoDePartida(int idPartida, string estado)
        {
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();
            Mensaje respuesta = new Mensaje();
            if (conexionDB != null)
            {
                string query = "UPDATE partida SET estado=@estado WHERE idPartida = @idPartida";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionDB);
                mySqlCommand.Parameters.AddWithValue("@estado", estado);
                mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                mySqlCommand.Prepare();
                String mensaje = "";
                int filasAfectadas = 0;
                try
                {
                    filasAfectadas = mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (filasAfectadas == -1)
                {
                    mensaje = "No fue posible realizar la operación. Intente más tarde.";
                    respuesta.Error = true;
                } else
                {
                    mensaje = "Actualización de estado exitosa.";
                    respuesta.Error = false;

                }
                respuesta.MensajeRespuesta = mensaje;
                respuesta.filasAfectadas = filasAfectadas;
            } else
            {
                respuesta.Error = true;
                respuesta.MensajeRespuesta = "No fue posible acceder a la base de datos. Intente más tarde.";
                respuesta.filasAfectadas = 0;
            }
            return respuesta;
        }

            public static Mensaje crearPartida(Partida partidaNueva)
        {
            Mensaje mensaje = new Mensaje();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            int filasAfectadas = 0;

            if(conexionBD != null)
            {
                string query = "INSERT INTO Partida (idPartida, oportunidades, fecha, idUsuarioRetador, idUsuario, idPalabra, idCategoria) " +
                    "VALUES (@idPartida, @oportunidades, @fecha, @idUsuarioRetador, @idUsuario, @idPalabra, @idCategoria)";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionBD);
                mySqlCommand.Parameters.AddWithValue("@idPartida", partidaNueva.idPartida);
                mySqlCommand.Parameters.AddWithValue("@oportunidades", partidaNueva.oportunidades);
                mySqlCommand.Parameters.AddWithValue("@fecha", partidaNueva.Fecha);
                mySqlCommand.Parameters.AddWithValue("@idUsuarioRetador", partidaNueva.idUsuarioRetador);
                mySqlCommand.Parameters.AddWithValue("@idUsuario", partidaNueva.idUsuario);
                mySqlCommand.Parameters.AddWithValue("@idPalabra", partidaNueva.palabraId);
                mySqlCommand.Parameters.AddWithValue("@idCategoria", partidaNueva.categoriaId);
                mySqlCommand.Prepare();
                try
                {
                    filasAfectadas = mySqlCommand.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    mensaje.Error = true;
                    mensaje.MensajeRespuesta = ex.Message;
                }
                if (filasAfectadas > 0)
                {
                    mensaje.Error = false;
                    mensaje.MensajeRespuesta = "Usuario insertado correctamente.";
                    mensaje.filasAfectadas = filasAfectadas;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.MensajeRespuesta = "Ocurrió un error, intente más tarde.";
                }
            }
            else
            {
                mensaje.Error = true;
                mensaje.MensajeRespuesta = "Por el momento no hay conexión a los servicios.";
            }
            return mensaje;
        }

    }
}