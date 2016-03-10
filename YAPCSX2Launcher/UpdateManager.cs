using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAPCSX2Launcher.Utilities.App
{
    public sealed class UpdateManager
    {
        #region class definition values + init
        private static UpdateManager instance;
        private readonly string currentVersion = Application.ProductVersion.ToString().Replace(".", "");
        public string newVersion { get; set; }
        public bool betaVersions { get; set; }
        public string[] changeLogs { get; set; }
        private readonly string checkVersionUrl = "http://localhost/version.php?beta=";
        private readonly string downloadUrl = "http://localhost/download.php?version=";
        private readonly string changelogUrl = "http://localhost/changelog.php?version=";
        public byte[] appExecutable { get; set; }
        private readonly string[] fields = new[] { "instance", "currentVersion", "newVersion", "betaVersions", "changeLogs", "checkVersionUrl", "downloadUrl", "changeLogUrl", "appExecutable" };

        public static UpdateManager Instance()
        {
            if (instance == null)
                instance = new UpdateManager();
            return instance;
        }
        #endregion

        public static string[] checkUpdates()
        {
            string url = UpdateManager.instance.checkVersionUrl;
            url += (UpdateManager.instance.betaVersions) ? "true" : "false";
            WebClient webMngr = new WebClient();
            string version = webMngr.DownloadString(url);
            //TODO: What do we actually get here?
            string[] returnValues = new[] { UpdateManager.instance.currentVersion, version };
            return returnValues;
        }

        private static void updateApp()
        {
            string url = UpdateManager.instance.downloadUrl;
            url += (UpdateManager.instance.betaVersions) ? "true" : "false";
            WebClient WebMngr = new WebClient();
            UpdateManager.instance.appExecutable = WebMngr.DownloadData(url);
            //TODO: finish
        }

        private static void getChangelogs()
        {
            string url = UpdateManager.instance.changelogUrl + UpdateManager.instance.currentVersion;
            WebClient webMngr = new WebClient();
            UpdateManager.instance.changeLogs = webMngr.DownloadString(url).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }
    }
}
