using ServiciosAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ServiciosAhorcado.Modelo
{
    public class GameUtil
    {
        public static String palabraSeleccionada { set; get; }
        public static List<char> arrayPalabra = new List<char>();
        public static Boolean juegoFinalizado = false;

        public static void IniciarPartida(string palabra)
        {
            palabraSeleccionada = palabra.ToLower();
            for (int i = 0; i < palabraSeleccionada.Length; i++)
            {
                arrayPalabra.Add(palabraSeleccionada[i]);
            }
        }

        public static List<int> verificarLetra(char letra)
        {
            List<int> coincidencias = new List<int>();
            IEnumerable<char> stringQuery = from ch in palabraSeleccionada
                                            where ch == letra
                                            select ch;
            foreach (char ch in stringQuery)
            {
                coincidencias.Append(arrayPalabra.IndexOf(ch));
                System.Diagnostics.Debug.WriteLine(arrayPalabra.IndexOf(ch));
                arrayPalabra.RemoveAt(arrayPalabra.IndexOf(ch));
            }
            return coincidencias;
        }

        public static DatosJuego verificarPalabra(String palabraAdivinada)
        {
            DatosJuego datos = new DatosJuego();
            if (palabraAdivinada.Equals(palabraSeleccionada))
            {
                datos.juegoFinalizado = true;
            } else
            {
                datos.juegoFinalizado = false;
            }
            return datos;
        }

    }

    
}