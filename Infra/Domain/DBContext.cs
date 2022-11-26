using Core.Domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Infra.Domain
{
    public class DBContext : IDBContext
    {

        private DbConnection connection;

        private IConfiguration configuration;

        public DBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbConnection dbConnection
        {


            get
            {

                if (connection == null)
                { 
                    connection = new OracleConnection(configuration["ConnectionStrings:DBConnectionString"]);

                    connection.Open();
                    
                }

                else if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;

            }
        }
    }
}
