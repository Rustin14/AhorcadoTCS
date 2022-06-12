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
    /// Lógica de interacción para CrearPartidaWindow.xaml
    /// </summary>
    public partial class CrearPartidaWindow : Window
    {

        Usuario usuarioIniciado = new Usuario();
        ServiciosAhorcado.AhorcadoSVCClient client = new ServiciosAhorcado.AhorcadoSVCClient();
        List<Palabra> palabras = new List<Palabra>();
        List<string> nombresPalabras = new List<string>();
        List<Categoria> categorias = new List<Categoria>();
        List<Usuario> usuariosEnPartida = new List<Usuario>();

        public CrearPartidaWindow(Usuario usuario)
        {
            InitializeComponent();
            usuarioIniciado = usuario;
            System.Diagnostics.Debug.WriteLine("Usuario: " + usuarioIniciado.nombre);
            nombreUsuarioLabel.Content = usuarioIniciado.nombre + " " + usuarioIniciado.apellidoPaterno;
            obtenerCategorias();
            obtenerPalabras();
        }

        public void esperarRetador()
        {
            //Método para que el Usuario pueda esperar a que un Retador se una a su partida (no estoy seguro aún cómo hacerlo)
        }

        public void obtenerCategorias()
        {
            categorias = client.obtenerCategorias();
            List<string> nombresCategorias = new List<string>();
            for(int i=0; i<categorias.Count; i++)
            {
                nombresCategorias.Add(categorias[i].nombreCategoria);
            }
            cbBoxCategoria.ItemsSource = nombresCategorias;
        }

        public void obtenerPalabras()
        {
            palabras = client.obtenerPalabras();
        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio(usuarioIniciado);
            menuInicio.Show();
            this.Close();
        }

        private void cbBoxSeleccion(object sender, SelectionChangedEventArgs e)
        {
            nombresPalabras.Clear();
            int idCategoriaSeleccionada = 0;
            string categoriaSeleccionada = (string) cbBoxCategoria.SelectedItem;
            for (int i = 0; i < categorias.Count; i++)
            {
                if (categorias[i].nombreCategoria.Equals(categoriaSeleccionada))
                {
                    idCategoriaSeleccionada = categorias[i].idCategoria;
                    break;
                }
            }
            for (int i = 0; i < palabras.Count; i++)
            {
                if (palabras[i].categoria == idCategoriaSeleccionada)
                {
                    nombresPalabras.Add(palabras[i].nombre);
                }
            }
            cbBoxPalabra.ItemsSource = nombresPalabras;
        }
    }
}
