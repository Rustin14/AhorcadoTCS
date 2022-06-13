using ProyectoAhorcado.ServiciosAhorcado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoAhorcado
{
    /// <summary>
    /// Lógica de interacción para EsperarJugador.xaml
    /// </summary>
    public partial class EsperarJugador : Window
    {

        Usuario usuarioIniciado = new Usuario();
        Partida partidaCreada = new Partida();
        Palabra palabraSeleccionada = new Palabra();
        ServiciosAhorcado.AhorcadoSVCClient client = new ServiciosAhorcado.AhorcadoSVCClient();

        public EsperarJugador(Usuario usuario, Partida partida, Palabra palabra)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            partidaCreada = partida;
            palabraSeleccionada = palabra;
            Thread hiloUnirse = new Thread(new ThreadStart(unirseAPartida));
            hiloUnirse.Start();
        }

        public void unirseAPartida()
        {
            Partida partida = new Partida();
            partida = client.obtenerPartidaPorID(partidaCreada.idPartida);
            Boolean bandera = false;
            while (bandera == false)
            {
                if (partida.idUsuario == partida.idUsuarioRetador)
                {
                    partida = client.obtenerPartidaPorID(partidaCreada.idPartida);
                    System.Diagnostics.Debug.WriteLine("ID Retador: " + partida.idUsuarioRetador);
                    System.Diagnostics.Debug.WriteLine("ID Usuario: " + partida.idUsuario);
                    bandera = true;
                } else
                {
                    Thread.Sleep(2000);
                }
            }
            abrirPartida();
        }

        public void abrirPartida()
        {
            VentanaAhorcado ventanaAhorcado = new VentanaAhorcado(palabraSeleccionada, usuarioIniciado, partidaCreada);
            ventanaAhorcado.Show();
            this.Close();
        }
    }
}
