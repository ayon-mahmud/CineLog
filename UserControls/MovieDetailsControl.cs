using CineLog.Solution.Models;
using CineLog.Solution.Data;

namespace CineLog.Solution.UserControls
{
    public partial class MovieDetailsControl : UserControl
    {
        private readonly Movie movie;
        private readonly int userId;

        public event EventHandler? BackRequested;

        public MovieDetailsControl(Movie movie, int userId)
        {
            InitializeComponent();
            this.movie = movie;
            this.userId = userId;
            LoadDetails();
        }

        private async void LoadDetails()
        {
            lblTitle.Text = movie.Title;

            string year = movie.ReleaseDate?.Year.ToString() ?? "—";
            string runtime = movie.Runtime.HasValue ? $"{movie.Runtime} min" : "";
            lblMeta.Text = $"{year} {(string.IsNullOrEmpty(runtime) ? "" : "• " + runtime)}";

            lblOverview.Text = movie.Overview ?? "No overview available.";

            if (!string.IsNullOrEmpty(movie.PosterPath))
            {
                string url = $"https://image.tmdb.org/t/p/w300{movie.PosterPath}";
                try
                {
                    using var client = new HttpClient();
                    byte[] bytes = await client.GetByteArrayAsync(url);
                    using var ms = new MemoryStream(bytes);
                    pictureBoxPoster.Image = Image.FromStream(ms);
                }
                catch { }
            }
            LoadUserRating();
            LoadReview();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddWatchlist_Click(object sender, EventArgs e)
        {
            try
            {
                int movieId = MovieRepository.GetOrCreateMovie(movie);
                WatchlistRepository.AddToWatchlist(userId, movieId);
                MessageBox.Show("Added to watchlist!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add to watchlist: " + ex.Message);
            }
        }

        private void btnMarkWatched_Click(object sender, EventArgs e)
        {
            try
            {
                int movieId = MovieRepository.GetOrCreateMovie(movie);
                WatchHistoryRepository.MarkWatched(userId, movieId);
                MessageBox.Show("Marked as watched!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to mark watched: " + ex.Message);
            }
        }

        private void lblOverview_Click(object sender, EventArgs e)
        {

        }
        private void LoadUserRating()
        {
            int movieId = MovieRepository.GetOrCreateMovie(movie);
            int currentRating = RatingRepository.GetRating(userId, movieId);
            lblCurrentRating.Text = currentRating > 0 ? $"Your rating: {currentRating}/5" : "Not rated yet";
        }

        private void RateMovie(int stars)
        {
            try
            {
                int movieId = MovieRepository.GetOrCreateMovie(movie);
                RatingRepository.SetRating(userId, movieId, stars);
                lblCurrentRating.Text = $"Your rating: {stars}/5";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save rating: " + ex.Message);
            }
        }

        private void btnRate1_Click(object sender, EventArgs e) => RateMovie(1);
        private void btnRate2_Click(object sender, EventArgs e) => RateMovie(2);
        private void btnRate3_Click(object sender, EventArgs e) => RateMovie(3);
        private void btnRate4_Click(object sender, EventArgs e) => RateMovie(4);
        private void btnRate5_Click(object sender, EventArgs e) => RateMovie(5);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadReview()
        {
            int movieId = MovieRepository.GetOrCreateMovie(movie);
            txtReview.Text = ReviewRepository.GetReview(userId, movieId);
        }

        private void btnSubmitReview_Click(object sender, EventArgs e)
        {
            string text = txtReview.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Write something before submitting.");
                return;
            }

            try
            {
                int movieId = MovieRepository.GetOrCreateMovie(movie);
                ReviewRepository.SetReview(userId, movieId, text);
                MessageBox.Show("Review saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save review: " + ex.Message);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            var lists = MovieListRepository.GetLists(userId);

            if (lists.Count == 0)
            {
                MessageBox.Show("You don't have any lists yet. Create one from the Lists screen first.");
                return;
            }

            // Build a simple selection prompt using existing list names
            string listNames = string.Join(", ", lists.Select(l => l.ListName));
            string chosenName = Microsoft.VisualBasic.Interaction.InputBox(
                $"Which list? ({listNames})", "Add to List", "");

            if (string.IsNullOrWhiteSpace(chosenName))
                return;

            var match = lists.FirstOrDefault(l => l.ListName.Equals(chosenName, StringComparison.OrdinalIgnoreCase));
            if (match == null)
            {
                MessageBox.Show("No list found with that name.");
                return;
            }

            try
            {
                int movieId = MovieRepository.GetOrCreateMovie(movie);
                MovieListRepository.AddMovieToList(match.ListId, movieId);
                MessageBox.Show($"Added to \"{match.ListName}\"!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add to list: " + ex.Message);
            }
        }
    }
}