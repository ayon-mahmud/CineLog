using MySql.Data.MySqlClient;

namespace CineLog.Solution.Data
{
    public static class WatchHistoryRepository
    {
        public static void MarkWatched(int userId, int movieId)
        {
            using var conn = Database.GetConnection();
            string sql = "INSERT INTO WatchHistory (UserId, MovieId, WatchedDate) VALUES (@userId, @movieId, @date);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            cmd.Parameters.AddWithValue("@date", DateTime.Today);
            cmd.ExecuteNonQuery();
        }
    }
}