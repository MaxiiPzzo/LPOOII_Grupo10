using ClasesBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Lógica de interacción para VistaPreviaImpresion.xaml
    /// </summary>
    public partial class VistaPreviaImpresion : Window
    {
        public VistaPreviaImpresion()
        {
            InitializeComponent();
        }

        // Método para recibir los datos desde "ListadoUsuarios"
        public void CargarDatos(ObservableCollection<Usuario> usuarios)
        {
            UsuariosDataGrid.ItemsSource = usuarios;
        }

        // Manejo del botón "Imprimir"
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(UsuariosDataGrid, "Vista Previa de Usuarios");
            }
        }
    }
}
