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

        private int indiceActual = 0;
        ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
        public ABMUsuario()
        {
            InitializeComponent();
            trabajarUsuarios = new TrabajarUsuarios();

            usuarios = trabajarUsuarios.TraerUsuarios();
            if (usuarios.Count > 0)
            {
                UsuarioActual = usuarios[0]; // Inicializa con el primer usuario
            }

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
        private void SiguienteUsuario()
        {
            if (usuarios.Count > 0)
            {
                indiceActual = (indiceActual + 1) % usuarios.Count;
                UsuarioActual = usuarios[indiceActual];
            }
        }

        // Método para retroceder al usuario anterior
        private void AnteriorUsuario()
        {
            if (usuarios.Count > 0)
            {
                indiceActual = (indiceActual - 1 + usuarios.Count) % usuarios.Count;
                UsuarioActual = usuarios[indiceActual];
            }
        }

        // Llama a estos métodos en los eventos de los botones de navegación
        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            SiguienteUsuario();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            AnteriorUsuario();
        }
    }
}
