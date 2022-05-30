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
        public MenuInicio()
        {
            InitializeComponent();
        }

        private void BtnPerfil(object sender, RoutedEventArgs e)
        {
            PerfilWindow perfilWindow = new PerfilWindow();
            perfilWindow.Show();
            this.Close();
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
