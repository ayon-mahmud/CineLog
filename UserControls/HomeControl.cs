using CineLog.Solution.Models;
using CineLog.Solution.Services;

namespace CineLog.Solution.UserControls
{
    public partial class HomeControl : UserControl
    {
        public event EventHandler<Movie>? MovieSelected;

        public HomeControl()
        {
            InitializeComponent();
            LoadRow(trendingPanel, TMDBService.GetTrendingAsync);
            LoadRow(upcomingPanel, TMDBService.GetUpcomingAsync);
            SetupAutoScroll(trendingPanel);
            SetupAutoScroll(upcomingPanel);
        }

        private async void LoadRow(FlowLayoutPanel panel, Func<Task<List<Movie>>> fetchMovies)
        {
            try
            {
                var movies = await fetchMovies();
                foreach (var movie in movies)
                {
                    var card = new MovieCard();
                    card.SetMovie(movie);
                    card.CardClicked += (s, m) => MovieSelected?.Invoke(this, m);
                    panel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load movies: " + ex.Message);
            }
        }

        private void SetupAutoScroll(FlowLayoutPanel panel)
        {
            int scrollX = 0;
            var timer = new System.Windows.Forms.Timer { Interval = 25 };

            timer.Tick += (s, e) =>
            {
                bool mouseIsOver = panel.RectangleToScreen(panel.ClientRectangle)
                                         .Contains(Cursor.Position);

                if (mouseIsOver)
                {
                    scrollX = panel.HorizontalScroll.Value;
                    return;
                }

                int maxScroll = panel.HorizontalScroll.Maximum;
                if (maxScroll <= 0) return;

                scrollX += 2;
                if (scrollX > maxScroll)
                    scrollX = 0;

                panel.AutoScrollPosition = new Point(scrollX, 0);
            };

            timer.Start();
        }

        private void lblSectionUpcoming_Click(object sender, EventArgs e)
        {

        }
    }
}