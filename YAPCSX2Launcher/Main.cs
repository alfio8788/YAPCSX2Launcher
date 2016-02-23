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
            } //Let's speed things up for now
            /*else
            {
                Form splashScreen = new SplashForm();
                splashScreen.ShowDialog();
            }*/
            string[] games = new string[5];
            ListViewItem itm;
            //Cover
            /*ImageList covers = new ImageList();
            Assembly cover;
            cover = Assembly.GetExecutingAssembly();
            Stream noCoverImage = cover.GetManifestResourceStream("YAPCSX2Launcher.Resources.ps3_no_cover.png");
            covers.Images.Add(Image.FromStream(noCoverImage));*/

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
    }
}
