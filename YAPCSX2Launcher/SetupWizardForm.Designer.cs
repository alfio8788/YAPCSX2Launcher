namespace YAPCSX2Launcher
{
    partial class SetupWizardForm
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
            this.configWizardSaveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 123);
            this.groupBox1.TabIndex = 0;
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
            this.configPcsx2Executable.TextChanged += new System.EventHandler(this.showSaveButton);
            // 
            // configPcsx2DataFolder
            // 
            this.configPcsx2DataFolder.Location = new System.Drawing.Point(130, 51);
            this.configPcsx2DataFolder.Name = "configPcsx2DataFolder";
            this.configPcsx2DataFolder.Size = new System.Drawing.Size(514, 20);
            this.configPcsx2DataFolder.TabIndex = 4;
            this.configPcsx2DataFolder.TextChanged += new System.EventHandler(this.showSaveButton);
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
            this.configPcsx2Folder.TextChanged += new System.EventHandler(this.showSaveButton);
            // 
            // configWizardSaveButton
            // 
            this.configWizardSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configWizardSaveButton.Location = new System.Drawing.Point(618, 141);
            this.configWizardSaveButton.Name = "configWizardSaveButton";
            this.configWizardSaveButton.Size = new System.Drawing.Size(75, 23);
            this.configWizardSaveButton.TabIndex = 1;
            this.configWizardSaveButton.Text = "Save";
            this.configWizardSaveButton.UseVisualStyleBackColor = true;
            this.configWizardSaveButton.Click += new System.EventHandler(this.configWizardSaveButton_Click);
            // 
            // SetupWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 173);
            this.ControlBox = false;
            this.Controls.Add(this.configWizardSaveButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupWizardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetupWizardForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupWizardForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox configPcsx2Executable;
        private System.Windows.Forms.TextBox configPcsx2DataFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox configPcsx2Folder;
        private System.Windows.Forms.Button ConfigPcsx2ExecutableButton;
        private System.Windows.Forms.Button ConfigPcsx2DataFolderButton;
        private System.Windows.Forms.Button configPcsx2FolderButton;
        private System.Windows.Forms.Button configWizardSaveButton;
    }
}