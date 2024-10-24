﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.Templates
{
    /// <summary>
    /// Lógica de interacción para AtletaFormGenderCheckboxUC.xaml
    /// </summary>
    public partial class AtletaFormGenderCheckboxUC : UserControl
    {
        public string SelectedGender { get; set; }
        public AtletaFormGenderCheckboxUC()
        {
            InitializeComponent();
        }


        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (sender as RadioButton);
            if (radioButton != null)
            {
                SelectedGender = radioButton.Content.ToString();
            }
        }
    }
}
