namespace CineLog.Solution.UserControls
{
    partial class MovieCard
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
            lblYear = new Label();
            lblRating = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPoster
            // 
            pictureBoxPoster.Location = new Point(3, 3);
            pictureBoxPoster.Name = "pictureBoxPoster";
            pictureBoxPoster.Size = new Size(162, 107);
            pictureBoxPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPoster.TabIndex = 0;
            pictureBoxPoster.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.Crimson;
            lblTitle.Location = new Point(52, 125);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(50, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "label1";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.ForeColor = Color.FromArgb(192, 0, 0);
            lblYear.Location = new Point(52, 154);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(50, 20);
            lblYear.TabIndex = 2;
            lblYear.Text = "label1";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.ForeColor = Color.FromArgb(192, 0, 0);
            lblRating.Location = new Point(52, 187);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(50, 20);
            lblRating.TabIndex = 3;
            lblRating.Text = "label1";
            lblRating.Click += MovieCard_Click;
            // 
            // MovieCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(lblRating);
            Controls.Add(lblYear);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxPoster);
            Name = "MovieCard";
            Size = new Size(168, 214);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxPoster;
        private Label lblTitle;
        private Label lblYear;
        private Label lblRating;
    }
}
