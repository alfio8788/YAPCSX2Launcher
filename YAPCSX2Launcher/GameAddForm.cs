using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using YAPCSX2Launcher.Properties;
using YAPCSX2Launcher.Utilities.Emulator;
using YAPCSX2Launcher.Utilities.SettingsManager;
using YAPCSX2Launcher.Utilities.GamesManager;
using YAPCSX2Launcher.Utilities.Formats;

namespace YAPCSX2Launcher
{
    public partial class GameAddForm : Form
    {
        #region valid extentions array
        //Accepted Games exts
        private static readonly string[] AcceptableImageFormats = {
            ".ISO", ".MDF",
            ".BIN", ".NRG",
            ".IMG"
        };
        #endregion

        private Configs configs;

        public GameAddForm()
        {
            InitializeComponent();
        }

        private void gameAddCancelButton_Click(object sender, EventArgs e)
        {
            //TODO: Ask confirmation
            Dispose();
        }

        private void GameAddForm_Load(object sender, EventArgs e)
        {
            #region compatibility values array
            var compatibilityValues = new[]
            {
                new { Text = "1", Value = "1" },
                new { Text = "2", Value = "2" },
                new { Text = "3", Value = "3" },
                new { Text = "4", Value = "4" },
                new { Text = "5", Value = "5" }
            };
            #endregion
            this.compatibilityComboBox.DataSource = compatibilityValues;
            this.compatibilityComboBox.DisplayMember = "Text";
            this.compatibilityComboBox.ValueMember = "Value";

            Bios biosManager = new Bios();
            List<Bios> bioses = biosManager.getBioses();

            this.biosComboBox.DataSource = bioses;
            this.biosComboBox.DisplayMember = "DisplayInfo";
            this.biosComboBox.ValueMember = "Location";

            this.configs = new Configs().getSettings();
            
        }

