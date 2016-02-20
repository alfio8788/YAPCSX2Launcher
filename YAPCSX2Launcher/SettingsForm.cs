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
            Dictionary<string, string> settingsArray = settings.XMLLoadConfig(configFile);
        }

        private void configCancelButton_Click(object sender, EventArgs e)
        {

            //TODO: Actually check if anything changed in the form and warn
            Close();
        }
    }
}
