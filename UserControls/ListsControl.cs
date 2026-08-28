using CineLog.Solution.Data;
using CineLog.Solution.Models;

namespace CineLog.Solution.UserControls
{
    public partial class ListsControl : UserControl
    {
        private readonly int userId;

        public event EventHandler<MovieList>? ListSelected;

        public ListsControl(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadLists();
        }

        private void LoadLists()
        {
            listsPanel.Controls.Clear();

            var lists = MovieListRepository.GetLists(userId);

            if (lists.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "No lists yet. Create one to get started!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F)
                };
                listsPanel.Controls.Add(emptyLabel);
                return;
            }

            foreach (var list in lists)
            {
                var panel = new Panel
                {
                    Width = 220,
                    Height = 80,
                    BackColor = Color.FromArgb(25, 35, 70), // dark blue
                    Margin = new Padding(8),
                    Cursor = Cursors.Hand
                };

                var nameLabel = new Label
                {
                    Text = list.ListName,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var countLabel = new Label
                {
                    Text = $"{list.MovieCount} film{(list.MovieCount == 1 ? "" : "s")}",
                    Location = new Point(10, 40),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(180, 190, 220) // lighter blue-gray, subtle contrast from title
                };

                panel.Click += (s, e) => ListSelected?.Invoke(this, list);
                nameLabel.Click += (s, e) => ListSelected?.Invoke(this, list);
                countLabel.Click += (s, e) => ListSelected?.Invoke(this, list);

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(countLabel);
                listsPanel.Controls.Add(panel);
            }
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            string listName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter a name for your new list:", "Create List", "");

            if (string.IsNullOrWhiteSpace(listName))
                return;

            MovieListRepository.CreateList(userId, listName, "");
            LoadLists(); // refresh to show the new list
        }
    }
}