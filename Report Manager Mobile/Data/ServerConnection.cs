using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Manager_Mobile.Data
{
    internal class ServerConnection
    {
        readonly MySqlConnection connection = new();

        public ServerConnection()
        {
            connection.ConnectionString = Globals.connectionString;

        }

        public MySqlConnection Connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }

        public void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
