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
    }
}
