using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo
{
    public class ConnectionUtil
    {

        private static string SERVER = "127.0.0.1";

        private static string PORT = "3306";

        private static string DATABASE = "ahorcados";

        private static string DB_USER = "root";

        private static string PASSWORD = "Flipper10011";

        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection conexionBD = null;
            string urlConexion = string.Format("server={0};" + "database={1};" +
                                                "username={2};" + "password={3};" +
                                                "port={4};",
                                                SERVER, DATABASE, DB_USER, PASSWORD, PORT);
            conexionBD = new MySqlConnection(urlConexion);
            try
            {
                conexionBD.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conexionBD;
        }


    }
}