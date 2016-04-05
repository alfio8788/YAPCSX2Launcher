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
        private int selectedScreenshot;

        public ViewScreenshotsForm(int passedGameId)
        {
            InitializeComponent();
            this.gameId = passedGameId;
            Screenshot screenshots = new Screenshot();
            List<Screenshot> screenshotList = screenshots.getScreenshots(passedGameId);
            this.screens = screenshotList;
            if(screenshotList.Count == 0)
            {
                this.Dispose();
            }
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
            pictureBox.Tag = screenshot.id;
            pictureBox.Name = "ss-" + position;
            this.panel1.Controls.Add(pictureBox);
            pictureBox.MouseClick += new MouseEventHandler(this.clonerBox_Click);

        }

        private void clonerBox_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //MessageBox.Show(pictureBox.Tag.ToString());
                PictureBox pictureBox = (PictureBox)sender;
                using (MemoryStream stream = new MemoryStream(this.screens[int.Parse(pictureBox.Tag.ToString())].screenshot))
                {
                    bigScreenshotBox.Image = new Bitmap(stream);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            { 
                PictureBox pictureBox = (PictureBox)sender;
                int screenshotId = int.Parse(pictureBox.Tag.ToString());
                this.selectedScreenshot = screenshotId;
                ScreenshotMenu.Show(Cursor.Position);
            }
        }

        private void removeScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.selectedScreenshot.ToString());

            if(MessageBox.Show("Are you sure you want to remove this screenshot?","Warning!",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Screenshot screenshotsManager = new Screenshot();
                bool result = screenshotsManager.removeScreenshot(this.selectedScreenshot);
                //bool result = true;
                //bool removedTrigger = false;
                if(result)
                {
                    Form refreshForm = new ViewScreenshotsForm(this.gameId);
                    refreshForm.Size = this.Size;
                    refreshForm.ShowDialog();
                    this.Dispose();
                    #region old code
                    /*foreach(PictureBox pb in this.panel1.Controls.OfType<PictureBox>())
                    {
                        //MessageBox.Show(pb.Tag.ToString());
                        if (removedTrigger)
                        {
                            Point currentLocation = pb.Location;
                            pb.Location = new Point(5, currentLocation.Y - 100);
                            pb.BorderStyle = BorderStyle.Fixed3D;
                        }
                        if (!removedTrigger && int.Parse(pb.Tag.ToString()) == this.selectedScreenshot)
                        {
                            removedTrigger = true;
                            pb.Dispose();
                        }
                    }*/
                    #endregion
                }
                else
                {
                    MessageBox.Show("Error: Could not remove screenshot, Try again in a few seconds!","ERROR!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
