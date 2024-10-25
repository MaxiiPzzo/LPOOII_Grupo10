using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Atleta : IDataErrorInfo
    {
        private int alt_ID;
        private string alt_DNI;
        private string alt_Apellido;
        private string alt_Nombre;
        private string alt_Nacionalidad;
        private string alt_Entrenador;
        private char alt_Genero;
        private double alt_Altura;
        private double alt_Peso;
        private DateTime alt_FechaNac;
        private string alt_Direccion;
        private string alt_Email;

        public int Alt_ID { get => alt_ID; set => alt_ID = value; }
        public string Alt_DNI { get => alt_DNI; set => alt_DNI = value; }
        public string Alt_Apellido { get => alt_Apellido; set => alt_Apellido = value; }
        public string Alt_Nombre { get => alt_Nombre; set => alt_Nombre = value; }
        public string Alt_Nacionalidad { get => alt_Nacionalidad; set => alt_Nacionalidad = value; }
        public string Alt_Entrenador { get => alt_Entrenador; set => alt_Entrenador = value; }
        public char Alt_Genero { get => alt_Genero; set => alt_Genero = value; }
        public double Alt_Altura { get => alt_Altura; set => alt_Altura = value; }
        public double Alt_Peso { get => alt_Peso; set => alt_Peso = value; }
        public DateTime Alt_FechaNac { get => alt_FechaNac; set => alt_FechaNac = value; }
        public string Alt_Direccion { get => alt_Direccion; set => alt_Direccion = value; }
        public string Alt_Email { get => alt_Email; set => alt_Email = value; }


        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(Alt_ID):
                        if (Alt_ID <= 0) error = "El ID es obligatorio.";
                        break;
                    case nameof(Alt_DNI):
                        if (string.IsNullOrWhiteSpace(Alt_DNI)) error = "El DNI es obligatorio.";
                        break;
                    case nameof(Alt_Apellido):
                        if (string.IsNullOrWhiteSpace(Alt_Apellido)) error = "El apellido es obligatorio.";
                        break;
                    case nameof(Alt_Nombre):
                        if (string.IsNullOrWhiteSpace(Alt_Nombre)) error = "El nombre es obligatorio.";
                        break;
                    case nameof(Alt_Altura):
                        if (Alt_Altura <= 0) error = "La altura debe ser mayor que cero.";
                        break;
                    case nameof(Alt_Peso):
                        if (Alt_Peso <= 0) error = "El peso debe ser mayor que cero.";
                        break;
                }
                return error;
            }
        }
        public string Error => null;
    }
}