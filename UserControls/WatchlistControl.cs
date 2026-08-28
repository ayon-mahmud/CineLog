using CineLog.Solution.Data;
using CineLog.Solution.Models;

namespace CineLog.Solution.UserControls
{
    public partial class WatchlistControl : UserControl
    {
        private readonly int userId;

        public event EventHandler<Movie>? MovieSelected;

        public WatchlistControl(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadWatchlist();
        }

        private void LoadWatchlist()
        {
            resultsPanel.Controls.Clear();

            var movies = MovieRepository.GetWatchlist(userId);

            if (movies.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "Your watchlist is empty. Search for movies to add some!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F)
                };
                resultsPanel.Controls.Add(emptyLabel);
                return;
            }

            foreach (var movie in movies)
            {
                var card = new MovieCard();
                card.SetMovie(movie);
                card.CardClicked += (s, m) => MovieSelected?.Invoke(this, m);
                resultsPanel.Controls.Add(card);
            }
        }
    }
}