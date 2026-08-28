using MySql.Data.MySqlClient;

namespace CineLog.Solution.Data
{
    public static class ReviewRepository
    {
        // One review per user per movie — update if it already exists
        public static void SetReview(int userId, int movieId, string reviewText)
        {
            using var conn = Database.GetConnection();

            string checkSql = "SELECT ReviewId FROM Reviews WHERE UserId = @userId AND MovieId = @movieId;";
            using (var checkCmd = new MySqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("@userId", userId);
                checkCmd.Parameters.AddWithValue("@movieId", movieId);
                var existing = checkCmd.ExecuteScalar();

                if (existing != null)
                {
                    string updateSql = "UPDATE Reviews SET ReviewText = @text, CreatedAt = CURRENT_TIMESTAMP WHERE ReviewId = @id;";
                    using var updateCmd = new MySqlCommand(updateSql, conn);
                    updateCmd.Parameters.AddWithValue("@text", reviewText);
                    updateCmd.Parameters.AddWithValue("@id", existing);
                    updateCmd.ExecuteNonQuery();
                    return;
                }
            }

            string insertSql = "INSERT INTO Reviews (UserId, MovieId, ReviewText) VALUES (@userId, @movieId, @text);";
            using var insertCmd = new MySqlCommand(insertSql, conn);
            insertCmd.Parameters.AddWithValue("@userId", userId);
            insertCmd.Parameters.AddWithValue("@movieId", movieId);
            insertCmd.Parameters.AddWithValue("@text", reviewText);
            insertCmd.ExecuteNonQuery();
        }

        // Returns "" if no review exists yet
        public static string GetReview(int userId, int movieId)
        {
            using var conn = Database.GetConnection();
            string sql = "SELECT ReviewText FROM Reviews WHERE UserId = @userId AND MovieId = @movieId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@movieId", movieId);

            var result = cmd.ExecuteScalar();
            return result?.ToString() ?? "";
        }
    }
}