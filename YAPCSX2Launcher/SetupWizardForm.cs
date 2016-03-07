using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//Folder Check Library
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.SettingsManager;
using YAPCSX2Launcher.Utilities.SQLManager;
//XML Class
using YAPCSX2Launcher.Utilities.XMLManager;

namespace YAPCSX2Launcher
{
    public partial class SetupWizardForm : Form
    {
        public SetupWizardForm()
        {
            InitializeComponent();
            //Disable Save Button
            configWizardSaveButton.Enabled = false;
        }

        private void SetupWizardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            //Remove this after debug is done
            //MessageBox.Show("Please configure YAPCSX2Launcher before closing this form");
        }

        private void configPcsx2FolderButton_Click(object sender, EventArgs e)
        {
            string pcsx2FolderPath;
            FolderBrowserDialog pcsx2Folder = new FolderBrowserDialog();
            if (pcsx2Folder.ShowDialog() == DialogResult.OK)
            {
                pcsx2FolderPath = pcsx2Folder.SelectedPath + "\\";
                configPcsx2Folder.Text = pcsx2FolderPath;
                //99.999999% of the times the executable will be in this folder too, so let's take the chance to set this as well
                configPcsx2Executable.Text = pcsx2FolderPath + "pcsx2.exe";
                //Check if there is a file called "portable.ini" in the folder, if this is the case set data folder the same as configPcsx2Folder
                if (File.Exists(pcsx2FolderPath + "portable.ini"))
                {
                    //Warn the user that some of the features are not supported if in portable mode
                    configPcsx2DataFolder.Text = pcsx2FolderPath;
                    MessageBox.Show("WARNING: Some of the features of this program are not supported in portable mode, you can disable this mode by removing or renaming the file portable.ini in the pcsx2 folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void ConfigPcsx2DataFolderButton_Click(object sender, EventArgs e)
        {
            string pcsx2DataFolderPath;
            FolderBrowserDialog pcsx2DataFolder = new FolderBrowserDialog();
            if (pcsx2DataFolder.ShowDialog() == DialogResult.OK)
            {
                pcsx2DataFolderPath = pcsx2DataFolder.SelectedPath;
                configPcsx2DataFolder.Text = pcsx2DataFolderPath;
            }
        }

        private void ConfigPcsx2ExecutableButton_Click(object sender, EventArgs e)
        {
            string pcsx2Executable;
            OpenFileDialog pcsx2ExecutableDialog = new OpenFileDialog();
            if (pcsx2ExecutableDialog.ShowDialog() == DialogResult.OK)
            {
                pcsx2Executable = pcsx2ExecutableDialog.FileName;
                configPcsx2Executable.Text = pcsx2Executable;
            }
        }

        private void configWizardSaveButton_Click(object sender, EventArgs e)
        {
            //Directory
            string directory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\YAPCSX2Launcher";
            //dbFile
            string dbFile = directory  + "\\YAPCSX2Launcher.db3";
            bool result = false;
            //Directory doesn't exist? Make it...
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(dbFile))
            {
                SQLMngr sqlManager = new SQLMngr();
                sqlManager.extractDb();
                Configs settings = new Configs();
                settings.pcsx2Folder = configPcsx2Folder.Text.ToString();
                settings.pcsx2DataFolder = configPcsx2DataFolder.Text.ToString();
                settings.pcsx2Executable = configPcsx2Executable.Text.ToString();
                settings.viewMode = "list";
                settings.sorting = "ASC";
                settings.gamepadSupport = false;
                settings.gamepadCancelButton = "0";
                settings.gamepadOkButton = "1";
                settings.remoteInfo = false;
                settings.ordering = "name";
                result = settings.saveSettings(settings);
                //MessageBox.Show(result.ToString());
            }
            if(result)
            {
                MessageBox.Show("Configuration Done");
                this.Dispose();
            } else //If the saving of the settings failed
            {
                File.Delete(dbFile);
                Directory.Delete(directory);
                MessageBox.Show("Couldn't save settings, make sure you have write permission in:" + System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void showSaveButton(object sender, EventArgs e)
        {
            /* TODO: Make a better detection...maybe someday */
            bool path1 = (configPcsx2Folder.TextLength >= 4);
            bool path2 = (configPcsx2DataFolder.TextLength >= 4);
            bool path3 = (configPcsx2Executable.TextLength >= 4);
            //Enable to debug the controls
            //MessageBox.Show("B1: " + path1 + " - B2: " + path2 + " - B3: " + path3);
            if(path1 && path2 && path3)
            {
                configWizardSaveButton.Enabled = true;
            }
        }
    }
}