using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//SQLManager
using YAPCSX2Launcher.Utilities.SQLManager;

namespace YAPCSX2Launcher.Utilities.SettingsManager
{
    public class Configs
    {
        #region valid variable ranges arrays
        /* VARS VALID RANGES */
        private static readonly int[] isValidCompatibilityRange = { 0, 1, 2, 3, 4, 5 };
        private static readonly bool[] isValidBoolRange = { true, false };
        private static readonly string[] isValidViewModeRange = { "list", "grid", "tv" };
        private static readonly string[] isValidSorting = { "alphabetical", "serial", "id", "region" };
        private static readonly string[] isValidSortingDirection = { "asc", "desc" };
        #endregion
        #region class Configs : array details
        public readonly int id = 1;
        public string pcsx2Folder { get; set; }
        public string pcsx2DataFolder { get; set; }
        public string pcsx2Executable { get; set; }
        public string viewMode { get; set; }
        public bool gamepadSupport { get; set; }
        public string gamepadOkButton { get; set; }
        public string gamepadCancelButton { get; set; }
        public string sorting { get; set; }
        public string ordering { get; set; }
        public bool remoteInfo { get; set; }

        #region class definition list
        public readonly string[] fields = new[] { "int", "pcsx2Folder", "pcsx2DataFolder", "pcsx2Executable", "viewMode", "gamepadSupport", "gamepadOkButton", "gamepadCancelButton", "sorting", "ordering", "remoteinfo" };
        #endregion
        #endregion

        public Configs getSettings()
        {
            SQLMngr sqlManager = new SQLMngr();
            DataTable configs = sqlManager.getSettings();
            Configs settings = new Configs();
            settings.pcsx2Folder = configs.Rows[0]["pcsx2folder"].ToString();
            settings.pcsx2DataFolder = configs.Rows[0]["pcsx2datafolder"].ToString();
            settings.pcsx2Executable = configs.Rows[0]["pcsx2executable"].ToString();
            settings.viewMode = configs.Rows[0]["viewmode"].ToString();
            settings.gamepadSupport = bool.Parse(configs.Rows[0]["gamepadsupport"].ToString());
            settings.gamepadOkButton = configs.Rows[0]["gamepadokbutton"].ToString();
            settings.gamepadCancelButton = configs.Rows[0]["gamepadcancelbutton"].ToString();
            settings.remoteInfo = bool.Parse(configs.Rows[0]["remoteinfo"].ToString());
            settings.ordering = configs.Rows[0]["ordering"].ToString();
            settings.sorting = configs.Rows[0]["sorting"].ToString();
            return settings;
        }

        public bool saveSettings(Configs settings)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.saveSettings(settings);
        }

        public bool updateSettings(Configs settings)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.updateSettings(settings);
        }
    }

    public class Skin
    {
        public readonly int id = 1;
        public byte[] fullscreenbackgroundimage { get; set; }
        public byte[] mainscreenbackgroundimage { get; set; }
        public byte[] mainscreengridbackgroundimage { get; set; }
        //public byte[] splashscreenimage { get; set; }
        public Color formbackgroundcolor { get; set; }
        public Color formfontcolor { get; set; }
        public Font insideformfont { get; set; }
        
        /* Useless as of now since there is no multiskin support yet*/
        /*public bool saveSkin(Skin skinSettings)
        {
            return true;
        }*/

        public bool updateSkin(Skin skinSettings)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.updateSkin(skinSettings);
        }

        public Color convertToColor(string color)
        {
            string[] colors = Regex.Split(color, ",");
            return Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]), int.Parse(colors[3]));
        }

        public string convertFromColor(Color color)
        {
            return color.A + "," + color.R + "," + color.G + "," + color.B;
        }

        public Skin getSkin()
        {
            SQLMngr sqlManager = new SQLMngr();
            DataRow skinDataRow = sqlManager.getSkin().Rows[0];
            Skin skinParams = new Skin();
            skinParams.fullscreenbackgroundimage = (byte[])skinDataRow["fullscreenbackgroundimage"];
            skinParams.mainscreenbackgroundimage = (byte[])skinDataRow["mainscreenbackgroundimage"];
            skinParams.mainscreengridbackgroundimage = (byte[])skinDataRow["mainscreengridbackgroundimage"];
            //skinParams.splashscreenimage = (byte[])skinDataRow["splashscreenimage"];
            return skinParams;
        }

        public void setSkin(Form form, Skin skinParams, string formname)
        {
            formname = formname.ToLower();
            switch(formname)
            {
                case "main":
                    this._mainFormSkinHelper(form, skinParams);
                    break;
                case "fullscreen":
                    this._fullscreenSkinHelper(form, skinParams);
                    break;
                case "splash":
                    this._splashscreenSkinHelper(form, skinParams);
                    break;
                default:
                    break;
            }

        }

        private void _mainFormSkinHelper(Form form, Skin skin)
        {

        }

        private void _fullscreenSkinHelper(Form form, Skin skin)
        {

        }

        private void _splashscreenSkinHelper(Form form, Skin skin)
        {

        }
    }

    public class DbSkin
    {
        public int id = 1;
        public byte[] fullscreenbackgroundimage { get; set; }
        public byte[] mainscreenbackgroundimage { get; set; }
        public byte[] mainscreengridbackgroundimage { get; set; }
        public byte[] splashscreenimage { get; set; }
        public string formbackgroundcolor { get; set; }
        public string formfontcolor { get; set; }
        public string insideformfont { get; set; }

        public Skin getSkin()
        {
            DataRow dbSkin = new SQLMngr().getSkin().Rows[0];
            Skin skin = new Skin();
            skin.formbackgroundcolor = skin.convertToColor(dbSkin["formbackgroundcolor"].ToString());
            skin.mainscreenbackgroundimage = (byte[])dbSkin["mainscreenbackgroundimage"];
            skin.mainscreengridbackgroundimage = (byte[])dbSkin["mainscreengridbackgroundimage"];
            //skin.splashscreenimage = (byte[])dbSkin["splashscreenimage"];
            skin.fullscreenbackgroundimage = (byte[])dbSkin["fullscreenbackgroundimage"];
            //skin.formfontcolor =
            //skin.insideformfont =
            return skin;
        }
    }
}
