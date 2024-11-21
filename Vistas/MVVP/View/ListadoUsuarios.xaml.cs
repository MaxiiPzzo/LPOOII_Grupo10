using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ClasesBase; // Asegúrate de que este namespace está presente

namespace Namespace // Cambia "Namespace" por el namespace correcto de tu proyecto
{
    public partial class ListadoUsuarios : Window
    {
        // Propiedad ObservableCollection para enlazar con la grilla
        public ObservableCollection<Usuario> Usuarios { get; set; }

        public ListadoUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            // Instancia de TrabajarUsuarios para obtener los usuarios
            TrabajarUsuarios trabajarUsuarios = new TrabajarUsuarios();

            // Llama al método TraerUsuarios() y ordena por Usu_NombreUsuario
            Usuarios = new ObservableCollection<Usuario>(
                trabajarUsuarios.TraerUsuarios().OrderBy(u => u.Usu_NombreUsuario)
            );

            // Enlaza la colección Usuarios a la grilla de la interfaz
            UsuariosDataGrid.ItemsSource = Usuarios;
        }

        private void userSearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string username = userSearchTextBox.Text.Trim();
            TrabajarUsuarios trabajarUsuarios = new TrabajarUsuarios();

            Usuarios = trabajarUsuarios.TraerUsuariosByNombreUsuario(username);

            UsuariosDataGrid.ItemsSource = Usuarios;


        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana de Vista Previa
            VistaPreviaImpresion vistaPrevia = new VistaPreviaImpresion();

            // Pasar la colección actual de usuarios (ObservableCollection<Usuario>)
            vistaPrevia.CargarDatos(Usuarios);

            // Mostrar la ventana
            vistaPrevia.ShowDialog();
        }


    }
}
