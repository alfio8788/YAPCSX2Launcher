using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.SettingsManager;
using YAPCSX2Launcher.Utilities.GamesManager;
using System.IO;

namespace YAPCSX2Launcher
{
    public partial class FullScreenForm : Form
    {
        private Size formSize;
        //private int gameLine = 0;
        private int gameColumn = 0;
        //private int spacer = 40;
        //private int selectedGame;
        private int wInitPoint = 40;
        private int hInitPoint = 70;
        private float coverProportion = 1.55F;
        private int coverH;

        public FullScreenForm()
        {
            this.formSize = Screen.FromControl(this).Bounds.Size;
            this.Size = this.formSize;
            this.Location = new Point(0, 0);
            InitializeComponent();
            /* get configs */
            Configs cfgs = new Configs().getSettings();
            /* Games */
            DataTable games = new Games().getGamesCatalogue();
            /* get grid */
            int remainingWidth = this.formSize.Width - 280;
            int modSpace = remainingWidth % 6;
            int boxWidthSize = (remainingWidth - modSpace) / 6;
            this.coverH = (int)Math.Round((boxWidthSize * this.coverProportion), 0);
            int counter = 0;
            for (int i = this.gameColumn; i < games.Rows.Count; i++)
            {
                Panel p = new Panel();
                p.Size = new Size(boxWidthSize, this.coverH);
                p.Name = games.Rows[i]["serial"].ToString();
                byte[] cover = new byte[0];
                cover = (byte[])games.Rows[i]["cover"];
                p.BackgroundImage = Bitmap.FromStream(new MemoryStream(cover));
                p.BackgroundImageLayout = ImageLayout.Zoom;
                p.Location = new Point(this.wInitPoint, this.hInitPoint);
                this.wInitPoint += boxWidthSize + 40;
                counter++;
                if(counter == 6)
                {
                    this.wInitPoint = 40;
                    hInitPoint += 40 + this.coverH;
                    counter = 0;
                }
                this.FullscreenPanel.Controls.Add(p);
            }

        }

        private void renderHelper()
        {

        }

        private void FullScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}