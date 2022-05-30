﻿using System;
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
    /// Lógica de interacción para RegistroWindow.xaml
    /// </summary>
    public partial class RegistroWindow : Window
    {
        public RegistroWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistrar(object sender, RoutedEventArgs e)
        {
            if (registrarButton.Content.Equals("Registrar"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                PerfilWindow perfilWindow = new PerfilWindow();
                perfilWindow.Show();
                this.Close();
            }
        }

        private void BtnCancelar(object sender, RoutedEventArgs e)
        {
            if (registrarButton.Content.Equals("Registrar"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                PerfilWindow perfilWindow = new PerfilWindow();
                perfilWindow.Show();
                this.Close();
            }
        }
    }
}
