using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class Partida
    {

        int idPartida { get; set; }

        int oportunidades { get; set; }

        DateTime Fecha { get; set; }

        String categoria { get; set; }


    }
}