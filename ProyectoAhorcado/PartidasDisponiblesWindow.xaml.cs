using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ProyectoAhorcado.ServiciosAhorcado;

namespace ProyectoAhorcado
{
    /// <summary>
    /// Lógica de interacción para PartidasDisponiblesWindow.xaml
    /// </summary>
    public partial class PartidasDisponiblesWindow : Window
    {

        Usuario usuarioIniciado = new Usuario();
        ServiciosAhorcado.AhorcadoSVCClient client = new ServiciosAhorcado.AhorcadoSVCClient();
        List<Usuario> usuarios = new List<Usuario>();

        public PartidasDisponiblesWindow(Usuario usuario)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            System.Diagnostics.Debug.WriteLine("Usuario: " + usuarioIniciado.nombre);
            nombreUsuarioLabel.Content = usuarioIniciado.nombre + " " + usuarioIniciado.apellidoPaterno;
            obtenerUsuarios();
            obtenerPartidasDisponibles();
        }

        public void obtenerUsuarios()
        {
            usuarios = client.obtenerUsuariosRegistrados();
        }

        public void obtenerPartidasDisponibles()
        {
            List<Partida> partidas = new List<Partida>();
            partidas = client.obtenerPartidasDisponibles();

            for (int i=0; i<partidas.Count; i++)
            {
                for (int j = 0; j < usuarios.Count; j++)
                {
                    if (partidas[i].idUsuarioRetador == usuarios[j].idUsuario)
                    {
                        partidas[i].nombreUsuarioRetador = usuarios[j].nombreUsuario;
                    }
                }
            }
            for (int i=0; i<partidas.Count; i++)
            {
                dtGridPartidas.Items.Add(partidas[i]);
            }
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
            menuInicio.Show();
            this.Close();
        }

        private void btnUnirse(object sender, RoutedEventArgs e)
        {
            Partida partida = (Partida)dtGridPartidas.SelectedItem;
            if (partida == null)
            {
                MensajesAlerta mensajesAlerta = new MensajesAlerta();
                mensajesAlerta.mensajeAlerta("Seleccione una partida para entrar.", "Unirse a partida");
            } else
            {
                Palabra palabra = client.obtenerPalabraPorID(partida.palabraId);
                Mensaje mensaje = client.actualizarIDRetador(usuarioIniciado.idUsuario, partida.idPartida);
                if (!mensaje.Error)
                {
                    mensaje = client.actualizarEstadoPartida(partida.idPartida, "Jugando");
                    if (!mensaje.Error)
                    {
                        VentanaAhorcado ventanaAhorcado = new VentanaAhorcado(palabra, usuarioIniciado, partida);
                        ventanaAhorcado.Show();
                        this.Close();
                    }
                } else
                {
                    MensajesAlerta mensajes = new MensajesAlerta();
                    mensajes.mensajeAlerta("No fue posible unirse a la partida", "Unirse a partida");
                    MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
                    menuInicio.Show();
                    this.Close();
                }
            }
        }


    }
}
