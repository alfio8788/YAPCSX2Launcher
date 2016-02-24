using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAPCSX2Launcher
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            //DEBUG ONLY, TODO: Make the splash screen actually do cool stuff :)
            Show();
            splashProgress.Maximum = 10000000;
            splashProgress.Step = 1;
            for(int j = 0; j < 10000000; j++)
            {
                splashProgress.PerformStep();
            }
            System.Threading.Thread.Sleep(1000);
            Close();
        }
    }
}
