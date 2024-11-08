using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class TrabajarUsuarios : ConnectionToDB
    {
        public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "traerUsuarios";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Usu_ID = reader.GetInt32(reader.GetOrdinal("Usu_ID")),
                                Usu_NombreUsuario = reader.GetString(reader.GetOrdinal("Usu_NombreUsuario")),
                                Usu_Contraseña = reader.GetString(reader.GetOrdinal("Usu_Contraseña")),
                                Usu_ApellidoNombre = reader.GetString(reader.GetOrdinal("Usu_ApellidoNombre")),
                                Rol_Codigo = reader.GetInt32(reader.GetOrdinal("Rol_Codigo"))
                            };
                            Console.WriteLine(usuario);
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }
    }
}
