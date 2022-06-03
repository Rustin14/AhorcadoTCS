using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class DatosJuego
    {

        public String[] arrayLetras { get; set; }

        public int partesAhorcado { get; set; }

        public Boolean juegoFinalizado { get; set; }

    }
}