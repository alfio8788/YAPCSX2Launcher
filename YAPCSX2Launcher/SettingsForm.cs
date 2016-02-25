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
            string configFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\YAPCSX2Loader\\config.xml";
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
    }
}
