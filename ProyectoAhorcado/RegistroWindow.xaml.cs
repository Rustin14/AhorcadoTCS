using ProyectoAhorcado.ServiciosAhorcado;
using ProyectoAhorcado.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

            if (validarCamposTexto().camposVacios == false)
            {
                if (validarCamposTexto().caracteresInvalidos == false)
                {
                    
                    if (confirmarContrasena(contrasenaBox.Password, confirmarContrasenaBox.Password))
                    {
                        usuario.nombre = nombreTextBox.Text;
                        usuario.apellidoPaterno = apellidoPTextBox.Text;
                        usuario.apellidoMaterno = apellidoMTextBox.Text;
                        if (validarCorreoElectronico(emailTextBox.Text))
                        {
                            usuario.correoElectronico = emailTextBox.Text;
                        }
                        else
                        {
                            mensajesAlerta.mensajeAlerta("Correo electrónico inválido.", "Registro de usuario");
                            return bandera;
                        }
                        usuario.nombreUsuario = nombreUsuarioTextBox.Text;
                        usuario.contrasena = contrasenaBox.Password;
                        Mensaje mensaje = cliente.RegistrarUsuario(usuario);
                        if (!mensaje.Error)
                        {
                            mensajesAlerta.mensajeExito(mensaje.MensajeRespuesta, "Registro de usuario");
                            usuarioRegistrado = usuario;
                            bandera = true;
                        }
                        else
                        {
                            mensajesAlerta.mensajeAlerta(mensaje.MensajeRespuesta, "Registro de usuario");
                        }
                    }
                    else
                    {
                        mensajesAlerta.mensajeAlerta("Las contraseñas no son iguales. Verificar.", "Registro de usuario");
                    }
                } else
                {
                    mensajesAlerta.mensajeAlerta("Campos inválidos. Verificar.", "Registro de usuario");
                }
            } else
            {
                mensajesAlerta.mensajeAlerta("Llenar todos los campos. Verificar.", "Registro de usuario");
            }
            return bandera;
        }

        public Match validarTexto(string cadena)
        {
            string regex = "^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$";
            Match match = Regex.Match(cadena, regex, RegexOptions.IgnoreCase);
            return match;
        }

        public Boolean validarCorreoElectronico(String email)
        {
            Boolean bandera = true;
            try
            {
                email = new MailAddress(email).Address;
            }
            catch (FormatException)
            {
                bandera = false;
            }
            return bandera;
        }

        public Boolean confirmarContrasena (string contrasena, string confirmacionContrasena)
        {
            return String.Equals(contrasena, confirmacionContrasena);
        }

        public Validacion validarCamposTexto()
        {
            Validacion validaciones = new Validacion();
            if (!String.IsNullOrWhiteSpace(nombreTextBox.Text) && !String.IsNullOrWhiteSpace(apellidoPTextBox.Text)
                && !String.IsNullOrWhiteSpace(apellidoMTextBox.Text)  && !String.IsNullOrWhiteSpace(emailTextBox.Text) 
                && !String.IsNullOrWhiteSpace(nombreUsuarioTextBox.Text) && !String.IsNullOrWhiteSpace(contrasenaBox.Password) 
                && !String.IsNullOrWhiteSpace(confirmarContrasenaBox.Password))
            {
                if (validarTexto(nombreTextBox.Text).Success && validarTexto(apellidoPTextBox.Text).Success 
                    && validarTexto(apellidoMTextBox.Text).Success && validarTexto(nombreUsuarioTextBox.Text).Success && validarCorreoElectronico(emailTextBox.Text))
                {
                    
                } else
                {
                    validaciones.caracteresInvalidos = true;
                }
            } else
            {
                validaciones.camposVacios = true;
            }
            return validaciones;
        }

        private void BtnRegistrar(object sender, RoutedEventArgs e)
        {
            if (registro())
            {
                MenuInicio menuInicio = new MenuInicio(usuarioRegistrado);
                menuInicio.Show();
                this.Close();
            }
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

