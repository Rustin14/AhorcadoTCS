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
    }
}
