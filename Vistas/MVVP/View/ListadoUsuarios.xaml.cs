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
    }
}
