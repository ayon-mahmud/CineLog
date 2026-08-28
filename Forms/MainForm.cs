using CineLog.Solution.Models;
using CineLog.Solution.UserControls;

namespace CineLog.Solution.Forms
{
    public partial class MainForm : Form
    {
        private readonly User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            StyleSidebar();
            currentUser = user;
            Text = $"CineLog — {currentUser.Username}";
            ShowHome();
        }

        private void StyleSidebar()
        {
            var sidebarButtons = new[] { btnHome, btnSearch, btnWatchlist, btnWatched, btnLists, btnProfile, btnLogout };

            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.FromArgb(45, 45, 45);
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(15, 0, 0, 0);
            }
        }

        private void ShowHome()
        {
            contentPanel.Controls.Clear();
            var home = new HomeControl();
            home.Dock = DockStyle.Fill;
            home.MovieSelected += (s, movie) => ShowMovieDetails(movie, ShowHome);
            contentPanel.Controls.Add(home);
        }

        private void ShowSearch()
        {
            contentPanel.Controls.Clear();
            var search = new SearchControl();
            search.Dock = DockStyle.Fill;
            search.MovieSelected += (s, movie) => ShowMovieDetails(movie, ShowSearch);
            contentPanel.Controls.Add(search);
        }

        private void ShowWatchlist()
        {
            contentPanel.Controls.Clear();
            var watchlist = new WatchlistControl(currentUser.UserId);
            watchlist.Dock = DockStyle.Fill;
            watchlist.MovieSelected += (s, movie) => ShowMovieDetails(movie, ShowWatchlist);
            contentPanel.Controls.Add(watchlist);
        }

        private void ShowWatched()
        {
            contentPanel.Controls.Clear();
            var watched = new WatchedControl(currentUser.UserId);
            watched.Dock = DockStyle.Fill;
            watched.MovieSelected += (s, movie) => ShowMovieDetails(movie, ShowWatched);
            contentPanel.Controls.Add(watched);
        }

        private void btnWatched_Click(object sender, EventArgs e) => ShowWatched();

        private void btnWatchlist_Click(object sender, EventArgs e) => ShowWatchlist();

        private void ShowMovieDetails(Movie movie, Action goBack)
        {
            contentPanel.Controls.Clear();
            var details = new MovieDetailsControl(movie, currentUser.UserId);
            details.Dock = DockStyle.Fill;
            details.BackRequested += (s, e) => goBack();
            contentPanel.Controls.Add(details);
        }

        private void btnHome_Click(object sender, EventArgs e) => ShowHome();

        private void btnSearch_Click(object sender, EventArgs e) => ShowSearch();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void ShowLists()
        {
            contentPanel.Controls.Clear();
            var lists = new ListsControl(currentUser.UserId);
            lists.Dock = DockStyle.Fill;
            lists.ListSelected += (s, list) => ShowListDetails(list);
            contentPanel.Controls.Add(lists);
        }

        private void ShowListDetails(MovieList list)
        {
            contentPanel.Controls.Clear();
            var listDetails = new ListDetailsControl(list);
            listDetails.Dock = DockStyle.Fill;
            listDetails.MovieSelected += (s, movie) => ShowMovieDetails(movie, () => ShowListDetails(list));
            listDetails.BackRequested += (s, e) => ShowLists();
            contentPanel.Controls.Add(listDetails);
        }

        private void ShowProfile()
        {
            contentPanel.Controls.Clear();
            var profile = new ProfileControl(currentUser);
            profile.Dock = DockStyle.Fill;
            profile.AccountDeleted += (s, e) =>
            {
                var login = new LoginForm();
                login.Show();
                this.Close();
            };
            contentPanel.Controls.Add(profile);
        }

        private void btnProfile_Click(object sender, EventArgs e) => ShowProfile();

        private void btnLists_Click(object sender, EventArgs e) => ShowLists();
    }
}