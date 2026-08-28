namespace CineLog.Solution.Models
{
    public class DiaryEntry
    {
        public Movie Movie { get; set; } = null!;
        public DateTime WatchedDate { get; set; }
    }
}