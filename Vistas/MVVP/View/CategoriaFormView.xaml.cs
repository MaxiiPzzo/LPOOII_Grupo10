using ClasesBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.MVVP.View
{
    /// <summary>
    /// Lógica de interacción para CategoriaFormView.xaml
    /// </summary>
    public partial class CategoriaFormView : UserControl
    {
        //TEMP
        private Categoria oCategoria;

        public CategoriaFormView()
        {
            InitializeComponent();
            oCategoria = new Categoria();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            {

                MessageBox.Show("Campos vacios. Debe completar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                oCategoria.Cat_Nombre = nombre;
                oCategoria.Cat_Descripcion = descripcion;
                MessageBox.Show($"Categoria creada con exito\nNombre: {oCategoria.Cat_Nombre}\nDescripcion: {oCategoria.Cat_Descripcion}", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
        }
    }
}
