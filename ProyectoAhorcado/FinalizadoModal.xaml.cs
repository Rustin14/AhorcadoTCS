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
    /// Lógica de interacción para FinalizadoModal.xaml
    /// </summary>
    public partial class FinalizadoModal : Window
    {
        public FinalizadoModal(string finalizado)
        {
            InitializeComponent();
            finalizadoLabel.Content = finalizado;
        }

        private void botonCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
