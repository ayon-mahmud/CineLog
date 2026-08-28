using MySql.Data.MySqlClient;

namespace CineLog.Solution.Data
{
    public static class WatchlistRepository
    {
        public static void AddToWatchlist(int userId, int movieId)
        {
            using var conn = Database.GetConnection();
            string sql = "INSERT IGNORE INTO Watchlist (UserId, MovieId) VALUES (@userId, @movieId);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            cmd.ExecuteNonQuery();
        }
    }
}