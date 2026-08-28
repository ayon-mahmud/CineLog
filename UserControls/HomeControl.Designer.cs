namespace CineLog.Solution.UserControls
{
    partial class HomeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSectionTrending = new Label();
            trendingPanel = new FlowLayoutPanel();
            upcomingPanel = new FlowLayoutPanel();
            lblSectionUpcoming = new Label();
            SuspendLayout();
            // 
            // lblSectionTrending
            // 
            lblSectionTrending.AutoSize = true;
            lblSectionTrending.Dock = DockStyle.Top;
            lblSectionTrending.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionTrending.ForeColor = Color.FromArgb(192, 0, 0);
            lblSectionTrending.Location = new Point(0, 0);
            lblSectionTrending.Name = "lblSectionTrending";
            lblSectionTrending.Size = new Size(217, 31);
            lblSectionTrending.TabIndex = 0;
            lblSectionTrending.Text = "Trending This Week";
            // 
            // trendingPanel
            // 
            trendingPanel.AutoScroll = true;
            trendingPanel.Dock = DockStyle.Top;
            trendingPanel.Location = new Point(0, 31);
            trendingPanel.Name = "trendingPanel";
            trendingPanel.Size = new Size(546, 231);
            trendingPanel.TabIndex = 1;
            trendingPanel.WrapContents = false;
            // 
            // upcomingPanel
            // 
            upcomingPanel.AutoScroll = true;
            upcomingPanel.Dock = DockStyle.Bottom;
            upcomingPanel.Location = new Point(0, 362);
            upcomingPanel.Name = "upcomingPanel";
            upcomingPanel.Size = new Size(546, 246);
            upcomingPanel.TabIndex = 2;
            upcomingPanel.WrapContents = false;
            // 
            // lblSectionUpcoming
            // 
            lblSectionUpcoming.AutoSize = true;
            lblSectionUpcoming.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionUpcoming.ForeColor = Color.FromArgb(192, 0, 0);
            lblSectionUpcoming.Location = new Point(0, 337);
            lblSectionUpcoming.Name = "lblSectionUpcoming";
            lblSectionUpcoming.Size = new Size(128, 31);
            lblSectionUpcoming.TabIndex = 3;
            lblSectionUpcoming.Text = "Upcoming ";
            lblSectionUpcoming.Click += lblSectionUpcoming_Click;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            Controls.Add(lblSectionUpcoming);
            Controls.Add(upcomingPanel);
            Controls.Add(trendingPanel);
            Controls.Add(lblSectionTrending);
            Name = "HomeControl";
            Size = new Size(546, 608);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSectionTrending;
        private FlowLayoutPanel trendingPanel;
        private FlowLayoutPanel upcomingPanel;
        private Label lblSectionUpcoming;
    }
}
