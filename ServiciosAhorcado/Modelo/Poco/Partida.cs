using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class Partida
    {

        public int idPartida { get; set; }

        public int oportunidades { get; set; }

        public DateTime Fecha { get; set; }

        public int idUsuarioRetador { get; set; }

        public int idUsuario { get; set; }

        public int palabraId { get; set; }

        public int categoriaId { get; set; }


    }
}