using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class Usuario
    {

        public int idUsuario { get; set; }

        public String correoElectronico { get; set; }

        public String nombre { get; set; }

        public String apellidoPaterno {get; set; }

        public String apellidoMaterno { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string nombreUsuario { get; set; }

        public String contrasena { get; set; }



    }
}