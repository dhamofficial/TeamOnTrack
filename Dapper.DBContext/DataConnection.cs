using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Utilities.Helper;

namespace Dapper
{ 
    public class DBContext : IDisposable
    {
        public string ActionMessage { get; set; }

        private IDbConnection _connection;

        /// <summary>
        /// internal connection field
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open && _connection.State != ConnectionState.Connecting)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public DBContext()
        {
            Initialize();
        }

        public void Initialize()
        {
            try
            {
                string ConnectionString = string.Empty;

                if (ConfigurationManager.ConnectionStrings["DBCon"].IsNotNullAndEmpty())
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
                    _connection = new SqlConnection(ConnectionString);
                }

            }
            catch (Exception ex)
            {
                ActionMessage = ex.ToString();
            }
        }

        public bool TestConnection()
        {
            bool ReturnValue = false;

            try
            {
                if (_connection != null && _connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                    ReturnValue = true;
                }
            }
            catch (Exception ex)
            {
                ActionMessage = ex.ToString();
            }

            return ReturnValue;

        }

        public IDbConnection GetIDbConnection()
        {
            return Connection;
        }

        public void Dispose()
        {
            try
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
            catch (Exception ex)
            {
                ActionMessage = ex.ToString();
            }
        }
    }
}
