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
            DataTable dt = new DataTable();
            try
            {
                conn.Open();


                // SqlCommand cmd = new SqlCommand("dbo.obtenerCompetencias", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                // Consulta SQL directamente
                string query = @"
            SELECT 
                c.Com_ID, 
                c.Com_Nombre, 
                c.Com_Descripcion, 
                c.Com_FechaFin, 
                c.Com_FechaInicio,
                c.Com_Organizador, 
                c.Com_Sponsors, 
                c.Com_Estado, 
                c.Com_Ubicacion, 
                d.Dis_Nombre AS Dis_Nombre, 
                cat.Cat_Nombre AS Cat_Nombre
            FROM Competencia c
            JOIN Disciplina d ON c.Dis_ID = d.Dis_ID
            JOIN Categoria cat ON c.Cat_ID = cat.Cat_ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
               
                return dt;

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
            conn.Close();
            return dt;
            
        }
    }
}
