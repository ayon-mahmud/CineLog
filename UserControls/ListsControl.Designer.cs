namespace CineLog.Solution.UserControls
{
    partial class ListsControl
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
            listsPanel = new FlowLayoutPanel();
            btnCreateList = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listsPanel
            // 
            listsPanel.AutoScroll = true;
            listsPanel.Dock = DockStyle.Bottom;
            listsPanel.Location = new Point(0, 69);
            listsPanel.Name = "listsPanel";
            listsPanel.Padding = new Padding(10);
            listsPanel.Size = new Size(480, 382);
            listsPanel.TabIndex = 0;
            // 
            // btnCreateList
            // 
            btnCreateList.BackColor = Color.FromArgb(25, 35, 70);
            btnCreateList.ForeColor = SystemColors.ButtonHighlight;
            btnCreateList.Location = new Point(3, 8);
            btnCreateList.Name = "btnCreateList";
            btnCreateList.Size = new Size(97, 50);
            btnCreateList.TabIndex = 1;
            btnCreateList.Text = "Create List";
            btnCreateList.UseVisualStyleBackColor = false;
            btnCreateList.Click += btnCreateList_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCreateList);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(107, 58);
            panel1.TabIndex = 2;
            // 
            // ListsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(listsPanel);
            Name = "ListsControl";
            Size = new Size(480, 451);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel listsPanel;
        private Button btnCreateList;
        private Panel panel1;
    }
}
