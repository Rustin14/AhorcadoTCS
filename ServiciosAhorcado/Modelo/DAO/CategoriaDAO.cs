using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosAhorcado.Modelo.Poco;
using MySql.Data.MySqlClient;

namespace ServiciosAhorcado.Modelo.DAO
{
    public class CategoriaDAO
    {

        public static List<Categoria> obtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            RespuestaLogin respuesta = new RespuestaLogin();
            MySqlConnection conexionDB = ConnectionUtil.obtenerConexion();

            if (conexionDB != null)
            {
                string query = "SELECT * FROM categoria";
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

                while(respuestaBD.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.idCategoria = (respuestaBD.IsDBNull(0) ? 0 : respuestaBD.GetInt32(0));
                    categoria.nombreCategoria = (respuestaBD.IsDBNull(1) ? "" : respuestaBD.GetString(1));
                    categorias.Add(categoria);
                }
            }
            else
            {
                Console.WriteLine("No es posible establecer conexión a la base de datos.");
            }

            return categorias;
        }

    }
}