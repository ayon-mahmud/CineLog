using MySql.Data.MySqlClient;

namespace CineLog.Solution.Data
{
    public static class Database
    {
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(Secrets.MySqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}