        private void buttonLocateFile_Click(object sender, EventArgs e)
        {
            string imageFormats = "DVD Image Files|";
            foreach(string format in AcceptableImageFormats)
            {
                imageFormats += "*" + format + ";";
            }
            OpenFileDialog gameImageDialog = new OpenFileDialog();
            gameImageDialog.CheckFileExists = true;
            gameImageDialog.CheckPathExists = true;
            gameImageDialog.Filter = imageFormats;
            if (gameImageDialog.ShowDialog() == DialogResult.OK)
            {
                isoFileTextBox.Text = gameImageDialog.FileName;
                //MessageBox.Show(gameImageDialog.FileName);
                string res = YAPCSX2Launcher.Utilities.Emulator.GameImageReader.ExtractSerial(isoFileTextBox.Text);
                if (string.IsNullOrEmpty(res))
                {
                    MessageBox.Show("The automatic identification of this Disc image failed, you will have to insert the data on your own", "Game Serial not found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.enableBoxes();
                } else
                {
                    //Retrieve game data
                    this.Cursor = Cursors.WaitCursor;
                    AutoGameInfoDb gameInfos = new AutoGameInfoDb();
                    gameInfos.cacheGameInfos();
                    GameDbData foundGameInfos = gameInfos.findGameInfo(res);
                    if(foundGameInfos == null)
                    {
                        MessageBox.Show(
                            "This game was not found in the DB, you will have to fill the infos on your own",
                            "Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                        this.enableBoxes();
                    } else
                    {
                        this.gameDataGroupBox.Visible = true;
                        this.serialTextBox.Text = foundGameInfos.serial;
                        this.regionTextBox.Text = foundGameInfos.region;
                        this.nameTextBox.Text = foundGameInfos.name;
                        this.compatibilityComboBox.SelectedIndex = foundGameInfos.compatibility - 1;
                        this.coverFindButton.Enabled = true;
                        if(this.configs.remoteInfo)
                        {
                            //TODO: Cover finding
                            MessageBox.Show(
                                "Warning: automatic cover finding is not implemented yet (remoteinfo setting)",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
                        } else
                        {
                            //Do nothing for now
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void enableBoxes()
        {
            this.gameDataGroupBox.Visible = true;
            this.serialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialTextBox.Enabled = true;
            this.regionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regionTextBox.Enabled = true;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Enabled = true;
            this.compatibilityComboBox.Enabled = true;
            this.coverFindButton.Enabled = true;
        }

        private void disableBoxes()
        {
            this.gameDataGroupBox.Visible = false;
            this.serialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialTextBox.Enabled = false;
            this.regionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.regionTextBox.Enabled = false;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Enabled = false;
            this.compatibilityComboBox.Enabled = false;
            this.coverFindButton.Enabled = false;
        }

        private void gameAddButton_Click(object sender, EventArgs e)
        {
            //cover
            byte[] image = null;
            if(!string.IsNullOrEmpty(this.coverTextBox.Text))
            {
                if(File.Exists(this.coverTextBox.Text))
                {
                    FileInfo imageInfos = new FileInfo(this.coverTextBox.Text);
                    FileStream imageStream = new FileStream(this.coverTextBox.Text, FileMode.Open);
                    BinaryReader imageBinaryReader = new BinaryReader(imageStream);
                    image = imageBinaryReader.ReadBytes(Convert.ToInt32(imageInfos.Length));
                    imageStream.Close();
                    imageBinaryReader.Close();
                }
            } else
            {
                //Get Cover From assembly
                Stream gameCoverAssemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("YAPCSX2Launcher.Resources.no_cover.png");
                var ms = new MemoryStream();
                gameCoverAssemblyStream.CopyTo(ms);
                image = ms.ToArray();
                gameCoverAssemblyStream.Close();
                ms.Close();
            }
            GamesConfigs gc = new GamesConfigs();
            Games game = new Games();
            game.name = nameTextBox.Text.ToString();
            game.cover = image;
            game.location = this.isoFileTextBox.Text.ToString();
            game.region = this.regionTextBox.Text.ToString();
            game.serial = this.serialTextBox.Text.ToString();
            game.compatibility = int.Parse(this.compatibilityComboBox.SelectedValue.ToString());
            gc.bios = this.biosComboBox.SelectedValue.ToString();
            gc.configFolder = this.serialTextBox.Text.ToString();
            gc.disableHacks = (this.disableHacksSwitch.Checked) ? true : false;
            gc.enableCheats = (this.enableCheatsSwitch.Checked) ? true : false;
            gc.fromcd = (this.fromCdSwitch.Checked) ? true : false;
            gc.fullboot = (this.fullbootSwitch.Checked) ? true : false;
            gc.nogui = (this.noguiSwitch.Checked) ? true : false;
            gc.customexecutable = (string.IsNullOrEmpty(this.CustomExecutableTextBox.Text.ToString())) ? null : this.CustomExecutableTextBox.ToString().ToLower();
            game.configs = gc;
            bool result = game.addGameToDb(game);
            if(result)
            {
                //Reload the main window
                Dispose();
            } else
            {
                MessageBox.Show("Error: Unable to add game", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void coverFindButton_Click(object sender, EventArgs e)
        {
            string imageFile;
            OpenFileDialog imageFileDialog = new OpenFileDialog();
            imageFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (imageFileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO: Check if it's an actual image file or the app will crash
                imageFile = imageFileDialog.FileName;
                coverTextBox.Text = imageFile;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Visible = true;
                FileStream imageBoxFile = new FileStream(imageFile, FileMode.Open);
                pictureBox1.Image = new Bitmap(imageBoxFile);
                imageBoxFile.Dispose();
            }
        }

        private void CustomExecutableButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog customExeDialog = new OpenFileDialog();
            customExeDialog.Filter = "Executable Files (*.exe) | *.exe";
            if(customExeDialog.ShowDialog() == DialogResult.OK)
            {
                CustomExecutableTextBox.Text = customExeDialog.FileName;
            }
        }
    }
}
