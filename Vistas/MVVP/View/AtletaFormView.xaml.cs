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
    /// Lógica de interacción para AtletaFormView.xaml
    /// </summary>
    public partial class AtletaFormView : UserControl
    {
        private Atleta oAtleta;
        public AtletaFormView()
        {
            InitializeComponent();
            oAtleta = new Atleta();
        }

        private void btnConfirmarAtleta_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Mejorar lógica :/

            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string nacionalidad = txtNacionalidad.Text;
            string entrenador = txtEntrenador.Text;

            char genero = rdGenero.SelectedGender[0];

            double altura;
            double peso;
            bool alturaValida = double.TryParse(txtAltura.Text, out altura);
            bool pesoValido = double.TryParse(txtPeso.Text, out peso);

            DateTime fechaNacimiento;
            bool fechaValida = DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento);

            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;

            
            if (string.IsNullOrWhiteSpace(dni) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(nacionalidad) ||
                string.IsNullOrWhiteSpace(entrenador) ||
                !alturaValida ||
                !pesoValido ||
                !fechaValida ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Campos vacíos o datos inválidos. Debe completar todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                
                Atleta oAtleta = new Atleta
                {
                    Alt_DNI = dni,
                    Alt_Nombre = nombre,
                    Alt_Apellido = apellido,
                    Alt_Nacionalidad = nacionalidad,
                    Alt_Entrenador = entrenador,
                    Alt_Altura = altura,
                    Alt_Peso = peso,
                    Alt_Genero = genero,
                    Alt_FechaNac = fechaNacimiento,
                    Alt_Direccion = direccion,
                    Alt_Email = email
                };

                MessageBox.Show($"Atleta creado con éxito\n" +
                                $"DNI: {oAtleta.Alt_DNI}\n" +
                                $"Nombre: {oAtleta.Alt_Nombre} {oAtleta.Alt_Apellido}\n" +
                                $"Nacionalidad: {oAtleta.Alt_Nacionalidad}\n" +
                                $"Entrenador: {oAtleta.Alt_Entrenador}\n" +
                                $"Altura: {oAtleta.Alt_Altura} cm\n" +
                                $"Peso: {oAtleta.Alt_Peso} kg\n" +
                                $"Genero: {oAtleta.Alt_Genero}\n" +
                                $"Fecha Nacimiento: {oAtleta.Alt_FechaNac.ToShortDateString()}\n" +
                                $"Dirección: {oAtleta.Alt_Direccion}\n" +
                                $"Email: {oAtleta.Alt_Email}",
                                "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                
                txtDni.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtNacionalidad.Text = string.Empty;
                txtEntrenador.Text = string.Empty;
                txtAltura.Text = string.Empty;
                txtPeso.Text = string.Empty;
                txtFechaNacimiento.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
        }

    }
}
