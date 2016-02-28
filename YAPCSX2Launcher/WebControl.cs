using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAPCSX2Launcher
{
    class WebControl
    {
        public string searchGame(string gameName)
        {
            //TODO
            return null;
        }

        private static string[] extractGameData(string url)
        {
            //TODO
            return null;
        }

        public string[] returnGameData(string url)
        {
            //TODO
            return null;
        }

        private static string getBaseURL(string value)
        {
            Dictionary<string, string> baseUrls = new Dictionary<string, string>();
            baseUrls.Add("baseurl", "http://sitemap.gamefaqs.com/game/ps2/");
            //baseUrls.Add("", "");
            return baseUrls["baseurl"];
        }

        public static string pcsx2GameDataURL()
        {
            return "http://bositman.pcsx2.net/data/data.csv";
        }
    }
}
