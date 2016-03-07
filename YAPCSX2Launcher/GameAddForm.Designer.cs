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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gameAddButton = new System.Windows.Forms.Button();
            this.gameAddCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonLocateFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gameDataGroupBox = new System.Windows.Forms.GroupBox();
            this.serialTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manualFillCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gameDataGroupBox.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(716, 274);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manualFillCheckBox);
            this.tabPage1.Controls.Add(this.gameDataGroupBox);
            this.tabPage1.Controls.Add(this.buttonLocateFile);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(708, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(708, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gameAddButton
            // 
            this.gameAddButton.Location = new System.Drawing.Point(650, 286);
            this.gameAddButton.Name = "gameAddButton";
            this.gameAddButton.Size = new System.Drawing.Size(75, 23);
            this.gameAddButton.TabIndex = 0;
            this.gameAddButton.Text = "Save";
            this.gameAddButton.UseVisualStyleBackColor = true;
            // 
            // gameAddCancelButton
            // 
            this.gameAddCancelButton.Location = new System.Drawing.Point(569, 286);
            this.gameAddCancelButton.Name = "gameAddCancelButton";
            this.gameAddCancelButton.Size = new System.Drawing.Size(75, 23);
            this.gameAddCancelButton.TabIndex = 1;
            this.gameAddCancelButton.Text = "Cancel";
            this.gameAddCancelButton.UseVisualStyleBackColor = true;
            this.gameAddCancelButton.Click += new System.EventHandler(this.gameAddCancelButton_Click);
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
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(95, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(576, 20);
            this.textBox1.TabIndex = 1;
            // 
            // buttonLocateFile
            // 
            this.buttonLocateFile.Location = new System.Drawing.Point(677, 6);
            this.buttonLocateFile.Name = "buttonLocateFile";
            this.buttonLocateFile.Size = new System.Drawing.Size(25, 20);
            this.buttonLocateFile.TabIndex = 2;
            this.buttonLocateFile.Text = "...";
            this.buttonLocateFile.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serial:";
            // 
            // gameDataGroupBox
            // 
            this.gameDataGroupBox.Controls.Add(this.textBox2);
            this.gameDataGroupBox.Controls.Add(this.label4);
            this.gameDataGroupBox.Controls.Add(this.nameTextBox);
            this.gameDataGroupBox.Controls.Add(this.label3);
            this.gameDataGroupBox.Controls.Add(this.serialTextBox);
            this.gameDataGroupBox.Controls.Add(this.label2);
            this.gameDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDataGroupBox.Location = new System.Drawing.Point(6, 55);
            this.gameDataGroupBox.Name = "gameDataGroupBox";
            this.gameDataGroupBox.Size = new System.Drawing.Size(696, 187);
            this.gameDataGroupBox.TabIndex = 4;
            this.gameDataGroupBox.TabStop = false;
            this.gameDataGroupBox.Text = "Game Data:";
            this.gameDataGroupBox.Visible = false;
            // 
            // serialTextBox
            // 
            this.serialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialTextBox.Enabled = false;
            this.serialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialTextBox.Location = new System.Drawing.Point(74, 26);
            this.serialTextBox.Name = "serialTextBox";
            this.serialTextBox.Size = new System.Drawing.Size(130, 15);
            this.serialTextBox.TabIndex = 4;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(74, 58);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(199, 15);
            this.nameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(74, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 15);
            this.textBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Region:";
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
            // GameAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 321);
            this.Controls.Add(this.gameAddCancelButton);
            this.Controls.Add(this.gameAddButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameAddForm";
            this.Text = "GameAddForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gameDataGroupBox.ResumeLayout(false);
            this.gameDataGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button gameAddButton;
        private System.Windows.Forms.Button gameAddCancelButton;
        private System.Windows.Forms.Button buttonLocateFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gameDataGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox manualFillCheckBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}