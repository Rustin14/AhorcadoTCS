using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo
{
    public class GameUtil
    {
        public String letraSeleccionada { get; set; }
        public String palabraSeleccionada { set; get; }
        int partesAhorcado = 0;

        public void IniciarPartida(string palabra)
        {
            palabraSeleccionada = palabra;
            Boolean juegoFinalizado = false;
            while (partesAhorcado < 6 || juegoFinalizado == false)
            {
               
            }
        }

        public Char[] verificarLetra(Char[] palabra)
        {
            if (letraSeleccionada.IndexOf(palabraSeleccionada, StringComparison.CurrentCultureIgnoreCase) > 0)
            {

            }
            else if (letraSeleccionada.IndexOf(palabraSeleccionada, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                partesAhorcado++;
            }
        }

    }

    
}