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
using YAPCSX2Launcher.Utilities.XMLManager;

namespace YAPCSX2Launcher
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            //First Launch? No problem we will solve this with a configuration wizard, else? Simply show the main window
            string userDataFolder = foldersAndFiles("main");
            //COMMENT THE IF CONDITION TO SHOW THE WIZARD SETUP FOR DEBUG EVEN AFTER THE SOFTWARE ALREADY CREATED IT'S FIRST CONFIG
            if (!Directory.Exists(userDataFolder))
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
            /* ISO READING TEST */
            /*string File = "C:\\Users\\alfio\\Desktop\\Bard's Tale, The (USA).iso";
            string res = PCSX2Utility.ExtractSerial(File);
            MessageBox.Show(res);*/

            /* TODO: Load settings */
            XMLManager settingsLoader = new XMLManager();
            Dictionary<string, string> settings = settingsLoader.XMLLoadConfig();
            //Set the side icons to match the settings
            if(settings["viewmode"].ToLower() == "list")
            {
                listViewSwitch_Click(null, null);
            } else if(settings["viewmode"].ToLower() == "grid")
            {
                pictureBox2_Click(null, null);
            } else if(settings["viewmode"].ToLower() == "tv")
            {
                pictureBox1_Click(null, null);
            } else //Any other value will default to list view to prevent problems
            {
                listViewSwitch_Click(null, null);
            }
            
            string[] games = new string[5];
            ListViewItem itm;

            Dictionary<string, string> gameDbDictionary = PCSX2Utility.gameDb();
            foreach(KeyValuePair<string,string> kvp in gameDbDictionary)
            {
                games[0] = null;
                games[1] = kvp.Key;
                games[2] = kvp.Value;
                itm = new ListViewItem(games);
                gameListGridMode.Items.Add(itm);
            }
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
            string userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\YAPCSX2Launcher\\";
            folders.Add("main", userDataFolder);
            folders.Add("emulatorconfigurationfoler", userDataFolder + "configs\\");
            folders.Add("configurationfile", userDataFolder + "config.xml");
            folders.Add("screenshotsfolder", userDataFolder + "screenshots\\");
            folders.Add("coversfolder", userDataFolder + "covers\\");
            folders.Add("gamesfile", userDataFolder + "games.xml");
            folders.Add("cachefolder", userDataFolder + "cache\\");
            folders.Add("languagesfile", userDataFolder + "languages.xml");
            return folders[dictionaryIndex];
        }
    }
}
