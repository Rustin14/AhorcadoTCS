using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoAhorcado
{
    internal class MensajesAlerta
    {
        public string messageBoxText { get; set; }

        public string caption { get; set; }

        public void mensajeAlerta (string mensaje, string titulo)
        {
            messageBoxText = mensaje;
            caption = titulo;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }
    }
}
