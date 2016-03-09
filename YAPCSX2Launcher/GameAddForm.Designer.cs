namespace YAPCSX2Launcher
{
    partial class GameAddForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manualFillCheckBox = new System.Windows.Forms.CheckBox();
            this.gameDataGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.coverFindButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.coverTextBox = new System.Windows.Forms.TextBox();
            this.compatibilityComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serialTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLocateFile = new System.Windows.Forms.Button();
            this.isoFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.biosComboBox = new System.Windows.Forms.ComboBox();
            this.fullbootSwitch = new System.Windows.Forms.CheckBox();
            this.fromCdSwitch = new System.Windows.Forms.CheckBox();
            this.enableCheatsSwitch = new System.Windows.Forms.CheckBox();
            this.disableHacksSwitch = new System.Windows.Forms.CheckBox();
            this.noguiSwitch = new System.Windows.Forms.CheckBox();
            this.gameAddButton = new System.Windows.Forms.Button();
            this.gameAddCancelButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gameDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 283);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manualFillCheckBox);
            this.tabPage1.Controls.Add(this.gameDataGroupBox);
            this.tabPage1.Controls.Add(this.buttonLocateFile);
            this.tabPage1.Controls.Add(this.isoFileTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 257);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // manualFillCheckBox
            // 
            this.manualFillCheckBox.AutoSize = true;
            this.manualFillCheckBox.Location = new System.Drawing.Point(9, 32);
            this.manualFillCheckBox.Name = "manualFillCheckBox";
            this.manualFillCheckBox.Size = new System.Drawing.Size(154, 17);
            this.manualFillCheckBox.TabIndex = 5;
            this.manualFillCheckBox.Text = "Insert Game Data Manually";
            this.manualFillCheckBox.UseVisualStyleBackColor = true;
            this.manualFillCheckBox.CheckedChanged += new System.EventHandler(this.manualFillCheckBox_CheckedChanged);
            // 
            // gameDataGroupBox
            // 
            this.gameDataGroupBox.Controls.Add(this.pictureBox1);
            this.gameDataGroupBox.Controls.Add(this.coverFindButton);
            this.gameDataGroupBox.Controls.Add(this.label6);
            this.gameDataGroupBox.Controls.Add(this.coverTextBox);
            this.gameDataGroupBox.Controls.Add(this.compatibilityComboBox);
            this.gameDataGroupBox.Controls.Add(this.label5);
            this.gameDataGroupBox.Controls.Add(this.regionTextBox);
            this.gameDataGroupBox.Controls.Add(this.label4);
            this.gameDataGroupBox.Controls.Add(this.nameTextBox);
            this.gameDataGroupBox.Controls.Add(this.label3);
            this.gameDataGroupBox.Controls.Add(this.serialTextBox);
            this.gameDataGroupBox.Controls.Add(this.label2);
            this.gameDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDataGroupBox.Location = new System.Drawing.Point(6, 55);
            this.gameDataGroupBox.Name = "gameDataGroupBox";
            this.gameDataGroupBox.Size = new System.Drawing.Size(612, 201);
            this.gameDataGroupBox.TabIndex = 4;
            this.gameDataGroupBox.TabStop = false;
            this.gameDataGroupBox.Text = "Game Data:";
            this.gameDataGroupBox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(490, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 158);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // coverFindButton
            // 
            this.coverFindButton.Enabled = false;
            this.coverFindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coverFindButton.Location = new System.Drawing.Point(445, 163);
            this.coverFindButton.Margin = new System.Windows.Forms.Padding(5);
            this.coverFindButton.Name = "coverFindButton";
            this.coverFindButton.Size = new System.Drawing.Size(35, 22);
            this.coverFindButton.TabIndex = 7;
            this.coverFindButton.Text = "...";
            this.coverFindButton.UseVisualStyleBackColor = true;
            this.coverFindButton.Click += new System.EventHandler(this.coverFindButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cover:";
            // 
            // coverTextBox
            // 
            this.coverTextBox.Enabled = false;
            this.coverTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coverTextBox.Location = new System.Drawing.Point(114, 163);
            this.coverTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.coverTextBox.Name = "coverTextBox";
            this.coverTextBox.Size = new System.Drawing.Size(321, 22);
            this.coverTextBox.TabIndex = 6;
            // 
            // compatibilityComboBox
            // 
            this.compatibilityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compatibilityComboBox.Enabled = false;
            this.compatibilityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compatibilityComboBox.FormattingEnabled = true;
            this.compatibilityComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.compatibilityComboBox.Location = new System.Drawing.Point(114, 129);
            this.compatibilityComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.compatibilityComboBox.Name = "compatibilityComboBox";
            this.compatibilityComboBox.Size = new System.Drawing.Size(121, 24);
            this.compatibilityComboBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Compatibility:";
            // 
            // regionTextBox
            // 
            this.regionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.regionTextBox.Enabled = false;
            this.regionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionTextBox.Location = new System.Drawing.Point(114, 80);
            this.regionTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(130, 15);
            this.regionTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Region:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(114, 105);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(321, 15);
            this.nameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // serialTextBox
            // 
            this.serialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialTextBox.Enabled = false;
            this.serialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialTextBox.Location = new System.Drawing.Point(114, 55);
            this.serialTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.serialTextBox.Name = "serialTextBox";
            this.serialTextBox.Size = new System.Drawing.Size(130, 15);
            this.serialTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serial:";
            // 
            // buttonLocateFile
            // 
            this.buttonLocateFile.Location = new System.Drawing.Point(593, 6);
            this.buttonLocateFile.Name = "buttonLocateFile";
            this.buttonLocateFile.Size = new System.Drawing.Size(25, 20);
            this.buttonLocateFile.TabIndex = 2;
            this.buttonLocateFile.Text = "...";
            this.buttonLocateFile.UseVisualStyleBackColor = true;
            this.buttonLocateFile.Click += new System.EventHandler(this.buttonLocateFile_Click);
            // 
            // isoFileTextBox
            // 
            this.isoFileTextBox.Enabled = false;
            this.isoFileTextBox.Location = new System.Drawing.Point(95, 6);
            this.isoFileTextBox.Name = "isoFileTextBox";
            this.isoFileTextBox.Size = new System.Drawing.Size(492, 20);
            this.isoFileTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Location:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.biosComboBox);
            this.tabPage2.Controls.Add(this.fullbootSwitch);
            this.tabPage2.Controls.Add(this.fromCdSwitch);
            this.tabPage2.Controls.Add(this.enableCheatsSwitch);
            this.tabPage2.Controls.Add(this.disableHacksSwitch);
            this.tabPage2.Controls.Add(this.noguiSwitch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(624, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "BIOS:";
            // 
            // biosComboBox
            // 
            this.biosComboBox.FormattingEnabled = true;
            this.biosComboBox.Location = new System.Drawing.Point(44, 12);
            this.biosComboBox.Name = "biosComboBox";
            this.biosComboBox.Size = new System.Drawing.Size(219, 21);
            this.biosComboBox.TabIndex = 5;
            // 
            // fullbootSwitch
            // 
            this.fullbootSwitch.AutoSize = true;
            this.fullbootSwitch.Location = new System.Drawing.Point(6, 131);
            this.fullbootSwitch.Name = "fullbootSwitch";
            this.fullbootSwitch.Size = new System.Drawing.Size(67, 17);
            this.fullbootSwitch.TabIndex = 4;
            this.fullbootSwitch.Text = "Full Boot";
            this.fullbootSwitch.UseVisualStyleBackColor = true;
            // 
            // fromCdSwitch
            // 
            this.fromCdSwitch.AutoSize = true;
            this.fromCdSwitch.Location = new System.Drawing.Point(6, 108);
            this.fromCdSwitch.Name = "fromCdSwitch";
            this.fromCdSwitch.Size = new System.Drawing.Size(67, 17);
            this.fromCdSwitch.TabIndex = 3;
            this.fromCdSwitch.Text = "From CD";
            this.fromCdSwitch.UseVisualStyleBackColor = true;
            // 
            // enableCheatsSwitch
            // 
            this.enableCheatsSwitch.AutoSize = true;
            this.enableCheatsSwitch.Location = new System.Drawing.Point(6, 85);
            this.enableCheatsSwitch.Name = "enableCheatsSwitch";
            this.enableCheatsSwitch.Size = new System.Drawing.Size(95, 17);
            this.enableCheatsSwitch.TabIndex = 2;
            this.enableCheatsSwitch.Text = "Enable Cheats";
            this.enableCheatsSwitch.UseVisualStyleBackColor = true;
            // 
            // disableHacksSwitch
            // 
            this.disableHacksSwitch.AutoSize = true;
            this.disableHacksSwitch.Location = new System.Drawing.Point(6, 62);
            this.disableHacksSwitch.Name = "disableHacksSwitch";
            this.disableHacksSwitch.Size = new System.Drawing.Size(95, 17);
            this.disableHacksSwitch.TabIndex = 1;
            this.disableHacksSwitch.Text = "Disable Hacks";
            this.disableHacksSwitch.UseVisualStyleBackColor = true;
            // 
            // noguiSwitch
            // 
            this.noguiSwitch.AutoSize = true;
            this.noguiSwitch.Location = new System.Drawing.Point(6, 39);
            this.noguiSwitch.Name = "noguiSwitch";
            this.noguiSwitch.Size = new System.Drawing.Size(62, 17);
            this.noguiSwitch.TabIndex = 0;
            this.noguiSwitch.Text = "No GUI";
            this.noguiSwitch.UseVisualStyleBackColor = true;
            // 
            // gameAddButton
            // 
            this.gameAddButton.Location = new System.Drawing.Point(566, 295);
            this.gameAddButton.Name = "gameAddButton";
            this.gameAddButton.Size = new System.Drawing.Size(75, 23);
            this.gameAddButton.TabIndex = 0;
            this.gameAddButton.Text = "Save";
            this.gameAddButton.UseVisualStyleBackColor = true;
            this.gameAddButton.Click += new System.EventHandler(this.gameAddButton_Click);
            // 
            // gameAddCancelButton
            // 
            this.gameAddCancelButton.Location = new System.Drawing.Point(485, 295);
            this.gameAddCancelButton.Name = "gameAddCancelButton";
            this.gameAddCancelButton.Size = new System.Drawing.Size(75, 23);
            this.gameAddCancelButton.TabIndex = 1;
            this.gameAddCancelButton.Text = "Cancel";
            this.gameAddCancelButton.UseVisualStyleBackColor = true;
            this.gameAddCancelButton.Click += new System.EventHandler(this.gameAddCancelButton_Click);
            // 
            // GameAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 326);
            this.Controls.Add(this.gameAddCancelButton);
            this.Controls.Add(this.gameAddButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameAddForm";
            this.Text = "GameAddForm";
            this.Load += new System.EventHandler(this.GameAddForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gameDataGroupBox.ResumeLayout(false);
            this.gameDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button gameAddButton;
        private System.Windows.Forms.Button gameAddCancelButton;
        private System.Windows.Forms.Button buttonLocateFile;
        private System.Windows.Forms.TextBox isoFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gameDataGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox manualFillCheckBox;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox compatibilityComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button coverFindButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox coverTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox biosComboBox;
        private System.Windows.Forms.CheckBox fullbootSwitch;
        private System.Windows.Forms.CheckBox fromCdSwitch;
        private System.Windows.Forms.CheckBox enableCheatsSwitch;
        private System.Windows.Forms.CheckBox disableHacksSwitch;
        private System.Windows.Forms.CheckBox noguiSwitch;
    }
}