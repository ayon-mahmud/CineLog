using CineLog.Solution.Data;
using CineLog.Solution.Models;

namespace CineLog.Solution.UserControls
{
    public partial class ListDetailsControl : UserControl
    {
        private readonly MovieList list;

        public event EventHandler<Movie>? MovieSelected;
        public event EventHandler? BackRequested;

        public ListDetailsControl(MovieList list)
        {
            InitializeComponent();
            this.list = list;
            lblListTitle.Text = list.ListName;
            LoadMovies();
        }

        private void LoadMovies()
        {
            resultsPanel.Controls.Clear();

            var movies = MovieListRepository.GetMoviesInList(list.ListId);

            if (movies.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "No movies in this list yet.",
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}