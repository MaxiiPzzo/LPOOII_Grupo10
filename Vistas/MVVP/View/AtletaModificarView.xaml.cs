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

namespace Vistas.MVVP.View
{
    /// <summary>
    /// Lógica de interacción para AtletaModificarView.xaml
    /// </summary>
    public partial class AtletaModificarView : Window
    {
        public AtletaModificarView()
        {
            InitializeComponent();
        }

        private void btnBuscarAtleta_Click(object sender, RoutedEventArgs e)
        {
            Atleta atletaEncontrado=TrabajarAtleta.TraerAtleta(int.Parse(txtBusqueda.Text));
           
            if (atletaEncontrado != null)
            {
                // Cargar los datos del atleta en los campos correspondientes
                txtDni.Text = atletaEncontrado.Alt_DNI;
                txtNombre.Text = atletaEncontrado.Alt_Nombre;
                txtApellido.Text = atletaEncontrado.Alt_Apellido;
                txtNacionalidad.Text = atletaEncontrado.Alt_Nacionalidad;
                txtEntrenador.Text = atletaEncontrado.Alt_Entrenador;
                txtAltura.Text = atletaEncontrado.Alt_Altura.ToString();
                txtPeso.Text = atletaEncontrado.Alt_Peso.ToString();
                txtFechaNacimiento.Text = atletaEncontrado.Alt_FechaNac.ToString("dd/MM/yyyy");
                txtDireccion.Text = atletaEncontrado.Alt_Direccion;
                txtEmail.Text = atletaEncontrado.Alt_Email;
            }
            else
            {
                MessageBox.Show("Atleta no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnConfirmarAtleta_Click(object sender, RoutedEventArgs e)
        {
            bool hasErrors = false;

            // Validar el campo DNI
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                txtDni.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtDni.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtNombre.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtApellido.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Nacionalidad
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                txtNacionalidad.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtNacionalidad.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Entrenador
            if (string.IsNullOrWhiteSpace(txtEntrenador.Text))
            {
                txtEntrenador.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtEntrenador.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Altura
            if (string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                txtAltura.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtAltura.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Peso
            if (string.IsNullOrWhiteSpace(txtPeso.Text))
            {
                txtPeso.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtPeso.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Fecha de Nacimiento
            if (string.IsNullOrWhiteSpace(txtFechaNacimiento.Text))
            {
                txtFechaNacimiento.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtFechaNacimiento.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                txtDireccion.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtDireccion.Style = null; // Quitar el estilo de error si hay texto
            }

            // Validar el campo Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Style = (Style)FindResource("ErrorTextBoxStyle");
                hasErrors = true;
            }
            else
            {
                txtEmail.Style = null; // Quitar el estilo de error si hay texto
            }

            if (hasErrors)
            {
                MessageBox.Show("Por favor, completa todos los campos requeridos.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

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
                    Alt_ID = int.Parse(txtBusqueda.Text),
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

                TrabajarAtleta.ModificarAtleta(oAtleta);

                MessageBox.Show($"Atleta modificado con éxito\n" +
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
