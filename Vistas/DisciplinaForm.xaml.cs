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
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para DisciplinaForm.xaml
    /// </summary>
    public partial class DisciplinaForm : Window
    {
        public DisciplinaForm()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Disciplina oDisciplina = new Disciplina
            {
                Dis_Nombre = txtDisNombre.Text,
                Dis_Descripcion = txtDisDescripcion.Text
            };

            MessageBox.Show($"Disciplina: {oDisciplina.Dis_Nombre}");
        }
    }
}
