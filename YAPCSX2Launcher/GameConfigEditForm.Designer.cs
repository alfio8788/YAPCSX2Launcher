namespace YAPCSX2Launcher
{
    partial class GameConfigEditForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.biosComboBox = new System.Windows.Forms.ComboBox();
            this.fullbootSwitch = new System.Windows.Forms.CheckBox();
            this.fromCdSwitch = new System.Windows.Forms.CheckBox();
            this.enableCheatsSwitch = new System.Windows.Forms.CheckBox();
            this.disableHacksSwitch = new System.Windows.Forms.CheckBox();
            this.noguiSwitch = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CustomExecutableButton = new System.Windows.Forms.Button();
            this.CustomExecutableTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.WideScreenSupportCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "BIOS:";
            // 
            // biosComboBox
            // 
            this.biosComboBox.FormattingEnabled = true;
            this.biosComboBox.Location = new System.Drawing.Point(60, 32);
            this.biosComboBox.Name = "biosComboBox";
            this.biosComboBox.Size = new System.Drawing.Size(219, 21);
            this.biosComboBox.TabIndex = 12;
            // 
            // fullbootSwitch
            // 
            this.fullbootSwitch.AutoSize = true;
            this.fullbootSwitch.Location = new System.Drawing.Point(12, 151);
            this.fullbootSwitch.Name = "fullbootSwitch";
            this.fullbootSwitch.Size = new System.Drawing.Size(67, 17);
            this.fullbootSwitch.TabIndex = 11;
            this.fullbootSwitch.Text = "Full Boot";
            this.fullbootSwitch.UseVisualStyleBackColor = true;
            // 
            // fromCdSwitch
            // 
            this.fromCdSwitch.AutoSize = true;
            this.fromCdSwitch.Location = new System.Drawing.Point(12, 128);
            this.fromCdSwitch.Name = "fromCdSwitch";
            this.fromCdSwitch.Size = new System.Drawing.Size(67, 17);
            this.fromCdSwitch.TabIndex = 10;
            this.fromCdSwitch.Text = "From CD";
            this.fromCdSwitch.UseVisualStyleBackColor = true;
            // 
            // enableCheatsSwitch
            // 
            this.enableCheatsSwitch.AutoSize = true;
            this.enableCheatsSwitch.Location = new System.Drawing.Point(12, 105);
            this.enableCheatsSwitch.Name = "enableCheatsSwitch";
            this.enableCheatsSwitch.Size = new System.Drawing.Size(95, 17);
            this.enableCheatsSwitch.TabIndex = 9;
            this.enableCheatsSwitch.Text = "Enable Cheats";
            this.enableCheatsSwitch.UseVisualStyleBackColor = true;
            // 
            // disableHacksSwitch
            // 
            this.disableHacksSwitch.AutoSize = true;
            this.disableHacksSwitch.Location = new System.Drawing.Point(12, 82);
            this.disableHacksSwitch.Name = "disableHacksSwitch";
            this.disableHacksSwitch.Size = new System.Drawing.Size(95, 17);
            this.disableHacksSwitch.TabIndex = 8;
            this.disableHacksSwitch.Text = "Disable Hacks";
            this.disableHacksSwitch.UseVisualStyleBackColor = true;
            // 
            // noguiSwitch
            // 
            this.noguiSwitch.AutoSize = true;
            this.noguiSwitch.Location = new System.Drawing.Point(12, 59);
            this.noguiSwitch.Name = "noguiSwitch";
            this.noguiSwitch.Size = new System.Drawing.Size(62, 17);
            this.noguiSwitch.TabIndex = 7;
            this.noguiSwitch.Text = "No GUI";
            this.noguiSwitch.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(462, 186);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(381, 186);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CustomExecutableButton
            // 
            this.CustomExecutableButton.Location = new System.Drawing.Point(512, 6);
            this.CustomExecutableButton.Name = "CustomExecutableButton";
            this.CustomExecutableButton.Size = new System.Drawing.Size(25, 20);
            this.CustomExecutableButton.TabIndex = 18;
            this.CustomExecutableButton.Text = "...";
            this.CustomExecutableButton.UseVisualStyleBackColor = true;
            this.CustomExecutableButton.Click += new System.EventHandler(this.CustomExecutableButton_Click);
            // 
            // CustomExecutableTextBox
            // 
            this.CustomExecutableTextBox.Enabled = false;
            this.CustomExecutableTextBox.Location = new System.Drawing.Point(178, 6);
            this.CustomExecutableTextBox.Name = "CustomExecutableTextBox";
            this.CustomExecutableTextBox.Size = new System.Drawing.Size(328, 20);
            this.CustomExecutableTextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Custom PCSX2 Executable Path:";
            // 
            // WideScreenSupportCheckbox
            // 
            this.WideScreenSupportCheckbox.AutoSize = true;
            this.WideScreenSupportCheckbox.Location = new System.Drawing.Point(12, 174);
            this.WideScreenSupportCheckbox.Name = "WideScreenSupportCheckbox";
            this.WideScreenSupportCheckbox.Size = new System.Drawing.Size(161, 17);
            this.WideScreenSupportCheckbox.TabIndex = 19;
            this.WideScreenSupportCheckbox.Text = "Enable Widescreen Patches";
            this.WideScreenSupportCheckbox.UseMnemonic = false;
            this.WideScreenSupportCheckbox.UseVisualStyleBackColor = true;
            // 
            // GameConfigEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(549, 221);
            this.Controls.Add(this.WideScreenSupportCheckbox);
            this.Controls.Add(this.CustomExecutableButton);
            this.Controls.Add(this.CustomExecutableTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.biosComboBox);
            this.Controls.Add(this.fullbootSwitch);
            this.Controls.Add(this.fromCdSwitch);
            this.Controls.Add(this.enableCheatsSwitch);
            this.Controls.Add(this.disableHacksSwitch);
            this.Controls.Add(this.noguiSwitch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameConfigEditForm";
            this.Text = "Edit Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox biosComboBox;
        private System.Windows.Forms.CheckBox fullbootSwitch;
        private System.Windows.Forms.CheckBox fromCdSwitch;
        private System.Windows.Forms.CheckBox enableCheatsSwitch;
        private System.Windows.Forms.CheckBox disableHacksSwitch;
        private System.Windows.Forms.CheckBox noguiSwitch;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button CustomExecutableButton;
        private System.Windows.Forms.TextBox CustomExecutableTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox WideScreenSupportCheckbox;
    }
}