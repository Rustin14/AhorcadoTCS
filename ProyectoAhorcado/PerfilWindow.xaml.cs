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
        public PerfilWindow()
        {
            InitializeComponent();
        }

        private void BtnRegresar(object sender, RoutedEventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio();
            menuInicio.Show();
            this.Close();
        }

        private void BtnActualizarDatos(object sender, RoutedEventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio();
            menuInicio.Show();
            this.Close();
        }
    }
}
