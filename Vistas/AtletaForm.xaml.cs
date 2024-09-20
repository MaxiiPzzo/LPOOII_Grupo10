using System;
using System.Collections.Generic;
using System.Windows;
using ClasesBases; 

namespace AtletaForm
{
    public partial class MainWindow : Window
    {
        // Lista para almacenar los atletas
        private List<Atleta> atletas = new List<Atleta>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en "Guardar Atleta"
        private void GuardarAtleta_Click(object sender, RoutedEventArgs e)
        {
            // Validar y capturar los datos del formulario
            try
            {
                Atleta nuevoAtleta = new Atleta
                {
                    Alt_Nombre = txtNombre.Text,
                    Alt_Apellido = txtApellido.Text,
                    Alt_DNI = txtDNI.Text,
                    Alt_Nacionalidad = txtNacionalidad.Text,
                    Alt_Entrenador = txtEntrenador.Text,
                    Alt_Genero = ((ComboBoxItem)cbGenero.SelectedItem).Content.ToString(),
                    Alt_Altura = Convert.ToDouble(txtAltura.Text),
                    Alt_Peso = Convert.ToDouble(txtPeso.Text),
                    Alt_FechaNac = dpFechaNac.SelectedDate.HasValue ? dpFechaNac.SelectedDate.Value : DateTime.MinValue,
                    Alt_Direccion = txtDireccion.Text,
                    Alt_Email = txtEmail.Text
                };

                // Agregar a la lista
                atletas.Add(nuevoAtleta);

                // Mostrar mensaje de éxito
                MessageBox.Show("Atleta guardado exitosamente!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                // Limpiar los campos del formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el atleta: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para limpiar el formulario después de guardar
        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtNacionalidad.Text = "";
            txtEntrenador.Text = "";
            cbGenero.SelectedIndex = -1;
            txtAltura.Text = "";
            txtPeso.Text = "";
            dpFechaNac.SelectedDate = null;
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }
    }

}
