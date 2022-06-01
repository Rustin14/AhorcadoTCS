using ServiciosAhorcado.Modelo.DAO;
using ServiciosAhorcado.Modelo.Poco;
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

        ServiciosAhorcado.AhorcadoSVC serviciosAhorcado = new ServiciosAhorcado.AhorcadoSVC();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            RespuestaLogin respuestaLogin = new RespuestaLogin();
            String email = emailtb.Text;
            String password = passwordtb.Text;
            respuestaLogin = serviciosAhorcado.LogIn(email, password);
            if (respuestaLogin.UsuarioCorrecto)
            {
                
            } else
            {

            }

        }

    }
}
