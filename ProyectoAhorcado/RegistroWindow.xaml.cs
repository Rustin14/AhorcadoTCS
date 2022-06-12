using ProyectoAhorcado.ServiciosAhorcado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para RegistroWindow.xaml
    /// </summary>
    public partial class RegistroWindow : Window
    {

        ServiciosAhorcado.AhorcadoSVCClient cliente = new ServiciosAhorcado.AhorcadoSVCClient();
        Usuario usuarioRegistrado;

        public RegistroWindow()
        {
            InitializeComponent();
        }

        private Boolean registro()
        {
            Boolean bandera = false;
            MensajesAlerta mensajesAlerta = new MensajesAlerta();
            Usuario usuario = new Usuario();

            if (validarCamposTexto() && confirmarContrasena(contrasenaBox.Password, confirmarContrasenaBox.Password))
            {
                usuario.nombre = nombreTextBox.Text;
                usuario.apellidoPaterno = apellidoPTextBox.Text;
                usuario.apellidoMaterno = apellidoMTextBox.Text;
                usuario.correoElectronico = emailTextBox.Text;
                usuario.nombreUsuario = nombreUsuarioTextBox.Text;
                usuario.contrasena = contrasenaBox.Password;
                Mensaje mensaje = cliente.RegistrarUsuario(usuario);
                if (!mensaje.Error)
                {
                    mensajesAlerta.mensajeExito(mensaje.MensajeRespuesta, "Registro de usuario");
                    usuarioRegistrado = usuario;
                    bandera = true;
                } else
                {
                   mensajesAlerta.mensajeAlerta(mensaje.MensajeRespuesta, "Registro de usuario");
                }
            } else
            {
                mensajesAlerta.mensajeAlerta("No dejar campos vacíos.", "Registro de usuario");
            }
            return bandera; 
        }

        public Match validarTexto(string cadena)
        {
            string regex = "/^[A - Za - z] +$/";
            Match match = Regex.Match(cadena, regex, RegexOptions.IgnoreCase);
            return match;
        }

        public Match validarCorreoElectronico(String email)
        {
            String regex = "(?:[a-z0-9!#$%&' * +/=? ^_`{|}~-]+(?:\\.[a-z0 - 9!#$%&'*+/=?^_`{|}~-]+)*|" +
                "\"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*\")" +
                "@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.)" +
                "{3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\\])";
            Match match = Regex.Match(email, regex, RegexOptions.IgnoreCase);
            return match;
        }

        public Boolean confirmarContrasena (string contrasena, string confirmacionContrasena)
        {
            return String.Equals(contrasena, confirmacionContrasena);
        }

        public Boolean validarCamposTexto()
        {
            if (!String.IsNullOrWhiteSpace(nombreTextBox.Text) && !String.IsNullOrWhiteSpace(apellidoPTextBox.Text)
                && !String.IsNullOrWhiteSpace(apellidoMTextBox.Text)  && !String.IsNullOrWhiteSpace(emailTextBox.Text) 
                && !String.IsNullOrWhiteSpace(nombreUsuarioTextBox.Text) && !String.IsNullOrWhiteSpace(contrasenaBox.Password) 
                && !String.IsNullOrWhiteSpace(confirmarContrasenaBox.Password))
            {
                if (validarTexto(nombreTextBox.Text).Success && validarTexto(apellidoPTextBox.Text).Success 
                    && validarTexto(apellidoMTextBox.Text).Success && validarTexto(nombreUsuarioTextBox.Text).Success && validarCorreoElectronico(emailTextBox.Text).Success)
                {
                    return true;
                }
            }
            return false;
        }

        private void BtnRegistrar(object sender, RoutedEventArgs e)
        {
            if (registro())
            {
                MenuInicio menuInicio = new MenuInicio(usuarioRegistrado);
                menuInicio.Show();
                this.Close();
            }
            //if (registrarButton.Content.Equals("Registrar"))
            //{
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();
            //    this.Close();
            //}
            //else
            //{
            //    PerfilWindow perfilWindow = new PerfilWindow();
            //    perfilWindow.Show();
            //    this.Close();
            //}
        }

        private void BtnCancelar(object sender, RoutedEventArgs e)
        {
            if (registrarButton.Content.Equals("Registrar"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                //PerfilWindow perfilWindow = new PerfilWindow();
                //perfilWindow.Show();
                this.Close();
            }
        }
    }
}

