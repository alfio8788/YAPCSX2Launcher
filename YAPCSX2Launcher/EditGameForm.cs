using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.GamesManager;
using System.IO;
using System.Reflection;

namespace YAPCSX2Launcher
{
    public partial class EditGameForm : Form
    {
        #region compatibility values array
        /* Compatibility values */
        Array compatibilityValues = new[]
        {
                new { Text = "1", Value = "1" },
                new { Text = "2", Value = "2" },
                new { Text = "3", Value = "3" },
                new { Text = "4", Value = "4" },
                new { Text = "5", Value = "5" }
        };
        #endregion
        /* Empty holders*/
        private Games currentGame;

        public EditGameForm(int gameId)
        {
            InitializeComponent();
            /* set compatibility box (on load does not fix it) */
            this.compatibilityComboBox.DataSource = this.compatibilityValues;
            this.compatibilityComboBox.DisplayMember = "Text";
            this.compatibilityComboBox.ValueMember = "Value";
            //MessageBox.Show("(From EditGameForm.cs) Passed ID: " + gameId);
            //Get Game Data & Configs
            Games game = new Games();
            GamesConfigs gameConfigs = new GamesConfigs();
            game = game.getGame(gameId);
            this.currentGame = game;
            gameConfigs = game.configs;

            /* Set form elements */
            this.SerialTextBox.Text = game.serial;
            this.iDTextBox.Text = game.id.ToString();
            this.locationTextBox.Text = game.location;
            this.regionTextBox.Text = game.region;
            this.nameTextBox.Text = game.name;
            this.compatibilityComboBox.SelectedValue = game.compatibility.ToString();
            /*game cover */
            Bitmap image;
            using (MemoryStream stream = new MemoryStream(game.cover))
            {
                image = new Bitmap(stream);
            }
            this.pictureBox1.Image = image;


        }

        private void EditGameForm_Load(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            /* TODO: Notice the user */
            Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Games game = new Games();
            /* Retrieve all the values */
            game.id = int.Parse(this.iDTextBox.Text);
            game.location = this.locationTextBox.Text;
            game.name = this.nameTextBox.Text;
            game.region = this.regionTextBox.Text;
            game.serial = this.SerialTextBox.Text;
            game.compatibility = int.Parse(this.compatibilityComboBox.SelectedValue.ToString());
            if(string.IsNullOrEmpty(this.coverTextBox.Text))
            {
                game.cover = this.currentGame.cover;
            } else
            {
                byte[] image;
                if (File.Exists(this.coverTextBox.Text))
                {
                    FileInfo imageInfos = new FileInfo(this.coverTextBox.Text);
                    FileStream imageStream = new FileStream(this.coverTextBox.Text, FileMode.Open);
                    BinaryReader imageBinaryReader = new BinaryReader(imageStream);
                    image = imageBinaryReader.ReadBytes(Convert.ToInt32(imageInfos.Length));
                    imageStream.Close();
                    imageBinaryReader.Close();
                } else
                {
                    MessageBox.Show("Warning: Specified Cover file Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Get Cover From assembly
                    Stream gameCoverAssemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("YAPCSX2Launcher.Resources.no_cover.png");
                    var ms = new MemoryStream();
                    gameCoverAssemblyStream.CopyTo(ms);
                    image = ms.ToArray();
                    gameCoverAssemblyStream.Close();
                    ms.Close();
                }
                game.cover = image;
            }
            bool result = game.updateGame(game);
            if(result)
            {
                Dispose();
            } else
            {
                MessageBox.Show("Error: Couldn't Update Game Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
