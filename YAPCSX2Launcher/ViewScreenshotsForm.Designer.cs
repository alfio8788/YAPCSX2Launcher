namespace YAPCSX2Launcher
{
    partial class ViewScreenshotsForm
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
            this.components = new System.ComponentModel.Container();
            this.closeButtonImage = new System.Windows.Forms.PictureBox();
            this.olvColumnId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSsId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bigScreenshotBox = new System.Windows.Forms.PictureBox();
            this.ScreenshotMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigScreenshotBox)).BeginInit();
            this.ScreenshotMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonImage.Image = global::YAPCSX2Launcher.Properties.Resources.close_image;
            this.closeButtonImage.Location = new System.Drawing.Point(736, 0);
            this.closeButtonImage.Margin = new System.Windows.Forms.Padding(0);
            this.closeButtonImage.Name = "closeButtonImage";
            this.closeButtonImage.Size = new System.Drawing.Size(25, 25);
            this.closeButtonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButtonImage.TabIndex = 0;
            this.closeButtonImage.TabStop = false;
            this.closeButtonImage.Click += new System.EventHandler(this.closeButtonImage_Click);
            // 
            // olvColumnId
            // 
            this.olvColumnId.AspectName = "id";
            this.olvColumnId.AutoCompleteEditor = false;
            this.olvColumnId.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvColumnId.DisplayIndex = 0;
            this.olvColumnId.Groupable = false;
            this.olvColumnId.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.olvColumnId.Hideable = false;
            this.olvColumnId.IsEditable = false;
            this.olvColumnId.IsVisible = false;
            this.olvColumnId.Searchable = false;
            this.olvColumnId.ShowTextInHeader = false;
            this.olvColumnId.Sortable = false;
            this.olvColumnId.Text = "ID";
            this.olvColumnId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnId.UseFiltering = false;
            this.olvColumnId.Width = 139;
            // 
            // olvColumnSsId
            // 
            this.olvColumnSsId.AspectName = "id";
            this.olvColumnSsId.DisplayIndex = 1;
            this.olvColumnSsId.IsVisible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 517);
            this.panel1.TabIndex = 2;
            // 
            // bigScreenshotBox
            // 
            this.bigScreenshotBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bigScreenshotBox.BackColor = System.Drawing.SystemColors.Control;
            this.bigScreenshotBox.Location = new System.Drawing.Point(203, 28);
            this.bigScreenshotBox.Name = "bigScreenshotBox";
            this.bigScreenshotBox.Size = new System.Drawing.Size(546, 517);
            this.bigScreenshotBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bigScreenshotBox.TabIndex = 0;
            this.bigScreenshotBox.TabStop = false;
            // 
            // ScreenshotMenu
            // 
            this.ScreenshotMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeScreenshotToolStripMenuItem});
            this.ScreenshotMenu.Name = "ScreenshotMenu";
            this.ScreenshotMenu.Size = new System.Drawing.Size(178, 48);
            // 
            // removeScreenshotToolStripMenuItem
            // 
            this.removeScreenshotToolStripMenuItem.Name = "removeScreenshotToolStripMenuItem";
            this.removeScreenshotToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removeScreenshotToolStripMenuItem.Text = "&Remove screenshot";
            this.removeScreenshotToolStripMenuItem.Click += new System.EventHandler(this.removeScreenshotToolStripMenuItem_Click);
            // 
            // ViewScreenshotsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 557);
            this.ControlBox = false;
            this.Controls.Add(this.bigScreenshotBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeButtonImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewScreenshotsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewScreenshotsForm";
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigScreenshotBox)).EndInit();
            this.ScreenshotMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox closeButtonImage;
        private BrightIdeasSoftware.OLVColumn olvColumnId;
        private BrightIdeasSoftware.OLVColumn olvColumnSsId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox bigScreenshotBox;
        private System.Windows.Forms.ContextMenuStrip ScreenshotMenu;
        private System.Windows.Forms.ToolStripMenuItem removeScreenshotToolStripMenuItem;
    }
}