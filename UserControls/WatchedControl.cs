using CineLog.Solution.Data;
using CineLog.Solution.Models;

namespace CineLog.Solution.UserControls
{
    public partial class WatchedControl : UserControl
    {
        private readonly int userId;

        public event EventHandler<Movie>? MovieSelected;

        public WatchedControl(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadDiary();
        }

        private void LoadDiary()
        {
            resultsPanel.Controls.Clear();

            var entries = MovieRepository.GetWatchHistory(userId);

            if (entries.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "You haven't marked any movies as watched yet.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F)
                };
                resultsPanel.Controls.Add(emptyLabel);
                return;
            }

            foreach (var entry in entries)
            {
                var card = new MovieCard();
                card.SetMovie(entry.Movie);
                card.CardClicked += (s, m) => MovieSelected?.Invoke(this, m);
                resultsPanel.Controls.Add(card);
            }
        }
    }
}