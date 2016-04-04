using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.Emulator;
using YAPCSX2Launcher.Utilities.GamesManager;

namespace YAPCSX2Launcher
{
    public partial class GameConfigEditForm : Form
    {
        private GamesConfigs gameConfig;

        public GameConfigEditForm(int gameId)
        {
            InitializeComponent();
            //Set Bioses values first
            Bios biosManager = new Bios();
            List<Bios> bioses = biosManager.getBioses();

            this.biosComboBox.DataSource = bioses;
            this.biosComboBox.DisplayMember = "DisplayInfo";
            this.biosComboBox.ValueMember = "Location";

            this.gameConfig = new GamesConfigs().getConfig(gameId);
            this.fullbootSwitch.Checked = gameConfig.fullboot;
            this.fromCdSwitch.Checked = gameConfig.fromcd;
            this.enableCheatsSwitch.Checked = gameConfig.enableCheats;
            this.disableHacksSwitch.Checked = gameConfig.disableHacks;
            this.noguiSwitch.Checked = gameConfig.nogui;
            this.biosComboBox.SelectedValue = gameConfig.bios;
            this.CustomExecutableTextBox.Text = (string.IsNullOrEmpty(gameConfig.customexecutable)) ? gameConfig.customexecutable : "";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //TODO: Warn user
            Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GamesConfigs gameConfig = new GamesConfigs();
            /*
            @configfolder
            @bios
            @enablecheat
            @fromcd
            @disablehacks
            @fullboot
            @nogui
            @gameid
            @customexecutable
            */
            gameConfig.configFolder = this.gameConfig.configFolder;
            gameConfig.bios = this.biosComboBox.SelectedValue.ToString();
            gameConfig.enableCheats = this.enableCheatsSwitch.Checked;
            gameConfig.fromcd = this.fromCdSwitch.Checked;
            gameConfig.disableHacks = this.disableHacksSwitch.Checked;
            gameConfig.fullboot = this.fullbootSwitch.Checked;
            gameConfig.nogui = this.noguiSwitch.Checked;
            gameConfig.customexecutable = (string.IsNullOrEmpty(this.CustomExecutableTextBox.Text.ToString())) ? null : this.CustomExecutableTextBox.Text.ToString().ToLower();
            gameConfig.gameId = this.gameConfig.gameId;

            bool result = gameConfig.updateConfig(gameConfig);
            if(result)
            {
                Dispose();
            } else
            {
                MessageBox.Show("Error: Settings couldn't be saved, try again later", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomExecutableButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog customExeDialog = new OpenFileDialog();
            customExeDialog.Filter = "Executable Files (*.exe) | *.exe";
            if (customExeDialog.ShowDialog() == DialogResult.OK)
            {
                CustomExecutableTextBox.Text = customExeDialog.FileName;
            }
        }
    }
}
