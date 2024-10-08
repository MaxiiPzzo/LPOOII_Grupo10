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

using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Usuario usuarioLogueado;
        public Main(Usuario user)
        {
            InitializeComponent();
            usuarioLogueado = user;
            //Para tener a disposicion los datos del usuaario, por ejemplo mostrar el username en alguna esquina y desloguearse
        }

        private void btnParticipante_Click(object sender, RoutedEventArgs e)
        {
            var atletaForm = new AtletaForm();
            atletaForm.Show();
            this.Close();
        }

        private void btnCompetencia_Click(object sender, RoutedEventArgs e)
        {
            var categoriaForm = new CategoriaForm();
            categoriaForm.Show();
            this.Close();
        }

        private void btnEvento_Click(object sender, RoutedEventArgs e)
        {
            var disciplinaForm = new DisciplinaForm();
            disciplinaForm.Show();
            this.Close();
        }
    }
}
