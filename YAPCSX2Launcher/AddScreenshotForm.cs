using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.Formats;
using YAPCSX2Launcher.Utilities.GamesManager;

namespace YAPCSX2Launcher
{
    public partial class AddScreenshotForm : Form
    {
        private int gameId;
        public AddScreenshotForm(int gameId)
        {
            InitializeComponent();
            this.gameId = gameId;
            //MessageBox.Show(this.gameId.ToString());
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            string imageFile;
            OpenFileDialog imageFileDialog = new OpenFileDialog();
            imageFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (imageFileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO: Check if it's an actual image file or the app will crash
                FormatValidityControl checkImage = new FormatValidityControl();
                imageFile = imageFileDialog.FileName;
                bool check = checkImage.isValidImage(imageFile);
                if (check)
                {
                    screenshotTextBox.Text = imageFile;
                    screenshotPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    screenshotPictureBox.Visible = true;
                    FileStream imageBoxFile = new FileStream(imageFile, FileMode.Open);
                    screenshotPictureBox.Image = new Bitmap(imageBoxFile);
                    imageBoxFile.Dispose();
                    this.saveButton.Enabled = true;
                } else
                {
                    this.saveButton.Enabled = false;
                    MessageBox.Show("Error: Not a valid image File","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddScreenshotForm_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Screenshot screenshot = new Screenshot();
            screenshot.gameid = this.gameId;
            FileInfo imageInfos = new FileInfo(this.screenshotTextBox.Text);
            FileStream imageStream = new FileStream(this.screenshotTextBox.Text, FileMode.Open);
            BinaryReader imageBinaryReader = new BinaryReader(imageStream);
            screenshot.screenshot = imageBinaryReader.ReadBytes(Convert.ToInt32(imageInfos.Length));
            imageStream.Close();
            imageBinaryReader.Close();

            bool result = screenshot.addScreenshot(screenshot);
            if(result)
            {
                Dispose();
            } else
            {
                MessageBox.Show("Error: Couldn't add screenshot, try again later","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //TODO: Warn user (needed?)
            Dispose();
        }
    }
}
