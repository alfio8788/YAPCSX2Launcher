using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using YAPCSX2Launcher.Utilities.SettingsManager;

namespace YAPCSX2Launcher
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void configCancelButton_Click(object sender, EventArgs e)
        {

            //TODO: Actually check if anything changed in the form and warn
            Dispose();
        }

        private void configSaveButton_Click(object sender, EventArgs e)
        {
            //Get All the settings
            Configs config = new Configs();
            config.pcsx2Folder = configPcsx2Folder.Text;
            config.pcsx2DataFolder = configPcsx2DataFolder.Text;
            config.pcsx2Executable = configPcsx2Executable.Text;
            config.viewMode = configDefaultView.SelectedValue.ToString();
            config.sorting = configDefaultSorting.SelectedValue.ToString();
            config.remoteInfo = (configDownloadExtraGameData.Checked) ? true : false;
            config.gamepadSupport = (configControllerSupport.Checked) ? true : false;
            config.gamepadOkButton = configControllerSupportConfirmButton.Text;
            config.gamepadCancelButton = configControllerSupportCancelButton.Text;
            config.ordering = configDefaultOrdering.SelectedValue.ToString();
            bool result = config.updateSettings(config);
            if(result)
            {
                Dispose();
            } else
            {
                MessageBox.Show("Error: Couldn't save settings!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configPcsx2FolderButton_Click(object sender, EventArgs e)
        {
            string pcsx2FolderPath;
            FolderBrowserDialog pcsx2Folder = new FolderBrowserDialog();
            if (pcsx2Folder.ShowDialog() == DialogResult.OK)
            {
                pcsx2FolderPath = pcsx2Folder.SelectedPath + "\\";
                configPcsx2Folder.Text = pcsx2FolderPath;
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var sortingValues = new[] {
                new { Text = "Ascending", Value = "ASC" },
                new { Text = "Descending", Value = "DESC"}
            };

            var orderingValues = new[]
            {
                new { Text = "Name", Value = "name" },
                new { Text = "Serial", Value = "serial" },
                new { Text = "Region", Value = "region" },
                new { Text = "Compatibility", Value = "compatibility" },
                new { Text = "Time Played", Value = "timeplayed" }
            };

            var defaultViewValues = new[] {
                new { Text= "List", Value = "list" },
                new { Text= "Grid", Value = "grid" },
                new { Text= "TV", Value = "tv" }
            };

            this.configDefaultView.DataSource = defaultViewValues;
            this.configDefaultView.ValueMember = "Value";
            this.configDefaultView.DisplayMember = "Text";
            this.configDefaultSorting.DataSource = sortingValues;
            this.configDefaultSorting.ValueMember = "Value";
            this.configDefaultSorting.DisplayMember = "Text";
            this.configDefaultOrdering.DataSource = orderingValues;
            this.configDefaultOrdering.ValueMember = "Value";
            this.configDefaultOrdering.DisplayMember = "Text";
            //On Load triggers after form opening for some reason: this is bound here till we figure out the problem
            Configs configs = new Configs().getSettings();
            configPcsx2Folder.Text = configs.pcsx2Folder;
            configPcsx2DataFolder.Text = configs.pcsx2DataFolder;
            configPcsx2Executable.Text = configs.pcsx2Executable;
            configDownloadExtraGameData.Checked = configs.remoteInfo;
            configDefaultView.SelectedValue = configs.viewMode;
            configDefaultSorting.SelectedValue = configs.sorting;
            configControllerSupport.Checked = configs.gamepadSupport;
            configControllerSupportConfirmButton.Text = configs.gamepadOkButton;
            configControllerSupportCancelButton.Text = configs.gamepadCancelButton;
            configDefaultOrdering.SelectedValue = configs.ordering;
        }
    }
}