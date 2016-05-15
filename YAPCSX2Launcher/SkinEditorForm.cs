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

namespace YAPCSX2Launcher
{
    public partial class SkinEditorForm : Form
    {
        private bool changedSettingsTrigger = false;
        private Skin skinParams;
        public SkinEditorForm()
        {
            InitializeComponent();
            //this.skinParams = new Skin().getSkin();
        }

        private void SkinSettingsCancelButton_Click(object sender, EventArgs e)
        {
            //TODO: Messagebox if settings changed
            this.Close();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            Form skinPreviewForm = new SkinPreviewForm(this.skinParams);
            skinPreviewForm.ShowDialog();
        }

        private void SkinSettingsSaveButton_Click(object sender, EventArgs e)
        {
            bool result = this.skinParams.updateSkin(this.skinParams);
            if(result)
            {
                this.Dispose();
            } else
            {
                MessageBox.Show("ERROR: Skin could not be saved, try again in a few seconds", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (colorTestDialog.ShowDialog() == DialogResult.OK)
            {
                this.changedSettingsTrigger = true;
                this.FormsBackgroundColor.BackColor = colorTestDialog.Color;
                /*var A = colorTestDialog.Color.A; var R = colorTestDialog.Color.R;
                var G = colorTestDialog.Color.G; var B = colorTestDialog.Color.B;*/
                this.skinParams.formbackgroundcolor = colorTestDialog.Color;
            }
        }
        private void FontColorConfigButton_Click(object sender, EventArgs e)
        {
            if (colorTestDialog.ShowDialog() == DialogResult.OK)
            {
                this.FontColorBox.BackColor = colorTestDialog.Color;
                /*var A = colorTestDialog.Color.A; var R = colorTestDialog.Color.R;
                var G = colorTestDialog.Color.G; var B = colorTestDialog.Color.B;*/
                this.skinParams.formfontcolor = colorTestDialog.Color;
            }
        }

        private void FontConfigButton_Click(object sender, EventArgs e)
        {
            if (this.FontDialog.ShowDialog() == DialogResult.OK)
            {
                this.changedSettingsTrigger = true;

                MessageBox.Show(this.FontDialog.Font.ToString());
            }
        }
    }
}
