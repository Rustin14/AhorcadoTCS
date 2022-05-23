using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class RespuestaLogin
    {

        public Boolean UsuarioCorrecto { get; set; }

        public string mensaje { get; set; }

        public Usuario InformacionUsuario { get; set; }

    }
}