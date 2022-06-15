using ServiciosAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosAhorcado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAhorcadoSVC" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAhorcadoSVC
    {
        [OperationContract]
        RespuestaLogin LogIn(String username, String password);

        [OperationContract]
        Mensaje RegistrarUsuario(Usuario usuario);

        [OperationContract]
        List<int> checarLetra(char letra);

        [OperationContract]
        void iniciarJuego(String palabra);

        [OperationContract]
        char getLetraEscogida();

        [OperationContract]
        void setLetraEscogida(char letra);

        [OperationContract]
        List<Palabra> obtenerPalabras();

        [OperationContract]
        List<Categoria> obtenerCategorias();

        [OperationContract]
        List<Partida> obtenerPartidasDisponibles();

        [OperationContract]
        Mensaje crearNuevaPartida(Partida partidaNueva);

        [OperationContract]
        Mensaje actualizarEstadoPartida(int idPartida, string estado);

        [OperationContract]
        List<Usuario> obtenerUsuariosRegistrados();

        [OperationContract]
        Partida obtenerPartidaPorID(int idPartida);

        [OperationContract]
        Palabra obtenerPalabraPorID(int idPalabra);

        [OperationContract]
        Mensaje actualizarIDRetador(int idRetador, int idPartida);

        [OperationContract]
        List<PuntajeGlobal> obtenerPuntajeGlobal(int idUsuario);

        [OperationContract]
        Mensaje insertarPuntajeGlobal(PuntajeGlobal puntajeGlobal);
    }
}
