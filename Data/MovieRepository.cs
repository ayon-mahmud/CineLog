using MySql.Data.MySqlClient;
using CineLog.Solution.Models;

namespace CineLog.Solution.Data
{
    public static class MovieRepository
    {

        public static List<DiaryEntry> GetWatchHistory(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = @"
        SELECT m.MovieId, m.TMDBId, m.Title, m.ReleaseDate, m.PosterPath,
               m.BackdropPath, m.Overview, m.Runtime, m.TMDBRating, wh.WatchedDate
        FROM WatchHistory wh
        JOIN Movies m ON wh.MovieId = m.MovieId
        WHERE wh.UserId = @userId
        ORDER BY wh.WatchedDate DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            var entries = new List<DiaryEntry>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var movie = new Movie
                {
                    MovieId = reader.GetInt32("MovieId"),
                    TMDBId = reader.GetInt32("TMDBId"),
                    Title = reader.GetString("Title"),
                    ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? null : reader.GetDateTime("ReleaseDate"),
                    PosterPath = reader.IsDBNull(reader.GetOrdinal("PosterPath")) ? null : reader.GetString("PosterPath"),
                    BackdropPath = reader.IsDBNull(reader.GetOrdinal("BackdropPath")) ? null : reader.GetString("BackdropPath"),
                    Overview = reader.IsDBNull(reader.GetOrdinal("Overview")) ? null : reader.GetString("Overview"),
                    Runtime = reader.IsDBNull(reader.GetOrdinal("Runtime")) ? null : reader.GetInt32("Runtime"),
                    TMDBRating = reader.IsDBNull(reader.GetOrdinal("TMDBRating")) ? null : reader.GetDecimal("TMDBRating")
                };

                entries.Add(new DiaryEntry
                {
                    Movie = movie,
                    WatchedDate = reader.GetDateTime("WatchedDate")
                });
            }
            return entries;
        }
        // Returns the local MovieId — inserts the movie first if we've never saved it before
        public static List<Movie> GetWatchlist(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = @"
        SELECT m.MovieId, m.TMDBId, m.Title, m.ReleaseDate, m.PosterPath,
               m.BackdropPath, m.Overview, m.Runtime, m.TMDBRating
        FROM Watchlist w
        JOIN Movies m ON w.MovieId = m.MovieId
        WHERE w.UserId = @userId
        ORDER BY w.AddedAt DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            var movies = new List<Movie>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                movies.Add(new Movie
                {
                    MovieId = reader.GetInt32("MovieId"),
                    TMDBId = reader.GetInt32("TMDBId"),
                    Title = reader.GetString("Title"),
                    ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? null : reader.GetDateTime("ReleaseDate"),
                    PosterPath = reader.IsDBNull(reader.GetOrdinal("PosterPath")) ? null : reader.GetString("PosterPath"),
                    BackdropPath = reader.IsDBNull(reader.GetOrdinal("BackdropPath")) ? null : reader.GetString("BackdropPath"),
                    Overview = reader.IsDBNull(reader.GetOrdinal("Overview")) ? null : reader.GetString("Overview"),
                    Runtime = reader.IsDBNull(reader.GetOrdinal("Runtime")) ? null : reader.GetInt32("Runtime"),
                    TMDBRating = reader.IsDBNull(reader.GetOrdinal("TMDBRating")) ? null : reader.GetDecimal("TMDBRating")
                });
            }
            return movies;
        }
        public static int GetOrCreateMovie(Movie movie)
        {
            using var conn = Database.GetConnection();

            // Check if we already have this TMDB movie saved
            string checkSql = "SELECT MovieId FROM Movies WHERE TMDBId = @tmdbId;";
            using (var checkCmd = new MySqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("@tmdbId", movie.TMDBId);
                var existing = checkCmd.ExecuteScalar();
                if (existing != null)
                    return Convert.ToInt32(existing);
            }

            // Not saved yet — insert it now
            string insertSql = @"
                INSERT INTO Movies (TMDBId, Title, ReleaseDate, PosterPath, BackdropPath, Overview, Runtime, TMDBRating)
                VALUES (@tmdbId, @title, @releaseDate, @poster, @backdrop, @overview, @runtime, @rating);
                SELECT LAST_INSERT_ID();";

            using var insertCmd = new MySqlCommand(insertSql, conn);
            insertCmd.Parameters.AddWithValue("@tmdbId", movie.TMDBId);
            insertCmd.Parameters.AddWithValue("@title", movie.Title);
            insertCmd.Parameters.AddWithValue("@releaseDate", (object?)movie.ReleaseDate ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@poster", (object?)movie.PosterPath ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@backdrop", (object?)movie.BackdropPath ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@overview", (object?)movie.Overview ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@runtime", (object?)movie.Runtime ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@rating", (object?)movie.TMDBRating ?? DBNull.Value);

            return Convert.ToInt32(insertCmd.ExecuteScalar());
        }
    }
}