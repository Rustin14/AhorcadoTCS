using ProyectoAhorcado.ServiciosAhorcado;
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

namespace ProyectoAhorcado
{
    /// <summary>
    /// Lógica de interacción para MenuInicio.xaml
    /// </summary>
    public partial class MenuInicio : Window
    {

        Usuario usuarioIniciado = new Usuario();

        public MenuInicio(Usuario usuario)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            System.Diagnostics.Debug.WriteLine("Usuario: " + usuarioIniciado.nombre);
            nombreUsuarioLabel.Content = usuarioIniciado.nombre + " " + usuarioIniciado.apellidoPaterno;
        }

        private void BtnPerfil(object sender, RoutedEventArgs e)
        {
            PerfilWindow perfilWindow = new PerfilWindow(usuarioIniciado);
            perfilWindow.Show();
            this.Close();
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCrearPartida(object sender, RoutedEventArgs e)
        {
            CrearPartidaWindow crearPartidaWindow = new CrearPartidaWindow(usuarioIniciado);
            crearPartidaWindow.Show();
            this.Close();
        }

        private void btnUnirsePartida(object sender, RoutedEventArgs e)
        {
            PartidasDisponiblesWindow partidasDisponiblesWindow = new PartidasDisponiblesWindow(usuarioIniciado);
            partidasDisponiblesWindow.Show();
            this.Close();
        }
    }
}
