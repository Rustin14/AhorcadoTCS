using MySql.Data.MySqlClient;
using ServiciosAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.DAO
{
    public class UsuarioDAO
    {
        
        public static RespuestaLogin iniciarSesion(string username, string password)
        {
            RespuestaLogin respuesta = new RespuestaLogin();
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();
            if (conexionDB != null)
            {
                string query = "SELECT * FROM usuario WHERE correoElectronico = @email and contrasena = @password;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionDB);
                mySqlCommand.Parameters.AddWithValue("@email", username);
                mySqlCommand.Parameters.AddWithValue("@password", password);
                mySqlCommand.Prepare();
                MySqlDataReader respuestaBD = null;
                try
                {
                    respuestaBD = mySqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    respuesta.UsuarioCorrecto = false;
                    respuesta.mensaje = ex.Message;
                }
                if (respuestaBD.Read())
                {
                    // Usuario existe con esas credenciales
                    respuesta.UsuarioCorrecto = true;
                    respuesta.mensaje = "Consulta realizada correctamente.";
                    Usuario usuario = new Usuario();
                    usuario.idUsuario = (respuestaBD.IsDBNull(0) ? 0 : respuestaBD.GetInt32(0));
                    usuario.correoElectronico = (respuestaBD.IsDBNull(1) ? "" : respuestaBD.GetString(1));
                    usuario.nombre = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                    usuario.apellidoPaterno = (respuestaBD.IsDBNull(3) ? "" : respuestaBD.GetString(3));
                    usuario.apellidoMaterno = (respuestaBD.IsDBNull(4) ? "" : respuestaBD.GetString(4));
                    DateTime dateTime = DateTime.Now;
                    usuario.fechaNacimiento = (respuestaBD.IsDBNull(5) ? dateTime : respuestaBD.GetDateTime(5));
                    usuario.contrasena = (respuestaBD.IsDBNull(6) ? "" : respuestaBD.GetString(6));
                    respuesta.InformacionUsuario = usuario;

                }
                else
                {
                    // Usuario no existe con esas credenciales
                    respuesta.UsuarioCorrecto = false;
                    respuesta.mensaje = "Usuario y/o contraseña incorrectos.";

                }
            }
            else
            {
                respuesta.UsuarioCorrecto = false;
                respuesta.mensaje = "No se puede acceder en este momento, intente más tarde.";
            }
            return respuesta;
        }

        public static Mensaje insertarUsuario(Usuario usuarioRegistro)
        {
            Mensaje mensaje = new Mensaje();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            int filasAfectadas = 0;

            if (conexionBD != null)
            {
                string query = "INSERT INTO usuario (correoElectronico, nombre, aPaterno, aMaterno, fechaNacimiento, nombreUsuario, contrasena) " +
                    "VALUES (@email, @nombre, @aPaterno, @aMaterno, @fechaNacimiento, @nombreUsuario, @contrasena);";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionBD);
                mySqlCommand.Parameters.AddWithValue("@email", usuarioRegistro.correoElectronico);
                mySqlCommand.Parameters.AddWithValue("@nombre", usuarioRegistro.nombre);
                mySqlCommand.Parameters.AddWithValue("@aPaterno", usuarioRegistro.apellidoPaterno);
                mySqlCommand.Parameters.AddWithValue("@aMaterno", usuarioRegistro.apellidoMaterno);
                mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", usuarioRegistro.fechaNacimiento);
                mySqlCommand.Parameters.AddWithValue("@nombreUsuario", usuarioRegistro.nombreUsuario);
                mySqlCommand.Parameters.AddWithValue("@contrasena", usuarioRegistro.contrasena);
                mySqlCommand.Prepare();
                try
                {
                    filasAfectadas = mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
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

        public static Mensaje modificarUsuario(string correoUsuario, Usuario nuevoDatosUsuario)
        {
            Mensaje mensaje = new Mensaje();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            int filasAfectadas = 0;
            if (conexionBD != null)
            {
                string query = "UPDATE usuario SET ,nombre = @nombre, aPaterno = @aPaterno, aMaterno = @aMaterno, fechaNacimiento = @fechaNacimiento," +
                    "nombreUsuario = @nombreUsuario, contrasena = @contrasena WHERE correoElectronico = @email";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conexionBD);
                mySqlCommand.Parameters.AddWithValue("@nombre", nuevoDatosUsuario.nombre);
                mySqlCommand.Parameters.AddWithValue("@aPaterno", nuevoDatosUsuario.apellidoPaterno);
                mySqlCommand.Parameters.AddWithValue("@aMaterno", nuevoDatosUsuario.apellidoMaterno);
                mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", nuevoDatosUsuario.fechaNacimiento);
                mySqlCommand.Parameters.AddWithValue("@nombreUsuario", nuevoDatosUsuario.nombreUsuario);
                mySqlCommand.Parameters.AddWithValue("@contrasena", nuevoDatosUsuario.contrasena);
                mySqlCommand.Parameters.AddWithValue("@email", nuevoDatosUsuario.correoElectronico);
                mySqlCommand.Prepare();
                try
                {
                    filasAfectadas = mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
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