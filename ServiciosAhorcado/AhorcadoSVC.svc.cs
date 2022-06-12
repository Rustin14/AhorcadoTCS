using ServiciosAhorcado.Modelo.DAO;
using ServiciosAhorcado.Modelo.Poco;
using ServiciosAhorcado.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosAhorcado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AhorcadoSVC" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AhorcadoSVC.svc o AhorcadoSVC.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AhorcadoSVC : IAhorcadoSVC
    {
        
        public AhorcadoSVC() { }

        public RespuestaLogin LogIn(String username, String password)
        {
            RespuestaLogin respuesta = new RespuestaLogin();
            respuesta = UsuarioDAO.iniciarSesion(username, password);
            return respuesta;
        }

        public Mensaje RegistrarUsuario(Usuario usuario)
        {
            Mensaje mensaje = new Mensaje();
            mensaje = UsuarioDAO.insertarUsuario(usuario);
            return mensaje;
        }

        public List<int> checarLetra(char letra)
        {
            List<int> coincidencias = GameUtil.verificarLetra(letra);
            return coincidencias;
        }

        public void iniciarJuego(String palabra)
        {
            GameUtil.IniciarPartida(palabra);
        }

        public List<Palabra> obtenerPalabras()
        {
            List<Palabra> palabras = new List<Palabra>();
            palabras = PalabraDAO.ObtenerPalabras();
            return palabras;
        }

        public List<Categoria> obtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias = CategoriaDAO.obtenerCategorias();
            return categorias;
        }

        public List<Partida> obtenerPartidasDisponibles()
        {
            List<Partida> partidas = new List<Partida>();
            partidas = PartidaDAO.obtenerPartidasDisponibles();
            return partidas;
        }

        public Mensaje crearNuevaPartida(Partida partidaNueva)
        {
            Mensaje mensaje = new Mensaje();
            mensaje = PartidaDAO.crearPartida(partidaNueva);
            return mensaje;
        }

        public Mensaje actualizarEstadoPartida(int idPartida, string estado)
        {
            Mensaje mensaje = PartidaDAO.actualizarEstadoDePartida(idPartida, estado);
            return mensaje;
        }

    }
}
