namespace CineLog.Solution.UserControls
{
    partial class ProfileControl
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
            lblUsername = new Label();
            lblEmail = new Label();
            lblAvgRating = new Label();
            lblListCount = new Label();
            lblWatchedCount = new Label();
            btnDeleteAccount = new Button();
            pictureBoxAvatar = new PictureBox();
            btnChangePicture = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(192, 0, 0);
            lblUsername.Location = new Point(27, 195);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(79, 31);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "label1";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(192, 0, 0);
            lblEmail.Location = new Point(27, 237);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 25);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "label1";
            // 
            // lblAvgRating
            // 
            lblAvgRating.AutoSize = true;
            lblAvgRating.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvgRating.ForeColor = Color.FromArgb(192, 0, 0);
            lblAvgRating.Location = new Point(277, 328);
            lblAvgRating.Name = "lblAvgRating";
            lblAvgRating.Size = new Size(59, 25);
            lblAvgRating.TabIndex = 2;
            lblAvgRating.Text = "label1";
            // 
            // lblListCount
            // 
            lblListCount.AutoSize = true;
            lblListCount.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblListCount.ForeColor = Color.FromArgb(192, 0, 0);
            lblListCount.Location = new Point(139, 328);
            lblListCount.Name = "lblListCount";
            lblListCount.Size = new Size(59, 25);
            lblListCount.TabIndex = 3;
            lblListCount.Text = "label1";
            // 
            // lblWatchedCount
            // 
            lblWatchedCount.AutoSize = true;
            lblWatchedCount.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWatchedCount.ForeColor = Color.FromArgb(192, 0, 0);
            lblWatchedCount.Location = new Point(27, 328);
            lblWatchedCount.Name = "lblWatchedCount";
            lblWatchedCount.Size = new Size(59, 25);
            lblWatchedCount.TabIndex = 4;
            lblWatchedCount.Text = "label1";
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackColor = Color.Black;
            btnDeleteAccount.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteAccount.ForeColor = Color.FromArgb(224, 224, 224);
            btnDeleteAccount.Location = new Point(27, 442);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(141, 29);
            btnDeleteAccount.TabIndex = 5;
            btnDeleteAccount.Text = "Delete Account ";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // pictureBoxAvatar
            // 
            pictureBoxAvatar.Location = new Point(27, 3);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(150, 150);
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAvatar.TabIndex = 6;
            pictureBoxAvatar.TabStop = false;
            // 
            // btnChangePicture
            // 
            btnChangePicture.BackColor = Color.Black;
            btnChangePicture.Font = new Font("Segoe UI Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangePicture.ForeColor = Color.Silver;
            btnChangePicture.Location = new Point(74, 156);
            btnChangePicture.Name = "btnChangePicture";
            btnChangePicture.Size = new Size(103, 23);
            btnChangePicture.TabIndex = 7;
            btnChangePicture.Text = "Change Picture";
            btnChangePicture.UseVisualStyleBackColor = false;
            btnChangePicture.Click += btnChangePicture_Click;
            // 
            // ProfileControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            Controls.Add(btnChangePicture);
            Controls.Add(pictureBoxAvatar);
            Controls.Add(btnDeleteAccount);
            Controls.Add(lblWatchedCount);
            Controls.Add(lblListCount);
            Controls.Add(lblAvgRating);
            Controls.Add(lblEmail);
            Controls.Add(lblUsername);
            Margin = new Padding(0);
            Name = "ProfileControl";
            Size = new Size(502, 498);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblEmail;
        private Label lblAvgRating;
        private Label lblListCount;
        private Label lblWatchedCount;
        private Button btnDeleteAccount;
        private PictureBox pictureBoxAvatar;
        private Button btnChangePicture;
    }
}
