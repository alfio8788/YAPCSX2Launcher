using BrightIdeasSoftware;
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
using YAPCSX2Launcher.Utilities.GamesManager;

namespace YAPCSX2Launcher
{
    public partial class ViewScreenshotsForm : Form
    {
        private int gameId;
        private List<Screenshot> screens;
        private int lastScreenPosition = 5;

        public ViewScreenshotsForm(int passedGameId)
        {
            InitializeComponent();
            this.gameId = passedGameId;
            Screenshot screenshots = new Screenshot();
            List<Screenshot> screenshotList = screenshots.getScreenshots(passedGameId);
            this.screens = screenshotList;
            int position = 1;
            foreach (Screenshot screen in screenshotList)
            {
                this.generateMiniatureBox(screen, position);
                position++;
            }

        }

        private void closeButtonImage_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void generateMiniatureBox(Screenshot screenshot, int position)
        {
            Point boxPosition;
            if(position == 1)
            {
                boxPosition = new Point(5, 5);
            } else
            {
                this.lastScreenPosition += 100;
                boxPosition = new Point(5, this.lastScreenPosition);
            }
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(160, 90);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            using (MemoryStream stream = new MemoryStream(screenshot.screenshot))
            {
                pictureBox.Image = new Bitmap(stream);
            }
            pictureBox.Location = boxPosition;
            pictureBox.Tag = position -1;
            pictureBox.Name = "ss-" + position;
            this.panel1.Controls.Add(pictureBox);
            pictureBox.Click += new EventHandler(this.clonerBox_Click);

        }

        private void clonerBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(pictureBox.Tag.ToString());
            PictureBox pictureBox = (PictureBox)sender;
            using (MemoryStream stream = new MemoryStream(this.screens[int.Parse(pictureBox.Tag.ToString())].screenshot))
            {
                bigScreenshotBox.Image = new Bitmap(stream);
            }
        }
    }
}
