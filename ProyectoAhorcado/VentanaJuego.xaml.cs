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
using ProyectoAhorcado.ServiciosAhorcado;

namespace ProyectoAhorcado
{
    /// <summary>
    /// Lógica de interacción para VentanaJuego.xaml
    /// </summary>
    public partial class VentanaJuego : Page
    {

        ServiciosAhorcado.AhorcadoSVCClient servicios = new ServiciosAhorcado.AhorcadoSVCClient();
        int partesAhorcado = 0;
        String[] arrayLetras;
        Boolean juegoFinalizado = false;
        Boolean victoria = false;
        Boolean derrota = false;
        String palabra;

        public VentanaJuego()
        {
            InitializeComponent();
            llenarComponente("palabra");
            servicios.iniciarJuego("palabra");
            letraCombo.ItemsSource = new List<String> {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", 
                "K", "L", "M", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        }

        public void llenarComponente(String palabra)
        {
            this.palabra = palabra;
            int numeroLetras = palabra.Length;
            String [] array = new String[numeroLetras-1];
            arrayLetras = array;
            for (int i = 0; i < numeroLetras; i++)
            {
                String textboxNumber = "textbox" + i.ToString();
                TextBox txt = new TextBox();
                txt.Name = textboxNumber;
                txt.Height = 75;
                txt.Width = 50;
                txt.Margin = new Thickness(10, 0, 10, 10);
                txt.FontSize = 60;
                txt.VerticalAlignment = VerticalAlignment.Center;
                txt.HorizontalAlignment = HorizontalAlignment.Center;
                txt.BorderThickness = new Thickness(0, 0, 0, 8);
                txt.BorderBrush = new SolidColorBrush(Colors.Black);
                txt.IsReadOnly = true;
                panelPalabra.Children.Add(txt);
            }
        }

        public void actualizarComponente(List<int> coincidencias, char letraEscogida)
        {
            if (coincidencias.Count > 0)
            {
                for (int i = 0; i < coincidencias.Count; i++)
                {
                    String textboxName = "textbox" + coincidencias[i].ToString();
                    System.Diagnostics.Debug.WriteLine(coincidencias[i]);
                    for (var x = 0; x < VisualTreeHelper.GetChildrenCount(panelPalabra); x++)
                    {
                        TextBox child = (TextBox)VisualTreeHelper.GetChild(panelPalabra, x);
                        if (child.Name == textboxName)
                        {
                            child.Text = letraEscogida.ToString();
                        }
                    }
                }
            } else
            {
                partesAhorcado++;
            }
        }

        public void actualizarAhorcado()
        {
            if (partesAhorcado == 1)
            {
                cabezaAhorcado.Visibility = Visibility.Visible;
            } else if (partesAhorcado == 2)
            {
                cuerpoAhorcado.Visibility = Visibility.Visible;
            } else if (partesAhorcado == 3)
            {
                brazoDerecho.Visibility = Visibility.Visible;
            } else if (partesAhorcado == 4)
            {
                brazoIzquierdo.Visibility = Visibility.Visible;
            } else if (partesAhorcado == 5)
            {
                piernaDerecha.Visibility = Visibility.Visible;
            } else if (partesAhorcado==6)
            {
                piernaIzquierda.Visibility = Visibility.Visible;
            }
        }

        private void jugarLetraBtn_Click(object sender, RoutedEventArgs e)
        {
            String letra = letraCombo.SelectedValue.ToString().ToLower();
            char letraEscogida = letra[0];
            List<int> coincidencias = servicios.checarLetra(letraEscogida);
            validarJuego();
            actualizarComponente(coincidencias, letraEscogida);
            actualizarAhorcado();
        }

        private void validarJuego()
        {
            if (juegoFinalizado == true && partesAhorcado == 6)
            {
                derrota = true;
            } else if (juegoFinalizado == true && partesAhorcado < 6)
            {
                victoria = true;
            } 
        }


    }

}
