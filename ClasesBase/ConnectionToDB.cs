using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ClasesBase
{
    public abstract class ConnectionToDB
    {
        private readonly string _connectionString;

        public ConnectionToDB()
        {
            _connectionString = ClasesBase.Properties.Settings.Default.DefaultConnection;

        }

        protected SqlConnection getConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
