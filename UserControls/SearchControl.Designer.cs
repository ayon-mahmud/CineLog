namespace CineLog.Solution.UserControls
{
    partial class SearchControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            txtSearchQuery = new TextBox();
            btnSearch = new Button();
            topPanel = new Panel();
            resultsPanel = new FlowLayoutPanel();
            lblDiscover = new Label();
            discoverPanel = new FlowLayoutPanel();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Location = new Point(3, 7);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.Size = new Size(519, 27);
            txtSearchQuery.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(18, 18, 18);
            btnSearch.Dock = DockStyle.Right;
            btnSearch.ForeColor = Color.FromArgb(192, 0, 0);
            btnSearch.Location = new Point(535, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 41);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // topPanel
            // 
            topPanel.AllowDrop = true;
            topPanel.Controls.Add(btnSearch);
            topPanel.Controls.Add(txtSearchQuery);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(675, 41);
            topPanel.TabIndex = 3;
            // 
            // resultsPanel
            // 
            resultsPanel.AutoSize = true;
            resultsPanel.BackColor = Color.FromArgb(18, 18, 18);
            resultsPanel.Dock = DockStyle.Top;
            resultsPanel.Location = new Point(0, 41);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Size = new Size(675, 0);
            resultsPanel.TabIndex = 4;
            // 
            // lblDiscover
            // 
            lblDiscover.AutoSize = true;
            lblDiscover.Dock = DockStyle.Top;
            lblDiscover.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiscover.ForeColor = Color.FromArgb(192, 0, 0);
            lblDiscover.Location = new Point(0, 41);
            lblDiscover.Name = "lblDiscover";
            lblDiscover.Size = new Size(69, 20);
            lblDiscover.TabIndex = 5;
            lblDiscover.Text = "Discover";
            // 
            // discoverPanel
            // 
            discoverPanel.AutoScroll = true;
            discoverPanel.Dock = DockStyle.Fill;
            discoverPanel.Location = new Point(0, 61);
            discoverPanel.Name = "discoverPanel";
            discoverPanel.Size = new Size(675, 487);
            discoverPanel.TabIndex = 6;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(discoverPanel);
            Controls.Add(lblDiscover);
            Controls.Add(resultsPanel);
            Controls.Add(topPanel);
            Name = "SearchControl";
            Size = new Size(675, 548);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchQuery;
        private Button btnSearch;
        private Panel topPanel;
        private FlowLayoutPanel resultsPanel;
        private Label lblDiscover;
        private FlowLayoutPanel discoverPanel;
    }
}