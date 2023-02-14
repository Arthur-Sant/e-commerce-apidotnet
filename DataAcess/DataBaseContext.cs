using System;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using apidotnetwiwthdapper.DataAcess.Interfaces;
using MySqlConnector;

namespace apidotnetwiwthdapper.DataAcess {

    public class DataBaseContext : IDataBaseContext {

        private readonly IConfiguration configuration;
        private MySqlConnection connection;

        public DataBaseContext(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public DataBaseContext() { }

        public DbConnection Connection {
            get {
                if(connection == null) {
                    connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
                }

                return connection;
            }
        }
    }
}
