using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class Mensaje
    {

        public Boolean Error { get; set; }

        public String MensajeRespuesta { get; set; }

        public int filasAfectadas { get; set; }

    }
}