using MySql.Data.MySqlClient;

namespace Sql_connect
{
    class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            string connString = $"Server={host};Port={port};Database={database}; port={port}; User Id={username};password={password}";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
