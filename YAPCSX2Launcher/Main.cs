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
// Load App Utilities
using YAPCSX2Launcher.Utilities.SQLManager;
using YAPCSX2Launcher.Utilities.GamesManager;
using YAPCSX2Launcher.Utilities.SettingsManager;
using YAPCSX2Launcher.Utilities.MainManager;
//Threading tests
using System.Threading;
using BrightIdeasSoftware;
//using static YAPCSX2Launcher.SingleInstanceMutex;

namespace YAPCSX2Launcher
{
    public partial class Main : Form
    {
        private Configs appSettings;
        public Main()
        {
            #region single instance
            /*SingleInstanceMutex sim = new SingleInstanceMutex();
            if (sim.IsOtherInstanceRunning)
            {
                //MessageBox.Show("ERROR: Only one instance of this program can run at once!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Dispose();
                Application.Exit();
            }*/
            #endregion
            InitializeComponent();
            #region first run
            //First Launch? No problem we will solve this with a configuration wizard, else? Simply show the main window
            string dbfile = foldersAndFiles("dbfile");
            //COMMENT THE IF CONDITION TO SHOW THE WIZARD SETUP FOR DEBUG EVEN AFTER THE SOFTWARE ALREADY CREATED IT'S FIRST CONFIG
            if (!File.Exists(dbfile))
            {
                MessageBox.Show("This is the first time you are running this application, we will now show you a setup wizard to help you configure this application", "First Launch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form wizardForm = new SetupWizardForm();
                wizardForm.ShowDialog();
            }
            #endregion
            /* Get the settings */
            Configs configs = new Configs().getSettings();
            this.appSettings = configs;
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
                this.objectListView1.Visible = true;
                this.GridViewPanel.Visible = false;
            }
            else if (configs.viewMode.ToLower() == "grid")
            {
                pictureBox2_Click(null, null);
                this.objectListView1.Visible = false;
                this.GridViewPanel.Visible = true;
            }
            else if (configs.viewMode.ToLower() == "tv")
            {
                pictureBox1_Click(null, null);
                Form fullscreenForm = new FullScreenForm();
                fullscreenForm.ShowDialog();
                //this.objectListView1.Visible = false;
                //this.GridViewPanel.Visible = false;
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
            this.objectListView1.Visible = true;
            this.GridViewPanel.Visible = false;
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
            //this.objectListView1.View = View.LargeIcon;
            this.objectListView1.Visible = false;
            this.GridViewPanel.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            #region old code
            /* RECOVER FROM ASSEMBLY */
            /*Assembly getImage;
            getImage = Assembly.GetExecutingAssembly();
            Stream buttonImage = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.list_view_n.png");
            Stream buttonImage2 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.grid_view_n.png");
            Stream buttonImage3 = getImage.GetManifestResourceStream("YAPCSX2Launcher.Resources.tv_icon_e.png");
            listViewSwitch.Image = new Bitmap(buttonImage);
            pictureBox2.Image = new Bitmap(buttonImage2);
            pictureBox1.Image = new Bitmap(buttonImage3);*/
            //this.objectListView1.Visible = false;
            //this.GridViewPanel.Visible = false;
            #endregion
            Form fullscreenForm = new FullScreenForm();
            Size formSize = Screen.FromControl(this).Bounds.Size;
            //MessageBox.Show(formSize.Width + "x" + formSize.Height);
            fullscreenForm.Size = formSize;
            fullscreenForm.ShowDialog();
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
                if (objectListView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
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

        private void viewScreenshotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
            int gameId = int.Parse(selectedRow["id"].ToString());

            Form screenshotsForm = new ViewScreenshotsForm(gameId);
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            /* Calculate area of the form */
            float screenWidthMod = (area.Width / 100) * 10;
            float screenHeightMod = (area.Height / 100) * 20;
            float formWidth = area.Width - screenWidthMod;
            float formHeight = area.Height - screenHeightMod;
            Size size = new Size(int.Parse(Math.Round(formWidth, 0).ToString()), int.Parse(Math.Round(formHeight, 0).ToString()));
            screenshotsForm.Size = size;
            try
            {
                screenshotsForm.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No screenshots available, add them first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
            int gameId = int.Parse(selectedRow["id"].ToString());
            this.launchGame(gameId);
        }

        private void objectListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRow selectedRow = (DataRow)this.objectListView1.SelectedObject;
            int gameId = int.Parse(selectedRow["id"].ToString());
            this.launchGame(gameId);
        }

        private void launchGame(int gameId)
        {
            //Get Game Data
            Games game = new Games().getGame(gameId);
            string configFolder = foldersAndFiles("emulatorconfigurationfoler");
            bool firstLaunch = (game.timeplayed == 0) ? true : false;
            if (firstLaunch)
            {
                MessageBox.Show("This is the first time this game is being played from this launcher, PCSX2 will be launched to let you configure the emulator." + Environment.NewLine + "Once configured close the emulator and launch again the game", "First Launch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool result = game.firstRun(gameId);
                if (result)
                {
                    //Launch without params
                    if (string.IsNullOrEmpty(game.configs.customexecutable))
                    {
                        var proc = System.Diagnostics.Process.Start(this.appSettings.pcsx2Executable, "--cfgpath=" + configFolder + game.configs.configFolder);
                        proc.WaitForExit();
                    }
                    else
                    {
                        var proc = System.Diagnostics.Process.Start(@game.configs.customexecutable, "--cfgpath=" + configFolder + game.configs.configFolder);
                        proc.WaitForExit();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Could not set the first run varible correctly, try again in a few seconds", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string launchParams = game.generateLaunchString(game.configs, configFolder, game.location);
                DateTime timenow = DateTime.Now;
                if (string.IsNullOrEmpty(game.configs.customexecutable))
                {
                    //MessageBox.Show(launchParams);
                    var proc = System.Diagnostics.Process.Start(this.appSettings.pcsx2Executable, launchParams);
                    proc.WaitForExit();
                }
                else
                {
                    var proc = System.Diagnostics.Process.Start(game.configs.customexecutable, launchParams);
                    proc.WaitForExit();
                }
                DateTime timeAfter = DateTime.Now;
                int secondsPlayed = (int)timeAfter.Subtract(timenow).TotalSeconds;
                //MessageBox.Show("Emulator was open for: " + secondsPlayed.ToString() + " Seconds");
                game.updatePlaytime(gameId, secondsPlayed);
            }
        }

        private void skinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form skinEditForm = new SkinEditorForm();
            skinEditForm.ShowDialog();
        }
    }
}