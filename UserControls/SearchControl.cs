using CineLog.Solution.Models;
using CineLog.Solution.Services;

namespace CineLog.Solution.UserControls
{
    public partial class SearchControl : UserControl
    {
        public event EventHandler<Movie>? MovieSelected;

        public SearchControl()
        {
            InitializeComponent();
            LoadDiscover();
        }

        private async void LoadDiscover()
        {
            try
            {
                var movies = await TMDBService.GetPopularAsync();
                foreach (var movie in movies)
                {
                    var card = new MovieCard();
                    card.SetMovie(movie);
                    card.CardClicked += Card_Clicked;
                    discoverPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load discover: " + ex.Message);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearchQuery.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
                return;

            btnSearch.Enabled = false;
            resultsPanel.Controls.Clear();

            try
            {
                var movies = await TMDBService.SearchMoviesAsync(query);

                foreach (var movie in movies)
                {
                    var card = new MovieCard();
                    card.SetMovie(movie);
                    card.CardClicked += Card_Clicked;
                    resultsPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private void Card_Clicked(object? sender, Movie movie)
        {
            MovieSelected?.Invoke(this, movie);
        }
    }
}