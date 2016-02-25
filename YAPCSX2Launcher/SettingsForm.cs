using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.XMLManager;
using System.IO;
namespace YAPCSX2Launcher
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            //TODO: Retrieve Settings to populate the form
            string configFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\YAPCSX2Launcher\\config.xml";
            XMLManager settings = new XMLManager();
            Dictionary<string, string> settingsArray = settings.XMLLoadConfig();
        }

        private void configCancelButton_Click(object sender, EventArgs e)
        {

            //TODO: Actually check if anything changed in the form and warn
            Close();
        }

        private void configSaveButton_Click(object sender, EventArgs e)
        {
            //Get All the settings
            Dictionary<string,string> settingsArray = new Dictionary<string, string>();
            settingsArray["PCSX2Folder"] = configPcsx2Folder.Text;
            settingsArray["PCSX2DataFolder"] = configPcsx2DataFolder.Text;
            settingsArray["PCSX2Executable"] = configPcsx2Executable.Text;
            settingsArray["viewmode"] = configDefaultView.Text.ToLower();
            settingsArray["sorting"] = configDefaultSorting.Text.ToLower();
            settingsArray["remoteinfo"] = (configDownloadExtraGameData.Checked) ? true.ToString() : false.ToString();
            settingsArray["controlersupport"] = (configControllerSupport.Checked) ? true.ToString() : false.ToString();
            settingsArray["controlersupportokbutton"] = configControllerSupportConfirmButton.Text;
            settingsArray["controlersupportcancelbutton"] = configControllerSupportCancelButton.Text;
            XMLManager configWriter = new XMLManager();
            configWriter.XMLWriteConfig(settingsArray);
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
    }
}
