using ProyectoAhorcado.ServiciosAhorcado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para VentanaAhorcado.xaml
    /// </summary>
    public partial class VentanaAhorcado : Window
    {
        ServiciosAhorcado.AhorcadoSVCClient servicios = new ServiciosAhorcado.AhorcadoSVCClient();
        Boolean partidaFinalizada = false;
        int partesAhorcado = 0;
        String[] arrayLetras;
        String palabra;
        Boolean creadorPartida = false;
        Usuario usuarioIniciado = new Usuario();
        Palabra palabraSeleccionada = new Palabra();
        Partida partidaCreada = new Partida();
        List<String> letrasCombo = new List<String> {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        char letraSeleccionada;
        

        public VentanaAhorcado(Palabra palabra, Usuario usuario, Partida partida)
        {
            InitializeComponent();
            llenarComponente(palabra.nombre);
            usuarioIniciado = usuario;
            palabraSeleccionada = palabra;
            partidaCreada = partida;
            servicios.iniciarJuego(palabra.nombre);
            descripcionText.Text = palabra.descripcion;
            letraCombo.ItemsSource = letrasCombo;
            detectarJugador();
            if (creadorPartida == true)
            {
                Thread hiloCreadorPartida = new Thread(new ThreadStart(mostrarJuegoRetador));
                hiloCreadorPartida.Start();
            }
        }

        public void detectarJugador()
        {
            if (partidaCreada.idUsuario == usuarioIniciado.idUsuario)
            {
                creadorPartida = true;
                letraCombo.Visibility = Visibility.Hidden;
                jugarLetraBtn.Visibility = Visibility.Hidden;
                palabraTb.Visibility = Visibility.Hidden;
                adivinarPalabraBtn.Visibility = Visibility.Hidden;
                labelLetra.Visibility = Visibility.Hidden;
                labelPalabra.Visibility = Visibility.Hidden;
            } 
        }

        public void mostrarJuegoRetador()
        {
            while (!partidaFinalizada)
            {
                if (letraSeleccionada != servicios.getLetraEscogida())
                {
                    letraSeleccionada = servicios.getLetraEscogida();
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        MostrarJuego();
                    })); 
                }
                
            }
        }

        public void registrarPartidaFinalizada()
        {
            
        }

        public void llenarComponente(String palabra)
        {
            this.palabra = palabra;
            int numeroLetras = palabra.Length;
            String[] array = new String[numeroLetras - 1];
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
            //System.Diagnostics.Debug.WriteLine("Numero de coincidencias: " + coincidencias.Count());
            if (coincidencias.Count() > 0)
            {
                for (int i = 0; i < coincidencias.Count(); i++)
                {
                    String textboxName = "textbox" + coincidencias[i].ToString();
                    System.Diagnostics.Debug.WriteLine("Este es el indice: " + coincidencias[i]);
                    for (var x = 0; x < VisualTreeHelper.GetChildrenCount(panelPalabra); x++)
                    {
                        TextBox child = (TextBox)VisualTreeHelper.GetChild(panelPalabra, x);
                        if (child.Name == textboxName)
                        {
                            child.Text = letraEscogida.ToString();
                        }
                    }
                }
            }
            else
            {
                partesAhorcado++;
            }
        }

        public void actualizarAhorcado()
        {
            if (partesAhorcado == 1)
            {
                cabezaAhorcado.Visibility = Visibility.Visible;
            }
            else if (partesAhorcado == 2)
            {
                cuerpoAhorcado.Visibility = Visibility.Visible;
            }
            else if (partesAhorcado == 3)
            {
                brazoDerecho.Visibility = Visibility.Visible;
            }
            else if (partesAhorcado == 4)
            {
                brazoIzquierdo.Visibility = Visibility.Visible;
            }
            else if (partesAhorcado == 5)
            {
                piernaDerecha.Visibility = Visibility.Visible;
            }
            else if (partesAhorcado == 6)
            {
                piernaIzquierda.Visibility = Visibility.Visible;
            }
        }

        private void Juego()
        {
            String letra = letraCombo.SelectedValue.ToString().ToLower();
            char letraEscogida = letra[0];
            List<int> coincidencias = servicios.checarLetra(letraEscogida);
            servicios.setLetraEscogida(letraEscogida);
            letrasCombo.Remove(letraEscogida.ToString().ToUpper());
            letraCombo.ItemsSource = letrasCombo;
            letraCombo.Items.Refresh();
            actualizarComponente(coincidencias, letraEscogida);
            actualizarAhorcado();
            validarJuego();
        }

        private void MostrarJuego()
        {
            List<int> coincidencias = servicios.checarLetra(letraSeleccionada);
            servicios.setLetraEscogida(letraSeleccionada);
            letrasCombo.Remove(letraSeleccionada.ToString().ToUpper());
            letraCombo.ItemsSource = letrasCombo;
            letraCombo.Items.Refresh();
            actualizarComponente(coincidencias, letraSeleccionada);
            actualizarAhorcado();
            validarJuego();
        }

        private void jugarLetraBtn_Click(object sender, RoutedEventArgs e)
        {
            Juego();
        }

        private void validarJuego()
        {
            int contadorVictoria = 0;
            if (partesAhorcado == 6)
            {
                partidaFinalizada = true;
                servicios.actualizarEstadoPartida(partidaCreada.idPartida, "Derrota");
                finalizadoRectangulo.Visibility = Visibility.Visible;
                derrotaLabel.Visibility = Visibility.Visible;
                FinalizadoModal modal = new FinalizadoModal("¡DERROTA!");
                modal.ShowDialog();
                MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
                menuInicio.Show();
                this.Close();
            }
            else if (partesAhorcado < 6)
            {
                for (var x = 0; x < VisualTreeHelper.GetChildrenCount(panelPalabra); x++)
                {
                    TextBox child = (TextBox)VisualTreeHelper.GetChild(panelPalabra, x);
                    if (!string.IsNullOrWhiteSpace(child.Text))
                    {
                        System.Diagnostics.Debug.WriteLine("Contador victoria:  " + contadorVictoria);
                        contadorVictoria++;
                    }
                }
                if (contadorVictoria == palabra.Count())
                {
                    partidaFinalizada = true;
                    servicios.actualizarEstadoPartida(partidaCreada.idPartida, "Victoria");
                    finalizadoRectangulo.Visibility = Visibility.Visible;
                    victoriaLabel.Visibility = Visibility.Visible;
                    FinalizadoModal modal = new FinalizadoModal("¡VICTORIA!");
                    modal.ShowDialog();
                    MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
                    menuInicio.Show();
                    this.Close();
                }
            }

        }
    }
}
