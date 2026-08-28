namespace CineLog.Solution.Models
{
    public class Movie
    {
        public int MovieId { get; set; }        // our own DB id (0 if not saved yet)
        public int TMDBId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string? PosterPath { get; set; }
        public string? BackdropPath { get; set; }
        public string? Overview { get; set; }
        public int? Runtime { get; set; }
        public decimal? TMDBRating { get; set; }
    }
}