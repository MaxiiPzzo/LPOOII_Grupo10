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
                                Usu_NombreUsuario = reader.IsDBNull(reader.GetOrdinal("Usu_NombreUsuario")) ? null : reader.GetString(reader.GetOrdinal("Usu_NombreUsuario")),
                                Usu_Contraseña = reader.IsDBNull(reader.GetOrdinal("Usu_Contraseña")) ? null : reader.GetString(reader.GetOrdinal("Usu_Contraseña")),
                                Usu_ApellidoNombre = reader.IsDBNull(reader.GetOrdinal("Usu_ApellidoNombre")) ? null : reader.GetString(reader.GetOrdinal("Usu_ApellidoNombre")),
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
        public void InsertarUsuario(string nombreUsuario, string contraseña, string apellidoNombre, int? rolCodigo)
        {
            using (SqlConnection connection = getConnection())
            {

                connection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usu_NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Usu_Contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@Usu_ApellidoNombre", apellidoNombre);
                    cmd.Parameters.AddWithValue("@Rol_Codigo", rolCodigo ?? (object)DBNull.Value);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarUsuario(int usuID, string nombreUsuario, string contraseña, string apellidoNombre, int? rolCodigo)
        {
            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ActualizarUsuario",connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usu_ID", usuID);
                    cmd.Parameters.AddWithValue("@Usu_NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Usu_Contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@Usu_ApellidoNombre", apellidoNombre);
                    cmd.Parameters.AddWithValue("@Rol_Codigo", rolCodigo ?? (object)DBNull.Value);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarUsuario(int usuID)
        {

            using (SqlConnection connection = getConnection())
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usu_ID", usuID);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
