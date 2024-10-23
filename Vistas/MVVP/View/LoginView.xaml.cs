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
    // NOTA: Considerar implementar toda la lógica en el ViewModel, utilizando el patrón MVVM
    public partial class LoginView : Window
    {
        //TEMP
        private List<Usuario> usuarios;
        public LoginView()
        {
            InitializeComponent();

            //TEMP
            usuarios = new List<Usuario>{
                new Usuario { Usu_ID = 1, Usu_NombreUsuario = "admin", Usu_Contraseña = "111", Rol_Codigo = 1 },
                new Usuario { Usu_ID = 2, Usu_NombreUsuario = "operador", Usu_Contraseña = "222", Rol_Codigo = 2 },
                new Usuario { Usu_ID = 3, Usu_NombreUsuario = "auditor", Usu_Contraseña = "333", Rol_Codigo = 3 }
            };
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var username = txtLoginUsername.Text;
            var password = pasLoginPassword.Password;

            if (validarCampos(username, password))
            {

                var usuarioEncontrado = verificarCredenciales(username, password);
                if (usuarioEncontrado == null)
                {
                    MessageBox.Show("Usuario o Contraseña incorrecta.", "Error de Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                    limpiarCampos();
                }
                else
                {
                    var mainPrincipal = new MainLayout();
                    mainPrincipal.Show();
                    this.Close();
                }
            }

            Console.WriteLine("Botón presionado desde la ventana Login: " + username + "," + password);

        }

        private bool validarCampos(string username, string pwd)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Los campos son obligatorios, no pueden estar vacios.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
                return false;
            }
            return true;
        }

        private void limpiarCampos()
        {
            txtLoginUsername.Text = string.Empty;
            pasLoginPassword.Password = string.Empty;
        }

        private Usuario verificarCredenciales(string usuario, string contraseña)
        {
            //foreach(Usuario user in usuarios)
            //{
            //    if (user.Usu_Contraseña == contraseña && user.Usu_NombreUsuario == usuario)
            //        return user;
            //}
            //return null;

            return usuarios.FirstOrDefault(u => u.Usu_NombreUsuario == usuario && u.Usu_Contraseña == contraseña);
        }
    }
}
