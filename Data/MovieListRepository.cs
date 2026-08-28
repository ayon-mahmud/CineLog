using MySql.Data.MySqlClient;
using CineLog.Solution.Models;

namespace CineLog.Solution.Data
{
    public static class MovieListRepository
    {
        public static int CreateList(int userId, string listName, string description)
        {
            using var conn = Database.GetConnection();
            string sql = @"
                INSERT INTO MovieLists (UserId, ListName, Description)
                VALUES (@userId, @name, @desc);
                SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@name", listName);
            cmd.Parameters.AddWithValue("@desc", (object?)description ?? DBNull.Value);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static List<MovieList> GetLists(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = @"
                SELECT l.ListId, l.ListName, l.Description, COUNT(lm.MovieId) AS MovieCount
                FROM MovieLists l
                LEFT JOIN ListMovies lm ON l.ListId = lm.ListId
                WHERE l.UserId = @userId
                GROUP BY l.ListId, l.ListName, l.Description
                ORDER BY l.CreatedAt DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            var lists = new List<MovieList>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lists.Add(new MovieList
                {
                    ListId = reader.GetInt32("ListId"),
                    ListName = reader.GetString("ListName"),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                    MovieCount = reader.GetInt32("MovieCount")
                });
            }
            return lists;
        }

        public static void AddMovieToList(int listId, int movieId)
        {
            using var conn = Database.GetConnection();
            string sql = "INSERT IGNORE INTO ListMovies (ListId, MovieId) VALUES (@listId, @movieId);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@listId", listId);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            cmd.ExecuteNonQuery();
        }

        public static List<Movie> GetMoviesInList(int listId)
        {
            using var conn = Database.GetConnection();
            string sql = @"
                SELECT m.MovieId, m.TMDBId, m.Title, m.ReleaseDate, m.PosterPath,
                       m.BackdropPath, m.Overview, m.Runtime, m.TMDBRating
                FROM ListMovies lm
                JOIN Movies m ON lm.MovieId = m.MovieId
                WHERE lm.ListId = @listId
                ORDER BY lm.AddedAt DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@listId", listId);

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
    }
}