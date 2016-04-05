namespace YAPCSX2Launcher
{
    partial class FullScreenForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FullscreenPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // FullscreenPanel
            // 
            this.FullscreenPanel.AutoScroll = true;
            this.FullscreenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullscreenPanel.Location = new System.Drawing.Point(0, 0);
            this.FullscreenPanel.Name = "FullscreenPanel";
            this.FullscreenPanel.Size = new System.Drawing.Size(1029, 556);
            this.FullscreenPanel.TabIndex = 0;
            // 
            // FullScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 556);
            this.ControlBox = false;
            this.Controls.Add(this.FullscreenPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullScreenForm";
            this.Text = "FullScreenForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FullscreenPanel;
    }
}