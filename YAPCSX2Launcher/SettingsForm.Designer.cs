namespace YAPCSX2Launcher
{
    partial class SettingsForm
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
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.SettingsTabControlTab2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.configPopups = new System.Windows.Forms.CheckBox();
            this.configUseNewCompatibilityData = new System.Windows.Forms.CheckBox();
            this.configDownloadExtraGameData = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.configDefaultSorting = new System.Windows.Forms.ComboBox();
            this.configDefaultView = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.configFoldersSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConfigPcsx2ExecutableButton = new System.Windows.Forms.Button();
            this.ConfigPcsx2DataFolderButton = new System.Windows.Forms.Button();
            this.configPcsx2FolderButton = new System.Windows.Forms.Button();
            this.configPcsx2Executable = new System.Windows.Forms.TextBox();
            this.configPcsx2DataFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.configPcsx2Folder = new System.Windows.Forms.TextBox();
            this.configControllersTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.configControllerSupportCancelButton = new System.Windows.Forms.TextBox();
            this.configControllerSupportConfirmButton = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.configControllerSupport = new System.Windows.Forms.CheckBox();
            this.configSaveButton = new System.Windows.Forms.Button();
            this.configCancelButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.configDefaultOrdering = new System.Windows.Forms.ComboBox();
            this.settingsTabControl.SuspendLayout();
            this.SettingsTabControlTab2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.configFoldersSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.configControllersTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.SettingsTabControlTab2);
            this.settingsTabControl.Controls.Add(this.configFoldersSettings);
            this.settingsTabControl.Controls.Add(this.configControllersTab);
            this.settingsTabControl.Location = new System.Drawing.Point(12, 12);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(716, 470);
            this.settingsTabControl.TabIndex = 0;
            // 
            // SettingsTabControlTab2
            // 
            this.SettingsTabControlTab2.Controls.Add(this.groupBox4);
            this.SettingsTabControlTab2.Controls.Add(this.groupBox2);
            this.SettingsTabControlTab2.Location = new System.Drawing.Point(4, 22);
            this.SettingsTabControlTab2.Name = "SettingsTabControlTab2";
            this.SettingsTabControlTab2.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabControlTab2.Size = new System.Drawing.Size(708, 444);
            this.SettingsTabControlTab2.TabIndex = 1;
            this.SettingsTabControlTab2.Text = "YAPCSX2Launcher";
            this.SettingsTabControlTab2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.configPopups);
            this.groupBox4.Controls.Add(this.configUseNewCompatibilityData);
            this.groupBox4.Controls.Add(this.configDownloadExtraGameData);
            this.groupBox4.Location = new System.Drawing.Point(6, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(696, 96);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Optional Features";
            // 
            // configPopups
            // 
            this.configPopups.AutoSize = true;
            this.configPopups.Location = new System.Drawing.Point(6, 65);
            this.configPopups.Name = "configPopups";
            this.configPopups.Size = new System.Drawing.Size(183, 17);
            this.configPopups.TabIndex = 2;
            this.configPopups.Text = "Enable Pop Ups (unimplemented)";
            this.configPopups.UseVisualStyleBackColor = true;
            this.configPopups.Visible = false;
            // 
            // configUseNewCompatibilityData
            // 
            this.configUseNewCompatibilityData.AutoSize = true;
            this.configUseNewCompatibilityData.Location = new System.Drawing.Point(6, 42);
            this.configUseNewCompatibilityData.Name = "configUseNewCompatibilityData";
            this.configUseNewCompatibilityData.Size = new System.Drawing.Size(267, 17);
            this.configUseNewCompatibilityData.TabIndex = 1;
            this.configUseNewCompatibilityData.Text = "Use PCSX2\'s Gameindex.dbf for compatibility rating";
            this.configUseNewCompatibilityData.UseVisualStyleBackColor = true;
            this.configUseNewCompatibilityData.Visible = false;
            // 
            // configDownloadExtraGameData
            // 
            this.configDownloadExtraGameData.AutoSize = true;
            this.configDownloadExtraGameData.Location = new System.Drawing.Point(6, 19);
            this.configDownloadExtraGameData.Name = "configDownloadExtraGameData";
            this.configDownloadExtraGameData.Size = new System.Drawing.Size(272, 17);
            this.configDownloadExtraGameData.TabIndex = 0;
            this.configDownloadExtraGameData.Text = "Retrieve additional game data (Might lead to IP Ban)";
            this.configDownloadExtraGameData.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.configDefaultOrdering);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.configDefaultSorting);
            this.groupBox2.Controls.Add(this.configDefaultView);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Settings";
            // 
            // configDefaultSorting
            // 
            this.configDefaultSorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configDefaultSorting.FormattingEnabled = true;
            this.configDefaultSorting.Items.AddRange(new object[] {
            "Alphabetical",
            "Serial"});
            this.configDefaultSorting.Location = new System.Drawing.Point(105, 38);
            this.configDefaultSorting.Name = "configDefaultSorting";
            this.configDefaultSorting.Size = new System.Drawing.Size(135, 21);
            this.configDefaultSorting.TabIndex = 3;
            // 
            // configDefaultView
            // 
            this.configDefaultView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configDefaultView.FormattingEnabled = true;
            this.configDefaultView.Location = new System.Drawing.Point(105, 13);
            this.configDefaultView.Name = "configDefaultView";
            this.configDefaultView.Size = new System.Drawing.Size(135, 21);
            this.configDefaultView.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Default Sorting:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Default View:";
            // 
            // configFoldersSettings
            // 
            this.configFoldersSettings.Controls.Add(this.groupBox1);
            this.configFoldersSettings.Location = new System.Drawing.Point(4, 22);
            this.configFoldersSettings.Name = "configFoldersSettings";
            this.configFoldersSettings.Padding = new System.Windows.Forms.Padding(3);
            this.configFoldersSettings.Size = new System.Drawing.Size(708, 444);
            this.configFoldersSettings.TabIndex = 2;
            this.configFoldersSettings.Text = "Folders";
            this.configFoldersSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConfigPcsx2ExecutableButton);
            this.groupBox1.Controls.Add(this.ConfigPcsx2DataFolderButton);
            this.groupBox1.Controls.Add(this.configPcsx2FolderButton);
            this.groupBox1.Controls.Add(this.configPcsx2Executable);
            this.groupBox1.Controls.Add(this.configPcsx2DataFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.configPcsx2Folder);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders Configuration";
            // 
            // ConfigPcsx2ExecutableButton
            // 
            this.ConfigPcsx2ExecutableButton.Location = new System.Drawing.Point(650, 83);
            this.ConfigPcsx2ExecutableButton.Name = "ConfigPcsx2ExecutableButton";
            this.ConfigPcsx2ExecutableButton.Size = new System.Drawing.Size(25, 20);
            this.ConfigPcsx2ExecutableButton.TabIndex = 8;
            this.ConfigPcsx2ExecutableButton.Text = "...";
            this.ConfigPcsx2ExecutableButton.UseVisualStyleBackColor = true;
            this.ConfigPcsx2ExecutableButton.Click += new System.EventHandler(this.ConfigPcsx2ExecutableButton_Click);
            // 
            // ConfigPcsx2DataFolderButton
            // 
            this.ConfigPcsx2DataFolderButton.Location = new System.Drawing.Point(650, 51);
            this.ConfigPcsx2DataFolderButton.Name = "ConfigPcsx2DataFolderButton";
            this.ConfigPcsx2DataFolderButton.Size = new System.Drawing.Size(25, 20);
            this.ConfigPcsx2DataFolderButton.TabIndex = 7;
            this.ConfigPcsx2DataFolderButton.Text = "...";
            this.ConfigPcsx2DataFolderButton.UseVisualStyleBackColor = true;
            this.ConfigPcsx2DataFolderButton.Click += new System.EventHandler(this.ConfigPcsx2DataFolderButton_Click);
            // 
            // configPcsx2FolderButton
            // 
            this.configPcsx2FolderButton.Location = new System.Drawing.Point(650, 19);
            this.configPcsx2FolderButton.Name = "configPcsx2FolderButton";
            this.configPcsx2FolderButton.Size = new System.Drawing.Size(25, 20);
            this.configPcsx2FolderButton.TabIndex = 6;
            this.configPcsx2FolderButton.Text = "...";
            this.configPcsx2FolderButton.UseVisualStyleBackColor = true;
            this.configPcsx2FolderButton.Click += new System.EventHandler(this.configPcsx2FolderButton_Click);
            // 
            // configPcsx2Executable
            // 
            this.configPcsx2Executable.Location = new System.Drawing.Point(130, 83);
            this.configPcsx2Executable.Name = "configPcsx2Executable";
            this.configPcsx2Executable.Size = new System.Drawing.Size(514, 20);
            this.configPcsx2Executable.TabIndex = 5;
            // 
            // configPcsx2DataFolder
            // 
            this.configPcsx2DataFolder.Location = new System.Drawing.Point(130, 51);
            this.configPcsx2DataFolder.Name = "configPcsx2DataFolder";
            this.configPcsx2DataFolder.Size = new System.Drawing.Size(514, 20);
            this.configPcsx2DataFolder.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "PCSX2 Executable:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PCSX2 Data Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PCSX2 Folder:";
            // 
            // configPcsx2Folder
            // 
            this.configPcsx2Folder.Location = new System.Drawing.Point(130, 19);
            this.configPcsx2Folder.Name = "configPcsx2Folder";
            this.configPcsx2Folder.Size = new System.Drawing.Size(514, 20);
            this.configPcsx2Folder.TabIndex = 0;
            // 
            // configControllersTab
            // 
            this.configControllersTab.Controls.Add(this.groupBox3);
            this.configControllersTab.Location = new System.Drawing.Point(4, 22);
            this.configControllersTab.Name = "configControllersTab";
            this.configControllersTab.Padding = new System.Windows.Forms.Padding(3);
            this.configControllersTab.Size = new System.Drawing.Size(708, 444);
            this.configControllersTab.TabIndex = 3;
            this.configControllersTab.Text = "Controllers";
            this.configControllersTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.configControllerSupportCancelButton);
            this.groupBox3.Controls.Add(this.configControllerSupportConfirmButton);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.configControllerSupport);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(699, 136);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controller Settings";
            // 
            // configControllerSupportCancelButton
            // 
            this.configControllerSupportCancelButton.Location = new System.Drawing.Point(89, 93);
            this.configControllerSupportCancelButton.Name = "configControllerSupportCancelButton";
            this.configControllerSupportCancelButton.Size = new System.Drawing.Size(100, 20);
            this.configControllerSupportCancelButton.TabIndex = 4;
            // 
            // configControllerSupportConfirmButton
            // 
            this.configControllerSupportConfirmButton.Location = new System.Drawing.Point(89, 56);
            this.configControllerSupportConfirmButton.Name = "configControllerSupportConfirmButton";
            this.configControllerSupportConfirmButton.Size = new System.Drawing.Size(100, 20);
            this.configControllerSupportConfirmButton.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cancel Button:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Confirm Button:";
            // 
            // configControllerSupport
            // 
            this.configControllerSupport.AutoSize = true;
            this.configControllerSupport.Location = new System.Drawing.Point(6, 19);
            this.configControllerSupport.Name = "configControllerSupport";
            this.configControllerSupport.Size = new System.Drawing.Size(146, 17);
            this.configControllerSupport.TabIndex = 0;
            this.configControllerSupport.Text = "Enable Controller Support";
            this.configControllerSupport.UseVisualStyleBackColor = true;
            // 
            // configSaveButton
            // 
            this.configSaveButton.Location = new System.Drawing.Point(653, 488);
            this.configSaveButton.Name = "configSaveButton";
            this.configSaveButton.Size = new System.Drawing.Size(75, 23);
            this.configSaveButton.TabIndex = 1;
            this.configSaveButton.Text = "Save";
            this.configSaveButton.UseVisualStyleBackColor = true;
            this.configSaveButton.Click += new System.EventHandler(this.configSaveButton_Click);
            // 
            // configCancelButton
            // 
            this.configCancelButton.Location = new System.Drawing.Point(572, 488);
            this.configCancelButton.Name = "configCancelButton";
            this.configCancelButton.Size = new System.Drawing.Size(75, 23);
            this.configCancelButton.TabIndex = 2;
            this.configCancelButton.Text = "Cancel";
            this.configCancelButton.UseVisualStyleBackColor = true;
            this.configCancelButton.Click += new System.EventHandler(this.configCancelButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Default Ordering:";
            // 
            // configDefaultOrdering
            // 
            this.configDefaultOrdering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configDefaultOrdering.FormattingEnabled = true;
            this.configDefaultOrdering.Items.AddRange(new object[] {
            "Alphabetical",
            "Serial"});
            this.configDefaultOrdering.Location = new System.Drawing.Point(105, 65);
            this.configDefaultOrdering.Name = "configDefaultOrdering";
            this.configDefaultOrdering.Size = new System.Drawing.Size(135, 21);
            this.configDefaultOrdering.TabIndex = 5;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 523);
            this.Controls.Add(this.configCancelButton);
            this.Controls.Add(this.configSaveButton);
            this.Controls.Add(this.settingsTabControl);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.settingsTabControl.ResumeLayout(false);
            this.SettingsTabControlTab2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.configFoldersSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.configControllersTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage SettingsTabControlTab2;
        private System.Windows.Forms.TabPage configFoldersSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConfigPcsx2ExecutableButton;
        private System.Windows.Forms.Button ConfigPcsx2DataFolderButton;
        private System.Windows.Forms.Button configPcsx2FolderButton;
        private System.Windows.Forms.TextBox configPcsx2Executable;
        private System.Windows.Forms.TextBox configPcsx2DataFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox configPcsx2Folder;
        private System.Windows.Forms.TabPage configControllersTab;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox configControllerSupport;
        private System.Windows.Forms.TextBox configControllerSupportCancelButton;
        private System.Windows.Forms.TextBox configControllerSupportConfirmButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button configSaveButton;
        private System.Windows.Forms.Button configCancelButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox configDefaultSorting;
        private System.Windows.Forms.ComboBox configDefaultView;
        private System.Windows.Forms.CheckBox configUseNewCompatibilityData;
        private System.Windows.Forms.CheckBox configDownloadExtraGameData;
        private System.Windows.Forms.CheckBox configPopups;
        private System.Windows.Forms.ComboBox configDefaultOrdering;
        private System.Windows.Forms.Label label8;
    }
}