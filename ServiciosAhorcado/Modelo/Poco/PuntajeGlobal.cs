using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo.Poco
{
    public class PuntajeGlobal
    {
        public int idPuntaje { get; set; }
        public int puntos { get; set; }
        public int idPartida { get; set; }
        public int idUsuarioRetador { get; set; }
        public int idUsuario { get; set; }
        public int idCategoria { get; set; }
    }
}