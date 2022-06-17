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
        ServiciosAhorcado.AhorcadoSVCClient client = new ServiciosAhorcado.AhorcadoSVCClient();
        List<Usuario> usuarios = new List<Usuario>();


        public PerfilWindow(Usuario usuario)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            System.Diagnostics.Debug.WriteLine("Usuario: " + usuarioIniciado.nombre);
            labelNombre.Content = usuarioIniciado.nombre;
            labelApellidos.Content = usuarioIniciado.apellidoPaterno + " " + usuarioIniciado.apellidoMaterno;
            labelEmail.Content = usuarioIniciado.correoElectronico;
            labelNombreUsuario.Content = usuarioIniciado.nombreUsuario;
            obtenerUsuarios();
            obtenerPuntajeGlobal();
        }

        public void obtenerUsuarios() {
            usuarios = client.obtenerUsuariosRegistrados();
        }


        public void obtenerPuntajeGlobal() {
            List<PuntajeGlobal> puntajes = new List<PuntajeGlobal>();
            puntajes = client.obtenerPuntajeGlobal(usuarioIniciado.idUsuario);

            for (int i = 0; i < puntajes.Count; i++) {
                for (int j = 0; j < usuarios.Count; j++) {
                    Usuario usuario = usuarios.Find(x => x.idUsuario == puntajes[i].idUsuario);
                    puntajes[i].nombreUsuarioRetrador = usuario.nombre + " " + usuario.apellidoPaterno;
                }
                puntajes[i].nombreUsuarioRetrador = usuarios.Find(x => x.idUsuario == puntajes[i].idUsuario).nombreUsuario;
            }
            for (int i = 0; i < puntajes.Count; i++) {
                dtGridPuntajes.Items.Add(puntajes[i]);
            }
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
            registroWindow.nombreTextBox.Text = usuarioIniciado.nombre;
            registroWindow.apellidoPTextBox.Text = usuarioIniciado.apellidoPaterno;
            registroWindow.apellidoMTextBox.Text = usuarioIniciado.apellidoMaterno;
            registroWindow.emailTextBox.Text = usuarioIniciado.correoElectronico;
            registroWindow.emailTextBox.IsEnabled = false;
            registroWindow.nombreUsuarioTextBox.Text = usuarioIniciado.nombreUsuario;
            registroWindow.contrasenaBox.Password = usuarioIniciado.contrasena;
            registroWindow.crearUsuarioRegistrado();
            registroWindow.Show();
            this.Close();
        }

        
    }
}
