namespace CineLog.Solution.Models
{
    public class MovieList
    {
        public int ListId { get; set; }
        public string ListName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int MovieCount { get; set; }
    }
}