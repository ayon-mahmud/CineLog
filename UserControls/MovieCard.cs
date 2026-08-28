using CineLog.Solution.Models;

namespace CineLog.Solution.UserControls
{
    public partial class MovieCard : UserControl
    {
        public Movie Movie { get; private set; } = null!;
        public event EventHandler<Movie>? CardClicked;

        private System.Windows.Forms.Timer? hoverTimer;
        private float hoverProgress = 0f; // 0 = normal, 1 = fully popped
        private bool hoveringIn = false;

        private Size baseImageSize;
        private Point baseImageLocation;

        public MovieCard()
        {
            InitializeComponent();

            // Remember the poster's original position/size before any hover scaling
            baseImageSize = pictureBoxPoster.Size;
            baseImageLocation = pictureBoxPoster.Location;

            ApplyRoundedCorners();
            SetupHoverAnimation();
        }

        private void ApplyRoundedCorners()
        {
            Region = GetRoundedRegion(ClientRectangle, 16);
            pictureBoxPoster.Region = GetRoundedRegion(pictureBoxPoster.ClientRectangle, 12);
        }

        private static Region GetRoundedRegion(Rectangle bounds, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return new Region(path);
        }

        private void SetupHoverAnimation()
        {
            hoverTimer = new System.Windows.Forms.Timer { Interval = 15 };
            hoverTimer.Tick += (s, e) =>
            {
                float target = hoveringIn ? 1f : 0f;
                float speed = 0.18f; // higher = snappier easing

                hoverProgress += (target - hoverProgress) * speed;

                if (Math.Abs(hoverProgress - target) < 0.01f)
                {
                    hoverProgress = target;
                    hoverTimer!.Stop();
                }

                ApplyHoverScale(hoverProgress);
            };

            // Wire hover on every visible piece — this avoids the classic
            // false-trigger issue where moving between the poster and the
            // labels inside the same card would otherwise look like leaving it
            foreach (Control c in new Control[] { this, pictureBoxPoster, lblTitle, lblYear, lblRating })
            {
                c.MouseEnter += (s, e) => { hoveringIn = true; hoverTimer!.Start(); };
                c.MouseLeave += (s, e) => { hoveringIn = false; hoverTimer!.Start(); };
            }
        }

        private void ApplyHoverScale(float progress)
        {
            float scale = 1f + (0.06f * progress); // grows up to 6%

            int newWidth = (int)(baseImageSize.Width * scale);
            int newHeight = (int)(baseImageSize.Height * scale);

            int offsetX = (newWidth - baseImageSize.Width) / 2;
            int offsetY = (newHeight - baseImageSize.Height) / 2;

            pictureBoxPoster.Size = new Size(newWidth, newHeight);
            pictureBoxPoster.Location = new Point(baseImageLocation.X - offsetX, baseImageLocation.Y - offsetY);
            pictureBoxPoster.Region = GetRoundedRegion(pictureBoxPoster.ClientRectangle, 12);
        }

        public async void SetMovie(Movie movie)
        {
            Movie = movie;
            lblTitle.Text = movie.Title;
            lblYear.Text = movie.ReleaseDate?.Year.ToString() ?? "—";
            lblRating.Text = movie.TMDBRating.HasValue ? $"⭐ {movie.TMDBRating:0.0}" : "—";

            if (!string.IsNullOrEmpty(movie.PosterPath))
            {
                string url = $"https://image.tmdb.org/t/p/w200{movie.PosterPath}";
                pictureBoxPoster.Image = await LoadImageAsync(url);
            }
        }

        private static async Task<Image?> LoadImageAsync(string url)
        {
            try
            {
                using var client = new HttpClient();
                byte[] bytes = await client.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }

        private void MovieCard_Click(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, Movie);
        }
    }
}