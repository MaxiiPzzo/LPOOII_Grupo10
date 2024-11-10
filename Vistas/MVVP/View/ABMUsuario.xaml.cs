using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using ClasesBase;

namespace Vistas.MVVP.View
{
    /// <summary>
    /// Lógica de interacción para ABMUsuario.xaml
    /// </summary>
    public partial class ABMUsuario : Window, INotifyPropertyChanged
    {
        private TrabajarUsuarios trabajarUsuarios;
        private Usuario _usuarioActual;
        public Usuario UsuarioActual {
            get { return _usuarioActual; }
            set { 
            _usuarioActual = value;
                OnPropertyChanged(nameof(UsuarioActual));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
        public ABMUsuario()
        {

            InitializeComponent();
            trabajarUsuarios = new TrabajarUsuarios();

            actualizarUsuarios();

            UsuarioActual = new Usuario();
            limpiarCampos();

            grUsuarios.ItemsSource = usuarios;
            DataContext = this;
            CargarRoles();
        }

        private void actualizarUsuarios()
        {
            var usuariosActualizados = trabajarUsuarios.TraerUsuarios();
            usuarios.Clear();
            foreach (var usuario in usuariosActualizados)
            {
                usuarios.Add(usuario);
            }
        }

        private void CargarRoles()
        {
            cmbxRoles.Items.Add(new Rol { Rol_Codigo = 0, Rol_Descripcion = "Seleccionar Rol..." });
            cmbxRoles.Items.Add(new Rol { Rol_Codigo = 1, Rol_Descripcion = "Administrador" });
            cmbxRoles.Items.Add(new Rol { Rol_Codigo = 2, Rol_Descripcion = "Usuario" });
            cmbxRoles.Items.Add(new Rol { Rol_Codigo = 3, Rol_Descripcion = "Supervisor" });
            cmbxRoles.Items.Add(new Rol { Rol_Codigo = 4, Rol_Descripcion = "Invitado" });

            cmbxRoles.DisplayMemberPath = "Rol_Descripcion";
            cmbxRoles.SelectedValuePath = "Rol_Codigo";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
        private void SiguienteUsuario()
        {

        }
        private void AnteriorUsuario()
        {

        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            SiguienteUsuario();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            AnteriorUsuario();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            if (isValido())
            {
                trabajarUsuarios.InsertarUsuario(UsuarioActual.Usu_NombreUsuario, UsuarioActual.Usu_Contraseña, UsuarioActual.Usu_ApellidoNombre, UsuarioActual.Rol_Codigo);
                MessageBox.Show("Usuario creado con éxito!.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiarCampos();
                actualizarUsuarios();
            }
            else
            {
                MessageBox.Show("Campos vacíos o datos inválidos. Debe completar todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void limpiarCampos()
        {
            UsuarioActual.Usu_ApellidoNombre = string.Empty;
            UsuarioActual.Usu_Contraseña = string.Empty;
            UsuarioActual.Usu_NombreUsuario = string.Empty;
            UsuarioActual.Rol_Codigo = 0;

            grUsuarios.SelectedItem = null;
        }

        private bool isValido()
        {
            return !UsuarioActual.Usu_ApellidoNombre.Equals(string.Empty)
                && !UsuarioActual.Usu_Contraseña.Equals(string.Empty)
                && !UsuarioActual.Usu_NombreUsuario.Equals(string.Empty)
                && UsuarioActual.Rol_Codigo != 0;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
        }

        private void grUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grUsuarios.SelectedItem != null)
            {
                Usuario seleccionado = grUsuarios.SelectedItem as Usuario;

                UsuarioActual = new Usuario
                {
                    Usu_ID = seleccionado.Usu_ID,
                    Usu_NombreUsuario = seleccionado.Usu_NombreUsuario,
                    Usu_Contraseña = seleccionado.Usu_Contraseña,
                    Usu_ApellidoNombre = seleccionado.Usu_ApellidoNombre,
                    Rol_Codigo = seleccionado.Rol_Codigo
                };
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (grUsuarios.SelectedItem != null)
            {
                trabajarUsuarios.EliminarUsuario(UsuarioActual.Usu_ID);
                MessageBox.Show("Usuario borrado con éxito!.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                actualizarUsuarios();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para proceder con la operación.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (grUsuarios.SelectedItem != null)
            {
                if (isValido())
                {
                    trabajarUsuarios.ActualizarUsuario(UsuarioActual.Usu_ID, UsuarioActual.Usu_NombreUsuario, UsuarioActual.Usu_Contraseña, UsuarioActual.Usu_ApellidoNombre, UsuarioActual.Rol_Codigo);
                    MessageBox.Show("Usuario actualizado con éxito!.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    actualizarUsuarios();
                }
                else
                {
                    MessageBox.Show("Campos vacíos o datos inválidos. Debe completar todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para proceder con la operación.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
