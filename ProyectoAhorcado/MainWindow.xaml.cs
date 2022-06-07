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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoAhorcado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ServiciosAhorcado.AhorcadoSVCClient client = new ServiciosAhorcado.AhorcadoSVCClient();
        RespuestaLogin respuesta = new RespuestaLogin();
        Usuario usuarioIniciado = new Usuario();

        private void iniciarSesion ()
        {
            if (!String.IsNullOrWhiteSpace(emailTextBox.Text) && !String.IsNullOrWhiteSpace(contrasenaBox.Password))
            {
                string email = emailTextBox.Text;
                string password = contrasenaBox.Password;

                respuesta = client.LogIn(email, password);
                if (respuesta.UsuarioCorrecto == true)
                {
                    usuarioIniciado = respuesta.InformacionUsuario;
                    System.Diagnostics.Debug.WriteLine(usuarioIniciado.nombre);
                    MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
                    menuInicio.Show();
                    this.Close();
                }
                else
                {
                    MensajesAlerta alerta = new MensajesAlerta();
                    alerta.mensajeAlerta(respuesta.mensaje, "Inicio de sesión");
                }
            } else
            {
                MensajesAlerta alerta = new MensajesAlerta();
                alerta.mensajeAlerta("No dejar campos vacíos.", "Inicio de sesión");
            }
        }

        private void BtnIngresar(object sender, RoutedEventArgs e)
        {
            iniciarSesion();
        }

        private void BtnRegistrar(object sender, RoutedEventArgs e)
        {
            RegistroWindow registroWindow = new RegistroWindow();
            registroWindow.Show();
            this.Close();
        }
    }
}
