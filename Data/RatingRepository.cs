using MySql.Data.MySqlClient;

namespace CineLog.Solution.Data
{
    public static class RatingRepository
    {
        // Insert if new, update if the user already rated this movie
        public static void SetRating(int userId, int movieId, int rating)
        {
            using var conn = Database.GetConnection();
            string sql = @"
                INSERT INTO Ratings (UserId, MovieId, Rating)
                VALUES (@userId, @movieId, @rating)
                ON DUPLICATE KEY UPDATE Rating = @rating, RatedAt = CURRENT_TIMESTAMP;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.ExecuteNonQuery();
        }

        // Returns 0 if the user hasn't rated this movie yet
        public static int GetRating(int userId, int movieId)
        {
            using var conn = Database.GetConnection();
            string sql = "SELECT Rating FROM Ratings WHERE UserId = @userId AND MovieId = @movieId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@movieId", movieId);

            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}