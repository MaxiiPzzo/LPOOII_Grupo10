using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class TrabajarAtleta
    {
        public static Atleta TraerAtleta(int id)
        {
            Atleta atleta = null;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maxip\source\repos\LPOOII_Grupo10\ClasesBase\DATABASE\COMDEP.mdf;Integrated Security=True";

            string query = "SELECT * FROM Atleta WHERE Atl_ID = @Atl_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el comando SQL
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Atl_ID", id);

                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Ejecutar el comando y leer los datos
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        atleta = new Atleta
                        {
                            Alt_ID = (int)reader["Atl_ID"],
                            Alt_DNI = reader["Atl_DNI"].ToString(),
                            Alt_Apellido = reader["Atl_Apellido"].ToString(),
                            Alt_Nombre = reader["Atl_Nombre"].ToString(),
                            Alt_Nacionalidad = reader["Atl_Nacionalidad"].ToString(),
                            Alt_Entrenador = reader["Atl_Entrenador"].ToString(),
                            Alt_Genero = Convert.ToChar(reader["Atl_Genero"]),
                            Alt_Altura = Convert.ToDouble(reader["Atl_Altura"]),
                            Alt_Peso = Convert.ToDouble(reader["Atl_Peso"]),
                            Alt_FechaNac = Convert.ToDateTime(reader["Atl_FechaNac"]),
                            Alt_Direccion = reader["Atl_Direccion"].ToString(),
                            Alt_Email = reader["Atl_Email"].ToString()
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al traer el atleta: " + ex.Message);
                }
            }

            return atleta;
        }

        public static void AltaAtleta(Atleta nuevoAtleta)
        {
            // Cadena de conexión a la base de datos (modifícala según tu configuración)
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maxip\source\repos\LPOOII_Grupo10\ClasesBase\DATABASE\COMDEP.mdf;Integrated Security=True";

            // Query para insertar un nuevo atleta
            string query = "INSERT INTO Atleta (Atl_DNI, Atl_Apellido, Atl_Nombre, Atl_Nacionalidad, Atl_Entrenador, Atl_Genero, Atl_Altura, Atl_Peso, Atl_FechaNac, Atl_Direccion, Atl_Email) " +
                           "VALUES (@Atl_DNI, @Atl_Apellido, @Atl_Nombre, @Atl_Nacionalidad, @Atl_Entrenador, @Atl_Genero, @Atl_Altura, @Atl_Peso, @Atl_FechaNac, @Atl_Direccion, @Atl_Email)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Atl_DNI", nuevoAtleta.Alt_DNI);
                command.Parameters.AddWithValue("@Atl_Apellido", nuevoAtleta.Alt_Apellido);
                command.Parameters.AddWithValue("@Atl_Nombre", nuevoAtleta.Alt_Nombre);
                command.Parameters.AddWithValue("@Atl_Nacionalidad", nuevoAtleta.Alt_Nacionalidad);
                command.Parameters.AddWithValue("@Atl_Entrenador", nuevoAtleta.Alt_Entrenador);
                command.Parameters.AddWithValue("@Atl_Genero", nuevoAtleta.Alt_Genero);
                command.Parameters.AddWithValue("@Atl_Altura", nuevoAtleta.Alt_Altura);
                command.Parameters.AddWithValue("@Atl_Peso", nuevoAtleta.Alt_Peso);
                command.Parameters.AddWithValue("@Atl_FechaNac", nuevoAtleta.Alt_FechaNac);
                command.Parameters.AddWithValue("@Atl_Direccion", nuevoAtleta.Alt_Direccion);
                command.Parameters.AddWithValue("@Atl_Email", nuevoAtleta.Alt_Email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el atleta: " + ex.Message);
                }
            }
        }

        public static void BajaAtleta(int atletaId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maxip\source\repos\LPOOII_Grupo10\ClasesBase\DATABASE\COMDEP.mdf;Integrated Security=True";

            string query = "DELETE FROM Atleta WHERE Atl_ID = @Atl_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Atl_ID", atletaId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el atleta: " + ex.Message);
                }
            }
        }

        public static void ModificarAtleta(Atleta atletaModificado)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maxip\source\repos\LPOOII_Grupo10\ClasesBase\DATABASE\COMDEP.mdf;Integrated Security=True";

            string query = "UPDATE Atleta SET Atl_DNI = @Atl_DNI, Atl_Apellido = @Atl_Apellido, Atl_Nombre = @Atl_Nombre, Atl_Nacionalidad = @Atl_Nacionalidad, " +
                           "Atl_Entrenador = @Atl_Entrenador, Atl_Genero = @Atl_Genero, Atl_Altura = @Atl_Altura, Atl_Peso = @Atl_Peso, " +
                           "Atl_FechaNac = @Atl_FechaNac, Atl_Direccion = @Atl_Direccion, Atl_Email = @Atl_Email " +
                           "WHERE Atl_ID = @Atl_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Atl_ID", atletaModificado.Alt_ID);
                command.Parameters.AddWithValue("@Atl_DNI", atletaModificado.Alt_DNI);
                command.Parameters.AddWithValue("@Atl_Apellido", atletaModificado.Alt_Apellido);
                command.Parameters.AddWithValue("@Atl_Nombre", atletaModificado.Alt_Nombre);
                command.Parameters.AddWithValue("@Atl_Nacionalidad", atletaModificado.Alt_Nacionalidad);
                command.Parameters.AddWithValue("@Atl_Entrenador", atletaModificado.Alt_Entrenador);
                command.Parameters.AddWithValue("@Atl_Genero", atletaModificado.Alt_Genero);
                command.Parameters.AddWithValue("@Atl_Altura", atletaModificado.Alt_Altura);
                command.Parameters.AddWithValue("@Atl_Peso", atletaModificado.Alt_Peso);
                command.Parameters.AddWithValue("@Atl_FechaNac", atletaModificado.Alt_FechaNac);
                command.Parameters.AddWithValue("@Atl_Direccion", atletaModificado.Alt_Direccion);
                command.Parameters.AddWithValue("@Atl_Email", atletaModificado.Alt_Email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al modificar el atleta: " + ex.Message);
                }
            }
        }
    }
}
