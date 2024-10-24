using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class TrabajarCompetencia
    {
        public static DataTable traerCompetencias()
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.DefaultConnection);
            try
            {
                conn.Open();
            }
            catch (SqlException sqlEx)
            {
                // Manejo de errores de SQL
                Console.WriteLine("SQL ERROR: " + sqlEx.Message);
                // Aquí puedes agregar más detalles o un manejo específico según el código de error de sqlEx.Number
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine("ERROR: " + ex.Message);
            }



            // SqlCommand cmd = new SqlCommand("ObtenerCompetencias", conn);
            // cmd.CommandType = CommandType.StoredProcedure;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Competencia";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
    }
}
