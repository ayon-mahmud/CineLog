namespace CineLog.Solution.UserControls
{
    partial class MovieDetailsControl
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
            pictureBoxPoster = new PictureBox();
            lblTitle = new Label();
            lblMeta = new Label();
            lblOverview = new Label();
            btnMarkWatched = new Button();
            btnAddWatchlist = new Button();
            btnBack = new Button();
            btnRate1 = new Button();
            btnRate2 = new Button();
            btnRate3 = new Button();
            btnRate4 = new Button();
            btnRate5 = new Button();
            lblCurrentRating = new Label();
            txtReview = new TextBox();
            btnSubmitReview = new Button();
            btnAddToList = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPoster
            // 
            pictureBoxPoster.Location = new Point(3, 87);
            pictureBoxPoster.Name = "pictureBoxPoster";
            pictureBoxPoster.Size = new Size(219, 374);
            pictureBoxPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPoster.TabIndex = 0;
            pictureBoxPoster.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(232, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(73, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "label1";
            // 
            // lblMeta
            // 
            lblMeta.AutoSize = true;
            lblMeta.Font = new Font("Segoe UI Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMeta.ForeColor = Color.FromArgb(192, 0, 0);
            lblMeta.Location = new Point(243, 85);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(49, 23);
            lblMeta.TabIndex = 2;
            lblMeta.Text = "label1";
            // 
            // lblOverview
            // 
            lblOverview.ForeColor = Color.FromArgb(192, 0, 0);
            lblOverview.Location = new Point(243, 118);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(62, 25);
            lblOverview.TabIndex = 3;
            lblOverview.Text = "label1";
            lblOverview.Click += lblOverview_Click;
            // 
            // btnMarkWatched
            // 
            btnMarkWatched.ForeColor = Color.CornflowerBlue;
            btnMarkWatched.Location = new Point(229, 168);
            btnMarkWatched.Name = "btnMarkWatched";
            btnMarkWatched.Size = new Size(117, 29);
            btnMarkWatched.TabIndex = 4;
            btnMarkWatched.Text = "Mark Watched";
            btnMarkWatched.UseVisualStyleBackColor = true;
            btnMarkWatched.Click += btnMarkWatched_Click;
            // 
            // btnAddWatchlist
            // 
            btnAddWatchlist.ForeColor = SystemColors.Highlight;
            btnAddWatchlist.Location = new Point(229, 203);
            btnAddWatchlist.Name = "btnAddWatchlist";
            btnAddWatchlist.Size = new Size(131, 29);
            btnAddWatchlist.TabIndex = 5;
            btnAddWatchlist.Text = "Add to Watchlist";
            btnAddWatchlist.UseVisualStyleBackColor = true;
            btnAddWatchlist.Click += btnAddWatchlist_Click;
            // 
            // btnBack
            // 
            btnBack.ForeColor = SystemColors.HotTrack;
            btnBack.Location = new Point(390, 528);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 6;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnRate1
            // 
            btnRate1.BackColor = SystemColors.ActiveCaption;
            btnRate1.Location = new Point(228, 308);
            btnRate1.Name = "btnRate1";
            btnRate1.Size = new Size(27, 36);
            btnRate1.TabIndex = 7;
            btnRate1.Text = "1";
            btnRate1.UseVisualStyleBackColor = false;
            btnRate1.Click += btnRate1_Click;
            // 
            // btnRate2
            // 
            btnRate2.BackColor = SystemColors.ActiveCaption;
            btnRate2.Location = new Point(265, 308);
            btnRate2.Name = "btnRate2";
            btnRate2.Size = new Size(27, 36);
            btnRate2.TabIndex = 8;
            btnRate2.Text = "2";
            btnRate2.UseVisualStyleBackColor = false;
            btnRate2.Click += btnRate2_Click;
            // 
            // btnRate3
            // 
            btnRate3.BackColor = SystemColors.ActiveCaption;
            btnRate3.Location = new Point(298, 308);
            btnRate3.Name = "btnRate3";
            btnRate3.Size = new Size(27, 36);
            btnRate3.TabIndex = 9;
            btnRate3.Text = "3";
            btnRate3.UseVisualStyleBackColor = false;
            btnRate3.Click += btnRate3_Click;
            // 
            // btnRate4
            // 
            btnRate4.BackColor = SystemColors.ActiveCaption;
            btnRate4.Location = new Point(333, 308);
            btnRate4.Name = "btnRate4";
            btnRate4.Size = new Size(27, 36);
            btnRate4.TabIndex = 10;
            btnRate4.Text = "4";
            btnRate4.UseVisualStyleBackColor = false;
            btnRate4.Click += btnRate4_Click;
            // 
            // btnRate5
            // 
            btnRate5.BackColor = SystemColors.ActiveCaption;
            btnRate5.Location = new Point(366, 308);
            btnRate5.Name = "btnRate5";
            btnRate5.Size = new Size(27, 36);
            btnRate5.TabIndex = 11;
            btnRate5.Text = "5";
            btnRate5.UseVisualStyleBackColor = false;
            btnRate5.Click += btnRate5_Click;
            // 
            // lblCurrentRating
            // 
            lblCurrentRating.AutoSize = true;
            lblCurrentRating.ForeColor = SystemColors.HotTrack;
            lblCurrentRating.Location = new Point(228, 347);
            lblCurrentRating.Name = "lblCurrentRating";
            lblCurrentRating.Size = new Size(39, 20);
            lblCurrentRating.TabIndex = 12;
            lblCurrentRating.Text = "Rate";
            lblCurrentRating.Click += label1_Click;
            // 
            // txtReview
            // 
            txtReview.Location = new Point(228, 401);
            txtReview.Multiline = true;
            txtReview.Name = "txtReview";
            txtReview.Size = new Size(246, 60);
            txtReview.TabIndex = 13;
            txtReview.TextChanged += textBox1_TextChanged;
            // 
            // btnSubmitReview
            // 
            btnSubmitReview.BackColor = SystemColors.AppWorkspace;
            btnSubmitReview.ForeColor = SystemColors.HotTrack;
            btnSubmitReview.Location = new Point(228, 478);
            btnSubmitReview.Name = "btnSubmitReview";
            btnSubmitReview.Size = new Size(71, 32);
            btnSubmitReview.TabIndex = 14;
            btnSubmitReview.Text = "Submit";
            btnSubmitReview.UseVisualStyleBackColor = false;
            btnSubmitReview.Click += btnSubmitReview_Click;
            // 
            // btnAddToList
            // 
            btnAddToList.BackColor = SystemColors.ButtonHighlight;
            btnAddToList.ForeColor = SystemColors.Highlight;
            btnAddToList.Location = new Point(229, 251);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(117, 29);
            btnAddToList.TabIndex = 15;
            btnAddToList.Text = "Add to List";
            btnAddToList.UseVisualStyleBackColor = false;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // MovieDetailsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddToList);
            Controls.Add(btnSubmitReview);
            Controls.Add(txtReview);
            Controls.Add(lblCurrentRating);
            Controls.Add(btnRate5);
            Controls.Add(btnRate4);
            Controls.Add(btnRate3);
            Controls.Add(btnRate2);
            Controls.Add(btnRate1);
            Controls.Add(btnBack);
            Controls.Add(btnAddWatchlist);
            Controls.Add(btnMarkWatched);
            Controls.Add(lblOverview);
            Controls.Add(lblMeta);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxPoster);
            Name = "MovieDetailsControl";
            Size = new Size(494, 572);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxPoster;
        private Label lblTitle;
        private Label lblMeta;
        private Label lblOverview;
        private Button btnMarkWatched;
        private Button btnAddWatchlist;
        private Button btnBack;
        private Button btnRate1;
        private Button btnRate2;
        private Button btnRate3;
        private Button btnRate4;
        private Button btnRate5;
        private Label lblCurrentRating;
        private TextBox txtReview;
        private Button btnSubmitReview;
        private Button btnAddToList;
    }
}
