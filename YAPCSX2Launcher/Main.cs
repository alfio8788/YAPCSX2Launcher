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
using System.Reflection;
using YAPCSX2Launcher.Utilities.Emulator;
// Load App Utilities
using YAPCSX2Launcher.Utilities.SQLManager;
using YAPCSX2Launcher.Utilities.GamesManager;
using YAPCSX2Launcher.Utilities.SettingsManager;
//Threading tests
//using System.Threading;
//using System.Reflection;
//using static YAPCSX2Launcher.SingleInstanceMutex;

namespace YAPCSX2Launcher
{
    public partial class Main : Form
    {
        public Main()
        {
            //using (SingleInstanceMutex sim = new SingleInstanceMutex())
            //{
            //    if (sim.IsOtherInstanceRunning)
            //    {
            //        Application.Exit();
            //    }
            //}
            InitializeComponent();
            //First Launch? No problem we will solve this with a configuration wizard, else? Simply show the main window
            string dbfile = foldersAndFiles("dbfile");
            //MessageBox.Show(dbfile);
            //COMMENT THE IF CONDITION TO SHOW THE WIZARD SETUP FOR DEBUG EVEN AFTER THE SOFTWARE ALREADY CREATED IT'S FIRST CONFIG
            if (!File.Exists(dbfile))
            {
                MessageBox.Show("This is the first time you are running this application, we will now show you a setup wizard to help you configure this application", "First Launch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form wizardForm = new SetupWizardForm();
                wizardForm.ShowDialog();
            } //Let's speed things up for now TODO: Uncomment when done
            /*else
            {
                Form splashScreen = new SplashForm();
                splashScreen.ShowDialog();
            }*/
            /* Get the settings */
            Configs configs = new Configs().getSettings();
            DataTable games = new Games().getGamesCatalogue();
            //MessageBox.Show(games.Rows.Count.ToString());
            /* ISO READING TEST */
            /*string File = "C:\\Users\\alfio\\Desktop\\Bard's Tale, The (USA).iso";
            string res = PCSX2Utility.ExtractSerial(File);
            MessageBox.Show(res);*/

            /* TODO: Set Everything */
            //Set the side icons to match the settings
            if(configs.viewMode.ToLower() == "list")
            {
                listViewSwitch_Click(null, null);
            }
            else if (configs.viewMode.ToLower() == "grid")
            {
                pictureBox2_Click(null, null);
            }
            else if (configs.viewMode.ToLower() == "tv")
            {
                pictureBox1_Click(null, null);
            }

            /*string[] games = new string[5];
            ListViewItem itm;

            Dictionary<string, string> gameDbDictionary = PCSX2Utility.gameDb();
            foreach(KeyValuePair<string,string> kvp in gameDbDictionary)
            {
                games[0] = null;
                games[1] = kvp.Key;
                games[2] = kvp.Value;
                itm = new ListViewItem(games);
                gameListGridMode.Items.Add(itm);
            }*/
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void listViewSwitch_Click(object sender, EventArgs e)
        {
            /* RECOVER FROM ASSEMBLY */
            Assembly getImage;
            getImage = Assembly.GetExecutingAssembly();
            Stream buttonImage1 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.list_view_e.png");
            Stream buttonImage2 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.grid_view_n.png");
            Stream buttonImage3 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.tv_icon_n.png");
            listViewSwitch.Image = new Bitmap(buttonImage1);
            pictureBox2.Image = new Bitmap(buttonImage2);
            pictureBox1.Image = new Bitmap(buttonImage3);

            /* Swap to list view mode */
            gameListGridMode.View = View.Details;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /* RECOVER FROM ASSEMBLY */
            Assembly getImage;
            getImage = Assembly.GetExecutingAssembly();
            Stream buttonImage = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.list_view_n.png");
            Stream buttonImage2 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.grid_view_e.png");
            Stream buttonImage3 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.tv_icon_n.png");
            listViewSwitch.Image = new Bitmap(buttonImage);
            pictureBox2.Image = new Bitmap(buttonImage2);
            pictureBox1.Image = new Bitmap(buttonImage3);

            /* swap to grid view mode */
            gameListGridMode.View = View.LargeIcon;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /* RECOVER FROM ASSEMBLY */
            Assembly getImage;
            getImage = Assembly.GetExecutingAssembly();
            Stream buttonImage = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.list_view_n.png");
            Stream buttonImage2 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.grid_view_n.png");
            Stream buttonImage3 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.tv_icon_e.png");
            listViewSwitch.Image = new Bitmap(buttonImage);
            pictureBox2.Image = new Bitmap(buttonImage2);
            pictureBox1.Image = new Bitmap(buttonImage3);

            /* TODO: FULL SCREEN MODE */
        }

        private static string foldersAndFiles(string dictionaryIndex)
        {
            //Load the main folder too and include it in another variable so we will not have to calculate it every time...
            Dictionary<string, string> folders = new Dictionary<string, string>();
            string location = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\YAPCSX2Launcher\\";
            folders.Add("main", location);
            folders.Add("dbfile", location + "YAPCSX2Launcher.db3");
            folders.Add("emulatorconfigurationfoler", location + "configs\\");
            folders.Add("cachefolder", location + "cache\\");
            folders.Add("languagesfile", location + "languages.xml");
            return folders[dictionaryIndex];
        }
    }
}
