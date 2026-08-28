using MySql.Data.MySqlClient;

namespace CineLog.Solution.Data
{
    public static class ProfileRepository
    {
        public static int GetWatchedCount(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = "SELECT COUNT(*) FROM WatchHistory WHERE UserId = @userId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static int GetListCount(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = "SELECT COUNT(*) FROM MovieLists WHERE UserId = @userId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static decimal GetAverageRating(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = "SELECT AVG(Rating) FROM Ratings WHERE UserId = @userId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            var result = cmd.ExecuteScalar();
            return result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0m;
        }
    }
}