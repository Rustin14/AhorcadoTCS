using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class Palabra
    {
        public int idPalabra { get; set; }

        public int categoria { get; set; }

        public String nombre { get; set; }

        public String descripcion { get; set; }



    }
}