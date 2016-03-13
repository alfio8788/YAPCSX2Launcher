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
using YAPCSX2Launcher.Utilities.MainManager;
//Threading tests
using System.Threading;
using System.Diagnostics;
using BrightIdeasSoftware;
//using static YAPCSX2Launcher.SingleInstanceMutex;

namespace YAPCSX2Launcher
{
    public partial class Main : Form
    {
        public Main()
        {
            /*SingleInstanceMutex sim = new SingleInstanceMutex();
            if (sim.IsOtherInstanceRunning)
            {
                //MessageBox.Show("ERROR: Only one instance of this program can run at once!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Dispose();
                Application.Exit();
            }*/
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
            } //Let's speed things up for now TODO: Uncomment when done (probably to remove)
            /*else
            {
                Form splashScreen = new SplashForm();
                splashScreen.ShowDialog();
            }*/
            /* Get the settings */
            Configs configs = new Configs().getSettings();
            DataTable games = new Games().getGamesCatalogue();
            //MessageBox.Show(games.Rows.Count.ToString());
            //Get Images
            Dictionary<int,Image> compatImgs = new ListViewManager().getImageList();
            this.objectListView1.SetObjects(games.Rows);
            this.objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //Set compatibility column to load the images
            this.olvColumnCompatibility.Width = 200;
            this.olvColumnCompatibility.AspectGetter = delegate (object x)
            {
                DataRow strings = (DataRow)x;
                //MessageBox.Show(strings["compatibility"].ToString());
                return compatImgs[int.Parse(strings["compatibility"].ToString())];
            };
            this.olvColumnCompatibility.Renderer = new ImageRenderer();
            //this.objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.RowHeight = 100;
            this.olvColumnCover.Renderer = new ImageRenderer();

            /* TODO: Set Everything */
            //Set the side icons to match the settings
            if (configs.viewMode.ToLower() == "list")
            {
                listViewSwitch_Click(null, null);
                this.objectListView1.View = View.Details;
                //listManager.listViewModeDetailFill(this.gameListGridMode, games);
            }
            else if (configs.viewMode.ToLower() == "grid")
            {
                pictureBox2_Click(null, null);
                this.objectListView1.View = View.LargeIcon;
            }
            else if (configs.viewMode.ToLower() == "tv")
            {
                pictureBox1_Click(null, null);
            }
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
            //gameListGridMode.View = View.Details;
            this.objectListView1.View = View.Details;
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
            //gameListGridMode.View = View.LargeIcon;
            this.objectListView1.View = View.LargeIcon;
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
            return folders[dictionaryIndex];
        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form addGameForm = new GameAddForm();
            addGameForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void donateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //TODO: Insert Url and Uncomment
            //ProcessStartInfo sInfo = new ProcessStartInfo("");
            //Process.Start(sInfo);
        }

        private void checkForUpdatesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form updateForm = new AppUpdateForm();
            updateForm.ShowDialog();
        }

        private void objectListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("trigger of right click");
                if (objectListView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    //MessageBox.Show("Selected Item: " + this.objectListView1.SelectedIndex.ToString());
                    gameEditMenu.Show(Cursor.Position);
                }
            }
        }

        private void editGameSubMenu_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
            //MessageBox.Show(selectedRow["id"].ToString());
            Form editGameForm = new EditGameForm(int.Parse(selectedRow["id"].ToString()));
            editGameForm.ShowDialog();
        }

        private void gameConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
            Form gameConfigForm = new GameConfigEditForm(int.Parse(selectedRow["id"].ToString()));
            gameConfigForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void removeGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to remove this game from the database?","Warning!",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
                //Remove game
                Games game = new Games();
                bool result = game.removeGame(int.Parse(selectedRow["id"].ToString()));
                if(result)
                {
                    this.reloadMainList();
                } else
                {
                    MessageBox.Show("Error: Couldn't remove game, try again later","Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /* game list reload logic */
        public void listReloadHelper()
        {
            this.reloadMainList();
        }

        private void reloadMainList()
        {
            /* Get the settings */
            Configs configs = new Configs().getSettings();
            DataTable games = new Games().getGamesCatalogue();
            //MessageBox.Show(games.Rows.Count.ToString());
            //Get Images
            Dictionary<int, Image> compatImgs = new ListViewManager().getImageList();
            this.objectListView1.SetObjects(games.Rows);
            this.objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //Set compatibility column to load the images
            this.olvColumnCompatibility.Width = 200;
            this.olvColumnCompatibility.AspectGetter = delegate (object x)
            {
                DataRow strings = (DataRow)x;
                //MessageBox.Show(strings["compatibility"].ToString());
                return compatImgs[int.Parse(strings["compatibility"].ToString())];
            };
            this.olvColumnCompatibility.Renderer = new ImageRenderer();
            //this.objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.RowHeight = 100;
            this.olvColumnCover.Renderer = new ImageRenderer();
        }

        private void addScreenshotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
            int gameId = int.Parse(selectedRow["id"].ToString());
            Form addScreenshotForm = new AddScreenshotForm(gameId);
            addScreenshotForm.ShowDialog();
        }
    }
}