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
            connection.ConnectionString = @"Server=179.111.22.137;Database=report_manager;Uid=newuser;Pwd=New@Mic15;SSL Mode=None;AllowPublicKeyRetrieval=true";
            //connection.ConnectionString = @"Server=localhost;Database=report_manager;Uid=newuser;Pwd=New@Mic15;SSL Mode=None;AllowPublicKeyRetrieval=true";

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
