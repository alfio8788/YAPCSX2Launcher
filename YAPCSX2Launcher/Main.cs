using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

//no more need of registry hacks :)
//Load the ModifyRegistry class
//using Utility.ModifyRegistry;

namespace YAPCSX2Launcher
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            //First Launch? No problem we will solve this with a configuration wizard, else? Simply show the main window
            string userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\YAPCSX2Loader\\";
            //COMMENT THE IF CONDITION TO SHOW THE WIZARD SETUP FOR DEBUG EVEN AFTER THE SOFTWARE ALREADY CREATED IT'S FIRST CONFIG
            if (!Directory.Exists(userDataFolder))
            {
                Form wizardForm = new SetupWizardForm();
                wizardForm.ShowDialog();
            } //Let's speed things up 
            /*else
            {
                Form splashScreen = new SplashForm();
                splashScreen.ShowDialog();
            }*/
            gameListGridMode.Columns.Add("Serial", 100);
            gameListGridMode.Columns.Add("Game", 300);
            gameListGridMode.Columns.Add("Region", 50);
            gameListGridMode.Columns.Add("Compatibility", 50);

            //DEBUG DATA, TO REMOVE ONCE WORKING
            string[] games = new string[4];
            ListViewItem itm;
            games[0] = "SCAJ-20141";
            games[1] = "Grandia III";
            games[2] = "JP";
            games[3] = "5";
            itm = new ListViewItem(games);
            gameListGridMode.Items.Add(itm);
            string[] games2 = new string[4];
            games2[0] = "SCAJ-99999";
            games2[1] = "Unknown game";
            games2[2] = "JP";
            games2[3] = "0";
            itm = new ListViewItem(games2);
            gameListGridMode.Items.Add(itm);
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form settingsDialog = new SettingsForm();
            settingsDialog.Show();
        }

        private void aboutToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form aboutDialog = new AboutForm();
            aboutDialog.Show();
        }
    }
}
