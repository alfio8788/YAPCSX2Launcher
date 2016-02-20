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
            System.Threading.Thread.Sleep(5000);
            Close();
        }
    }
}
