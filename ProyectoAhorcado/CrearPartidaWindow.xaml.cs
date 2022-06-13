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
            //while ()
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

        public void crearPartida(int idCategoria, int idPalabra)
        {
            Partida partida = new Partida();
            partida.oportunidades = 0;
            partida.idUsuario = usuarioIniciado.idUsuario;
            partida.idUsuarioRetador = usuarioIniciado.idUsuario;
            partida.Fecha = DateTime.Now;
            partida.palabraId = idPalabra;
            partida.categoriaId = idCategoria;
            partida.estado = "Abierta";

            Mensaje mensaje = client.crearNuevaPartida(partida);
            if (mensaje.Error == false) 
            {
                Palabra palabra = palabras.Find(x => x.idPalabra == partida.palabraId);

                VentanaAhorcado ventanaAhorcado = new VentanaAhorcado(palabra, usuarioIniciado, partida);
                ventanaAhorcado.Show();
                this.Close();
            } else
            {
                MensajesAlerta alerta = new MensajesAlerta();
                alerta.mensajeAlerta(mensaje.MensajeRespuesta, "Crear partida");
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nombrePalabra = cbBoxPalabra.SelectedItem.ToString();
            int idPalabra = 0;
            for (int i = 0; i < palabras.Count; i++)
            {
                if (nombrePalabra == palabras[i].nombre)
                {
                    idPalabra = palabras[i].idPalabra;
                }
            }
            int idCategoriaSeleccionada = 0;
            string categoriaSeleccionada = (string)cbBoxCategoria.SelectedItem;
            for (int i = 0; i < categorias.Count; i++)
            {
                if (categorias[i].nombreCategoria.Equals(categoriaSeleccionada))
                {
                    idCategoriaSeleccionada = categorias[i].idCategoria;
                    break;
                }
            }
            crearPartida(idCategoriaSeleccionada, idPalabra);
        }
    }
}
