using System.Net.Http.Headers;
using System.Text.Json;
using CineLog.Solution.Models;

namespace CineLog.Solution.Services
{
    public static class TMDBService
    {
        private static readonly HttpClient client = new HttpClient();

        static TMDBService()
        {
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Secrets.TmdbReadAccessToken);
        }

        // async Task<T> = "this runs in the background and eventually gives you a T"
        public static async Task<List<Movie>> SearchMoviesAsync(string query)
        {
            string url = $"search/movie?query={Uri.EscapeDataString(query)}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // throws if TMDB returned an error

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(json);
            var results = new List<Movie>();

            foreach (var item in doc.RootElement.GetProperty("results").EnumerateArray())
            {
                var movie = new Movie
                {
                    TMDBId = item.GetProperty("id").GetInt32(),
                    Title = item.GetProperty("title").GetString() ?? "",
                    Overview = item.TryGetProperty("overview", out var ov) ? ov.GetString() : null,
                    PosterPath = item.TryGetProperty("poster_path", out var pp) && pp.ValueKind != JsonValueKind.Null
                                    ? pp.GetString() : null,
                    TMDBRating = item.TryGetProperty("vote_average", out var vr)
                                    ? (decimal)vr.GetDouble() : null
                };

                if (item.TryGetProperty("release_date", out var rd) &&
                    DateTime.TryParse(rd.GetString(), out var parsedDate))
                {
                    movie.ReleaseDate = parsedDate;
                }

                results.Add(movie);
            }

            return results;
        }
        public static async Task<List<Movie>> GetTrendingAsync()
    => await GetMovieListAsync("trending/movie/week");

        public static async Task<List<Movie>> GetPopularAsync()
    => await GetMovieListAsync("movie/popular");

        public static async Task<List<Movie>> GetNowPlayingAsync()
            => await GetMovieListAsync("movie/now_playing");

        public static async Task<List<Movie>> GetUpcomingAsync()
            => await GetMovieListAsync("movie/upcoming");

        // Shared helper — all three endpoints return the same JSON shape as search
        private static async Task<List<Movie>> GetMovieListAsync(string endpoint)
        {
            HttpResponseMessage response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);
            var results = new List<Movie>();

            foreach (var item in doc.RootElement.GetProperty("results").EnumerateArray())
            {
                var movie = new Movie
                {
                    TMDBId = item.GetProperty("id").GetInt32(),
                    Title = item.GetProperty("title").GetString() ?? "",
                    Overview = item.TryGetProperty("overview", out var ov) ? ov.GetString() : null,
                    PosterPath = item.TryGetProperty("poster_path", out var pp) && pp.ValueKind != JsonValueKind.Null
                                    ? pp.GetString() : null,
                    TMDBRating = item.TryGetProperty("vote_average", out var vr)
                                    ? (decimal)vr.GetDouble() : null
                };

                if (item.TryGetProperty("release_date", out var rd) &&
                    DateTime.TryParse(rd.GetString(), out var parsedDate))
                {
                    movie.ReleaseDate = parsedDate;
                }

                results.Add(movie);
            }

            return results;
        }
    }
}