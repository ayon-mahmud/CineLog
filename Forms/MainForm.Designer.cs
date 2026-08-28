namespace CineLog.Solution.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            btnHome = new Button();
            btnSearch = new Button();
            btnWatchlist = new Button();
            btnWatched = new Button();
            btnLists = new Button();
            btnProfile = new Button();
            btnLogout = new Button();
            contentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(30, 30, 30);
            sidebarPanel.Controls.Add(btnHome);
            sidebarPanel.Controls.Add(btnSearch);
            sidebarPanel.Controls.Add(btnWatchlist);
            sidebarPanel.Controls.Add(btnWatched);
            sidebarPanel.Controls.Add(btnLists);
            sidebarPanel.Controls.Add(btnProfile);
            sidebarPanel.Controls.Add(btnLogout);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(180, 704);
            sidebarPanel.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Location = new Point(10, 20);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(160, 40);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnSearch
            // 
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(10, 70);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(160, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnWatchlist
            // 
            btnWatchlist.FlatStyle = FlatStyle.Flat;
            btnWatchlist.Location = new Point(10, 120);
            btnWatchlist.Name = "btnWatchlist";
            btnWatchlist.Size = new Size(160, 40);
            btnWatchlist.TabIndex = 2;
            btnWatchlist.Text = "Watchlist";
            btnWatchlist.UseVisualStyleBackColor = true;
            btnWatchlist.Click += btnWatchlist_Click;
            // 
            // btnWatched
            // 
            btnWatched.FlatStyle = FlatStyle.Flat;
            btnWatched.Location = new Point(10, 170);
            btnWatched.Name = "btnWatched";
            btnWatched.Size = new Size(160, 40);
            btnWatched.TabIndex = 3;
            btnWatched.Text = "Watched";
            btnWatched.UseVisualStyleBackColor = true;
            btnWatched.Click += btnWatched_Click;
            // 
            // btnLists
            // 
            btnLists.FlatStyle = FlatStyle.Flat;
            btnLists.Location = new Point(10, 220);
            btnLists.Name = "btnLists";
            btnLists.Size = new Size(160, 40);
            btnLists.TabIndex = 4;
            btnLists.Text = "Lists";
            btnLists.UseVisualStyleBackColor = true;
            btnLists.Click += btnLists_Click;
            // 
            // btnProfile
            // 
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Location = new Point(10, 270);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(160, 40);
            btnProfile.TabIndex = 5;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(10, 639);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(160, 40);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(18, 18, 18);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(180, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(895, 704);
            contentPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 704);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Name = "MainForm";
            Text = "CineLog";
            sidebarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarPanel;
        private Button btnHome;
        private Button btnSearch;
        private Button btnWatchlist;
        private Button btnWatched;
        private Button btnLists;
        private Button btnProfile;
        private Button btnLogout;
        private Panel contentPanel;
    }
}