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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainLayout.xaml
    /// </summary>
    public partial class MainLayout : Window
    {
        public MainLayout()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ventanaUsuarios = new Vistas.MVVP.View.ABMUsuario();
            // Mostrar la ventana
            ventanaUsuarios.Show();
        }
    }
}
