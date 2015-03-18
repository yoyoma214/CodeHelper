using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.DbConfig
{
    public delegate void ValidateError(string connStr, string message);

    public static class ConnectionManager
    {
        public static event ValidateError OnValidateError;

        private static List<Connection> Connections = new List<Connection>();

        public static void FireValidateError(string connStr, string message)
        {
            if (OnValidateError != null)
                OnValidateError(connStr, message);
        }

        public static Connection Get(string conn)
        {
            foreach (var c in Connections)
            {
                if (c.ConnectionString == conn)
                    return c;
            }

            return new Connection(conn);
        }

        public static void Update(Connection conn)
        {
            if ( !Connections.Contains(conn))  
                Connections.Add(conn);

            //Connections.Add(conn);
        }
    }
}
