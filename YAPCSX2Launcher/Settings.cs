using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//SQLManager
using YAPCSX2Launcher.Utilities.SQLManager;

namespace YAPCSX2Launcher.Utilities.SettingsManager
{
    class Configs
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
        public readonly string[] fields = new[] { "int", "pcsx2Folder", "pcsx2DataFolder", "pcsx2Executable", "viewMode", "gamepadSupport", "gamepadOkButton", "gamepadCancelButton", "sorting", "ordering", "remoteinfo" };
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
}
