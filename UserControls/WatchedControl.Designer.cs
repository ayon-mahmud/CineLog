namespace CineLog.Solution.UserControls
{
    partial class WatchedControl
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
            SuspendLayout();
            // 
            // resultsPanel
            // 
            resultsPanel.AutoScroll = true;
            resultsPanel.Dock = DockStyle.Fill;
            resultsPanel.Location = new Point(0, 0);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Padding = new Padding(10);
            resultsPanel.Size = new Size(473, 373);
            resultsPanel.TabIndex = 0;
            // 
            // WatchedControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(resultsPanel);
            Name = "WatchedControl";
            Size = new Size(473, 373);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel resultsPanel;
    }
}
