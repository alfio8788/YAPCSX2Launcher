namespace YAPCSX2Launcher
{
    partial class SkinEditorForm
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
            this.SkinSettingsCancelButton = new System.Windows.Forms.Button();
            this.SkinSettingsSaveButton = new System.Windows.Forms.Button();
            this.colorTestDialog = new System.Windows.Forms.ColorDialog();
            this.previewButton = new System.Windows.Forms.Button();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.BackgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.SplashScreenImageButton = new System.Windows.Forms.Button();
            this.SplashScreenTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListViewBackgroundButton = new System.Windows.Forms.Button();
            this.ListViewTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GridViewBackgroundButton = new System.Windows.Forms.Button();
            this.GridViewTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TvModeBackgroundButton = new System.Windows.Forms.Button();
            this.TvModeTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorsGroupBox = new System.Windows.Forms.GroupBox();
            this.FontColorBox = new System.Windows.Forms.PictureBox();
            this.FontColorConfigButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FormsBackgroundColor = new System.Windows.Forms.PictureBox();
            this.FormBackgroundColorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FontsGroupBox = new System.Windows.Forms.GroupBox();
            this.FontConfigButton = new System.Windows.Forms.Button();
            this.FontTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BackgroundGroupBox.SuspendLayout();
            this.ColorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormsBackgroundColor)).BeginInit();
            this.FontsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SkinSettingsCancelButton
            // 
            this.SkinSettingsCancelButton.Location = new System.Drawing.Point(736, 498);
            this.SkinSettingsCancelButton.Name = "SkinSettingsCancelButton";
            this.SkinSettingsCancelButton.Size = new System.Drawing.Size(75, 23);
            this.SkinSettingsCancelButton.TabIndex = 1;
            this.SkinSettingsCancelButton.Text = "Cancel";
            this.SkinSettingsCancelButton.UseVisualStyleBackColor = true;
            this.SkinSettingsCancelButton.Click += new System.EventHandler(this.SkinSettingsCancelButton_Click);
            // 
            // SkinSettingsSaveButton
            // 
            this.SkinSettingsSaveButton.Location = new System.Drawing.Point(817, 498);
            this.SkinSettingsSaveButton.Name = "SkinSettingsSaveButton";
            this.SkinSettingsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.SkinSettingsSaveButton.TabIndex = 2;
            this.SkinSettingsSaveButton.Text = "Save";
            this.SkinSettingsSaveButton.UseVisualStyleBackColor = true;
            this.SkinSettingsSaveButton.Click += new System.EventHandler(this.SkinSettingsSaveButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(655, 498);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 3;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Visible = false;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // FontDialog
            // 
            this.FontDialog.AllowVerticalFonts = false;
            this.FontDialog.FontMustExist = true;
            this.FontDialog.MaxSize = 16;
            this.FontDialog.ShowEffects = false;
            // 
            // BackgroundGroupBox
            // 
            this.BackgroundGroupBox.Controls.Add(this.SplashScreenImageButton);
            this.BackgroundGroupBox.Controls.Add(this.SplashScreenTextbox);
            this.BackgroundGroupBox.Controls.Add(this.label4);
            this.BackgroundGroupBox.Controls.Add(this.ListViewBackgroundButton);
            this.BackgroundGroupBox.Controls.Add(this.ListViewTextbox);
            this.BackgroundGroupBox.Controls.Add(this.label3);
            this.BackgroundGroupBox.Controls.Add(this.GridViewBackgroundButton);
            this.BackgroundGroupBox.Controls.Add(this.GridViewTextbox);
            this.BackgroundGroupBox.Controls.Add(this.label2);
            this.BackgroundGroupBox.Controls.Add(this.TvModeBackgroundButton);
            this.BackgroundGroupBox.Controls.Add(this.TvModeTextbox);
            this.BackgroundGroupBox.Controls.Add(this.label1);
            this.BackgroundGroupBox.Location = new System.Drawing.Point(12, 12);
            this.BackgroundGroupBox.Name = "BackgroundGroupBox";
            this.BackgroundGroupBox.Size = new System.Drawing.Size(474, 137);
            this.BackgroundGroupBox.TabIndex = 18;
            this.BackgroundGroupBox.TabStop = false;
            this.BackgroundGroupBox.Text = "Backgrounds";
            // 
            // SplashScreenImageButton
            // 
            this.SplashScreenImageButton.Location = new System.Drawing.Point(436, 98);
            this.SplashScreenImageButton.Name = "SplashScreenImageButton";
            this.SplashScreenImageButton.Size = new System.Drawing.Size(25, 20);
            this.SplashScreenImageButton.TabIndex = 21;
            this.SplashScreenImageButton.Text = "...";
            this.SplashScreenImageButton.UseVisualStyleBackColor = true;
            this.SplashScreenImageButton.Visible = false;
            // 
            // SplashScreenTextbox
            // 
            this.SplashScreenTextbox.Enabled = false;
            this.SplashScreenTextbox.Location = new System.Drawing.Point(159, 98);
            this.SplashScreenTextbox.Name = "SplashScreenTextbox";
            this.SplashScreenTextbox.Size = new System.Drawing.Size(271, 20);
            this.SplashScreenTextbox.TabIndex = 20;
            this.SplashScreenTextbox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Splash Screen Image:";
            this.label4.Visible = false;
            // 
            // ListViewBackgroundButton
            // 
            this.ListViewBackgroundButton.Location = new System.Drawing.Point(436, 70);
            this.ListViewBackgroundButton.Name = "ListViewBackgroundButton";
            this.ListViewBackgroundButton.Size = new System.Drawing.Size(25, 20);
            this.ListViewBackgroundButton.TabIndex = 18;
            this.ListViewBackgroundButton.Text = "...";
            this.ListViewBackgroundButton.UseVisualStyleBackColor = true;
            // 
            // ListViewTextbox
            // 
            this.ListViewTextbox.Enabled = false;
            this.ListViewTextbox.Location = new System.Drawing.Point(159, 70);
            this.ListViewTextbox.Name = "ListViewTextbox";
            this.ListViewTextbox.Size = new System.Drawing.Size(271, 20);
            this.ListViewTextbox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "List View Background Image:";
            // 
            // GridViewBackgroundButton
            // 
            this.GridViewBackgroundButton.Location = new System.Drawing.Point(436, 44);
            this.GridViewBackgroundButton.Name = "GridViewBackgroundButton";
            this.GridViewBackgroundButton.Size = new System.Drawing.Size(25, 20);
            this.GridViewBackgroundButton.TabIndex = 15;
            this.GridViewBackgroundButton.Text = "...";
            this.GridViewBackgroundButton.UseVisualStyleBackColor = true;
            // 
            // GridViewTextbox
            // 
            this.GridViewTextbox.Enabled = false;
            this.GridViewTextbox.Location = new System.Drawing.Point(159, 44);
            this.GridViewTextbox.Name = "GridViewTextbox";
            this.GridViewTextbox.Size = new System.Drawing.Size(271, 20);
            this.GridViewTextbox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Grid View Background Image:";
            // 
            // TvModeBackgroundButton
            // 
            this.TvModeBackgroundButton.Location = new System.Drawing.Point(436, 18);
            this.TvModeBackgroundButton.Name = "TvModeBackgroundButton";
            this.TvModeBackgroundButton.Size = new System.Drawing.Size(25, 20);
            this.TvModeBackgroundButton.TabIndex = 12;
            this.TvModeBackgroundButton.Text = "...";
            this.TvModeBackgroundButton.UseVisualStyleBackColor = true;
            // 
            // TvModeTextbox
            // 
            this.TvModeTextbox.Enabled = false;
            this.TvModeTextbox.Location = new System.Drawing.Point(159, 18);
            this.TvModeTextbox.Name = "TvModeTextbox";
            this.TvModeTextbox.Size = new System.Drawing.Size(271, 20);
            this.TvModeTextbox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "TV Mode Background Image:";
            // 
            // ColorsGroupBox
            // 
            this.ColorsGroupBox.Controls.Add(this.FontColorBox);
            this.ColorsGroupBox.Controls.Add(this.FontColorConfigButton);
            this.ColorsGroupBox.Controls.Add(this.label6);
            this.ColorsGroupBox.Controls.Add(this.FormsBackgroundColor);
            this.ColorsGroupBox.Controls.Add(this.FormBackgroundColorButton);
            this.ColorsGroupBox.Controls.Add(this.label5);
            this.ColorsGroupBox.Location = new System.Drawing.Point(12, 155);
            this.ColorsGroupBox.Name = "ColorsGroupBox";
            this.ColorsGroupBox.Size = new System.Drawing.Size(880, 83);
            this.ColorsGroupBox.TabIndex = 17;
            this.ColorsGroupBox.TabStop = false;
            this.ColorsGroupBox.Text = "Colors";
            // 
            // FontColorBox
            // 
            this.FontColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontColorBox.Location = new System.Drawing.Point(138, 45);
            this.FontColorBox.Name = "FontColorBox";
            this.FontColorBox.Size = new System.Drawing.Size(100, 20);
            this.FontColorBox.TabIndex = 11;
            this.FontColorBox.TabStop = false;
            // 
            // FontColorConfigButton
            // 
            this.FontColorConfigButton.Location = new System.Drawing.Point(244, 45);
            this.FontColorConfigButton.Name = "FontColorConfigButton";
            this.FontColorConfigButton.Size = new System.Drawing.Size(25, 20);
            this.FontColorConfigButton.TabIndex = 10;
            this.FontColorConfigButton.Text = "...";
            this.FontColorConfigButton.UseVisualStyleBackColor = true;
            this.FontColorConfigButton.Click += new System.EventHandler(this.FontColorConfigButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Font Color:";
            // 
            // FormsBackgroundColor
            // 
            this.FormsBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormsBackgroundColor.Location = new System.Drawing.Point(138, 19);
            this.FormsBackgroundColor.Name = "FormsBackgroundColor";
            this.FormsBackgroundColor.Size = new System.Drawing.Size(100, 20);
            this.FormsBackgroundColor.TabIndex = 8;
            this.FormsBackgroundColor.TabStop = false;
            // 
            // FormBackgroundColorButton
            // 
            this.FormBackgroundColorButton.Location = new System.Drawing.Point(244, 19);
            this.FormBackgroundColorButton.Name = "FormBackgroundColorButton";
            this.FormBackgroundColorButton.Size = new System.Drawing.Size(25, 20);
            this.FormBackgroundColorButton.TabIndex = 7;
            this.FormBackgroundColorButton.Text = "...";
            this.FormBackgroundColorButton.UseVisualStyleBackColor = true;
            this.FormBackgroundColorButton.Click += new System.EventHandler(this.FormBackgroundColorButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Forms Background Color:";
            // 
            // FontsGroupBox
            // 
            this.FontsGroupBox.Controls.Add(this.FontConfigButton);
            this.FontsGroupBox.Controls.Add(this.FontTextBox);
            this.FontsGroupBox.Controls.Add(this.label7);
            this.FontsGroupBox.Location = new System.Drawing.Point(492, 12);
            this.FontsGroupBox.Name = "FontsGroupBox";
            this.FontsGroupBox.Size = new System.Drawing.Size(400, 137);
            this.FontsGroupBox.TabIndex = 16;
            this.FontsGroupBox.TabStop = false;
            this.FontsGroupBox.Text = "Fonts";
            // 
            // FontConfigButton
            // 
            this.FontConfigButton.Location = new System.Drawing.Point(197, 19);
            this.FontConfigButton.Name = "FontConfigButton";
            this.FontConfigButton.Size = new System.Drawing.Size(25, 20);
            this.FontConfigButton.TabIndex = 5;
            this.FontConfigButton.Text = "...";
            this.FontConfigButton.UseVisualStyleBackColor = true;
            this.FontConfigButton.Click += new System.EventHandler(this.FontConfigButton_Click);
            // 
            // FontTextBox
            // 
            this.FontTextBox.Enabled = false;
            this.FontTextBox.Location = new System.Drawing.Point(43, 19);
            this.FontTextBox.Name = "FontTextBox";
            this.FontTextBox.Size = new System.Drawing.Size(148, 20);
            this.FontTextBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Font:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SkinEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 533);
            this.Controls.Add(this.BackgroundGroupBox);
            this.Controls.Add(this.ColorsGroupBox);
            this.Controls.Add(this.FontsGroupBox);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.SkinSettingsSaveButton);
            this.Controls.Add(this.SkinSettingsCancelButton);
            this.Name = "SkinEditorForm";
            this.Text = "SkinEditorForm";
            this.BackgroundGroupBox.ResumeLayout(false);
            this.BackgroundGroupBox.PerformLayout();
            this.ColorsGroupBox.ResumeLayout(false);
            this.ColorsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormsBackgroundColor)).EndInit();
            this.FontsGroupBox.ResumeLayout(false);
            this.FontsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SkinSettingsCancelButton;
        private System.Windows.Forms.Button SkinSettingsSaveButton;
        private System.Windows.Forms.ColorDialog colorTestDialog;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.GroupBox BackgroundGroupBox;
        private System.Windows.Forms.Button SplashScreenImageButton;
        private System.Windows.Forms.TextBox SplashScreenTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ListViewBackgroundButton;
        private System.Windows.Forms.TextBox ListViewTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button GridViewBackgroundButton;
        private System.Windows.Forms.TextBox GridViewTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TvModeBackgroundButton;
        private System.Windows.Forms.TextBox TvModeTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ColorsGroupBox;
        private System.Windows.Forms.PictureBox FontColorBox;
        private System.Windows.Forms.Button FontColorConfigButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox FormsBackgroundColor;
        private System.Windows.Forms.Button FormBackgroundColorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox FontsGroupBox;
        private System.Windows.Forms.Button FontConfigButton;
        private System.Windows.Forms.TextBox FontTextBox;
        private System.Windows.Forms.Label label7;
    }
}