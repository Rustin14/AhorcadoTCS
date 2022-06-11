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
using ServiciosAhorcado.Modelo.Poco;

namespace ProyectoAhorcado
{
    /// <summary>
    /// Lógica de interacción para PartidasDisponiblesWindow.xaml
    /// </summary>
    public partial class PartidasDisponiblesWindow : Window
    {

        Usuario usuarioIniciado = new Usuario();

        public PartidasDisponiblesWindow(Usuario usuario)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            System.Diagnostics.Debug.WriteLine("Usuario: " + usuarioIniciado.nombre);
            nombreUsuarioLabel.Content = usuarioIniciado.nombre + " " + usuarioIniciado.apellidoPaterno;
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
            menuInicio.Show();
            this.Close();
        }
    }
}
