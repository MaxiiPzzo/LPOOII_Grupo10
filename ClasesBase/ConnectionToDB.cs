using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ClasesBase
{
    public abstract class ConnectionToDB
    {
        private readonly SqlConnection _connectionString;

        public ConnectionToDB()
        {
            string connectionString = ClasesBase.Properties.Settings.Default.DefaultConnection;

            _connectionString = new SqlConnection(connectionString);

        }

        protected SqlConnection getConnection()
        {
            return _connectionString;
        }
    }
}
