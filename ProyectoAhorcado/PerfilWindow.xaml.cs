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
    /// Lógica de interacción para PerfilWindow.xaml
    /// </summary>
    public partial class PerfilWindow : Window
    {

        Usuario usuarioIniciado = new Usuario();

        public PerfilWindow(Usuario usuario)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            System.Diagnostics.Debug.WriteLine("Usuario: " + usuarioIniciado.nombre);
            labelNombre.Content = usuarioIniciado.nombre;
            labelApellidos.Content = usuarioIniciado.apellidoPaterno + " " + usuarioIniciado.apellidoPaterno;
            labelNombreUsuario.Content = usuarioIniciado.nombreUsuario;
            labelEmail.Content = usuarioIniciado.correoElectronico;
        }

        private void BtnRegresar(object sender, RoutedEventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
            menuInicio.Show();
            this.Close();
        }

        private void BtnActualizarDatos(object sender, RoutedEventArgs e)
        {
            RegistroWindow registroWindow = new RegistroWindow();
            registroWindow.ventanaLabel.Content = "Actualizar";
            registroWindow.registrarButton.Content = "Actualizar";
            registroWindow.Show();
            this.Close();
        }
    }
}
