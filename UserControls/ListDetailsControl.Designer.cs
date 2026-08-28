namespace CineLog.Solution.UserControls
{
    partial class ListDetailsControl
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
            resultsPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            btnBack = new Button();
            lblListTitle = new Label();
            resultsPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // resultsPanel
            // 
            resultsPanel.AutoScroll = true;
            resultsPanel.Controls.Add(panel1);
            resultsPanel.Dock = DockStyle.Fill;
            resultsPanel.Location = new Point(0, 0);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Padding = new Padding(10);
            resultsPanel.Size = new Size(494, 478);
            resultsPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lblListTitle);
            panel1.Location = new Point(13, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(175, 34);
            panel1.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ActiveCaption;
            btnBack.Location = new Point(72, 1);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 1;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblListTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblListTitle.Location = new Point(3, 1);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(63, 28);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "label1";
            // 
            // ListDetailsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(resultsPanel);
            Name = "ListDetailsControl";
            Size = new Size(494, 478);
            resultsPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel resultsPanel;
        private Label lblListTitle;
        private Panel panel1;
        private Button btnBack;
    }
}
