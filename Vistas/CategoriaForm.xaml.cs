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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para CategoriaForm.xaml
    /// </summary>
    public partial class CategoriaForm : Window
    {
        public CategoriaForm()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtNombre.Text)) {

                MessageBox.Show("Campos vacios. Debe completar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                MessageBox.Show($"Categoria creada con exito\nID: {txtID.Text}\nNombre: {txtNombre.Text}\nDescripcion: {txtDescripcion.Text}", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
