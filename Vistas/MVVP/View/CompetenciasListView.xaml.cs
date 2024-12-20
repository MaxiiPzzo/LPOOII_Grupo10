﻿using ClasesBase;
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

namespace Vistas.MVVP.View
{
    /// <summary>
    /// Lógica de interacción para CompetenciasListView.xaml
    /// </summary>
    public partial class CompetenciasListView : UserControl
    {
        public CompetenciasListView()
        {
            InitializeComponent();
            LoadCompetencias();
        }
        public void LoadCompetencias()
        {
            var listadoCompetencias = TrabajarCompetencia.traerCompetencias();
            grCompetencias.ItemsSource = listadoCompetencias.DefaultView;
        }
    }
}
