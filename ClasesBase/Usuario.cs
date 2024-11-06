using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario : ObservableObject
    {
        private int usu_ID;    
        private string usu_NombreUsuario;
        private string usu_Contraseña;
        private string usu_ApellidoNombre;
        private int rol_Codigo;

        public int Usu_ID 
        {
            get => usu_ID;
            set { usu_ID = value; OnPropertyChanged(); }
        }
        public string Usu_NombreUsuario 
        {
            get => usu_NombreUsuario;
            set { usu_NombreUsuario = value; OnPropertyChanged(); }
        }
        public string Usu_Contraseña 
        {
            get => usu_Contraseña;
            set { usu_Contraseña = value; OnPropertyChanged(); }
        }
        public string Usu_ApellidoNombre 
        { 
            get => usu_ApellidoNombre;
            set { usu_ApellidoNombre = value; OnPropertyChanged(); }
        }
        public int Rol_Codigo 
        { 
            get => rol_Codigo;
            set { rol_Codigo = value; OnPropertyChanged(); }
        }
    }
}