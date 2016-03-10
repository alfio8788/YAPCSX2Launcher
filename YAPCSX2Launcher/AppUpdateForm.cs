using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.App;

namespace YAPCSX2Launcher
{
    public partial class AppUpdateForm : Form
    {
        public AppUpdateForm()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void AppUpdateForm_Load(object sender, EventArgs e)
        {
            this.currentVersionLabel.Text = Application.ProductVersion;
        }

        private void betaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateManager updMngr = UpdateManager.Instance();
            updMngr.betaVersions = (this.betaCheckBox.Checked) ? true : false;
            string[] versions = UpdateManager.checkUpdates();
            if(string.IsNullOrEmpty(versions.ToString()))
            {
                MessageBox.Show("Could not check if there is a new version, Are you connected?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                this.lastVersionLabel.Text = versions[1];
            }
        }
    }
}
