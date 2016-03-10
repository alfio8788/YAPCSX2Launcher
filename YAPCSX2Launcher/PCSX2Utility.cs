using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Extra libraries for file reading
using System.IO;
using System.Reflection;
//To have the messagebox utility for debug, after debug comment this out...and the messageboxes too
using System.Windows.Forms;
using YAPCSX2Launcher.Utilities.SettingsManager;
using System.Text.RegularExpressions;
using System.Net;

namespace YAPCSX2Launcher.Utilities.Emulator
{
    public sealed class Bios
    {
        #region class definitions
        public string DisplayInfo { get; set; }
        public string Location { get; set; }
        public object Tag { get; set; }
        public readonly string[] fields = new[] { "DisplayInfo", "Location", "Tag" };
        #endregion

        public List<Bios> getBioses()
        {
            Configs settings = new Configs();
            settings = settings.getSettings();
            List<Bios> biosesList = new List<Bios>();
            foreach (var str in Directory.GetFiles(settings.pcsx2DataFolder + "bios"))
            {
                using (var reader = new StreamReader(str))
                {
                    string str2;
                    while ((str2 = reader.ReadLine()) != null)
                    {
                        if (str2.Contains("ROMconf"))
                        {
                            var bytes = (from i in Encoding.UTF8.GetBytes(str2)
                                         where i != 0
                                         select i).ToArray<byte>();
                            var src = Encoding.UTF8.GetString(bytes);
                            var str4 = StringsManipulation.Between(src, (string)"OSDSYS", (string)"@rom");
                            if (StringsManipulation.IsEmpty(str4))
                            {
                                str4 = StringsManipulation.Between(src, (string)"OSDSYS", (string)"@");
                            }
                            Bios item = new Bios
                            {
                                DisplayInfo = StringsManipulation.GetValue(str4),
                                Tag = str,
                                Location = str
                            };
                            biosesList.Add(item);

                        }
                    }
                }
            }
            return biosesList;
        }
    }

    public class StringsManipulation
    {
        private static Regex _invalidXMLChars = new Regex(@"(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|[\x00-\x08\x0B\x0C\x0E-\x1F\x7F-\x9F\uFEFF\uFFFE\uFFFF]", RegexOptions.Compiled);

        public static string RemoveInvalidXMLChars(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            return StringsManipulation._invalidXMLChars.Replace(text, "");
        }

        public static string Between(string src, string findfrom, string findto)
        {
            int index = src.IndexOf(findfrom);
            int num2 = src.IndexOf(findto, (int)(index + findfrom.Length));
            if ((index >= 0) && (num2 >= 0))
            {
                return src.Substring(index + findfrom.Length, (num2 - index) - findfrom.Length);
            }
            return "";
        }

        public static bool IsEmpty(string src)
        {
            return string.IsNullOrWhiteSpace(src);
        }

        public static string GetValue(string text)
        {
            var str = string.Empty;
            foreach (var str2 in text.Split(new char[] { ' ' }))
            {
                if (str2.Contains("ROMconf"))
                {
                    var str3 = StringsManipulation.RemoveInvalidXMLChars(str2);
                    var s = str3.Remove(str3.IndexOf("-")).Remove(0, 1).Insert(4, "/").Insert(7, "/");
                    var str5 = string.Empty;
                    try
                    {
                        str5 = str3.Remove(0, str3.IndexOf("PS2")).Replace("PS2", "").Remove(4).Insert(2, ".");
                    }
                    catch
                    {
                        str5 = "1.00";
                    }
                    var str6 = string.Empty;
                    if (str3.Contains("EC"))
                    {
                        str6 = "Europe";
                    }
                    else if (str3.Contains("AC"))
                    {
                        str6 = "USA";
                    }
                    else if (str3.Contains("WC"))
                    {
                        str6 = "Japan";
                    }
                    else {
                        str6 = "Japan";
                    }
                    if (str3.Contains("142424"))
                    {
                        str6 = "USA";
                    }
                    var time = DateTime.Parse(s);
                    var str7 = string.Format("{0}/{1}/{2}", time.Day, time.Month, time.Year);
                    return string.Format("{2} v{0} ({1})", str5, str7, str6);
                }
            }
            return str;
        }
    }

    class GameImageReader
    {
        #region valid values ranges
        //Accepted serial strings for games
        private static readonly string[] AcceptableSerials = {
            "SCUS", "SLUS", "PCPX",
            "SCAJ", "SCKA", "SCPS",
            "SLAJ", "SLKA", "SLPM",
            "SLPS", "TCPS", "PBPS",
            "SCED", "SCES", "SLED",
            "SLES", "TCES"
        };

        //Accepted Games exts
        private static readonly string[] AcceptableFormats = {
            ".ISO", ".MDF",
            ".BIN", ".NRG",
            ".IMG"
        };
        #endregion

        public static string ExtractSerial(string file)
        {
            string result;
            using (var streamReader = new StreamReader(file))
            {
                streamReader.BaseStream.Position = 30000L;
                string s2;
                while ((s2 = streamReader.ReadLine()) != null)
                {
                    if (streamReader.BaseStream.Position > 600000L)
                        break;
                    var bytes = Encoding.UTF8.GetBytes(s2);
                    var rawString = Encoding.UTF8.GetString(bytes);
                    var text = AcceptableSerials.FirstOrDefault(rawString.Contains);
                    if (text == null) continue;
                    var array = rawString.Substring(rawString.IndexOf(text)).Split(' ');
                    if (array[0].Length == text.Length) continue;
                    var text2 = array[0].Replace(".", "").Replace("_", "-");
                    if (text2.Contains(";"))
                        text2 = text2.Remove(text2.IndexOf(";"));
                    if (text2 == "SLES-5314")
                        text2 = "SLES-53142";
                    try
                    {
                        var text3 = text2.Substring(text2.IndexOf("-")).Replace("-", "");
                        if (char.IsLetter(text3[0]))
                            continue;
                    }
                    catch
                    {
                        MessageBox.Show("Failed, string is empty");
                        //Console.WriteLine("failed, string is empty");
                    }
                    result = text2.Trim();
                    return result;
                }
            }
            result = string.Empty;
            return result;
        }
    }

    class AutoGameInfoDb
    {
        #region class values definitions
        private readonly string url = "http://bositman.pcsx2.net/data/data.csv";
        private readonly string cachedFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\YAPCSX2Launcher\\games.csv";
        private bool localFileExists = File.Exists(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\YAPCSX2Launcher\\games.csv") ? true : false;
        private List<GameDbData> dbCache;
        public readonly string[] fields = new[] { "url", "cachedFile", "localFileExists", "dbCache" };
        #endregion

        public bool updateDbFile()
        {
            bool status = true;
            byte[] downloadedFile;
            WebClient webManager = new WebClient();
            try
            {
                downloadedFile = webManager.DownloadData(this.url);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                downloadedFile = null;
                status = false;
            }
            if(localFileExists && status)
            {
                File.Delete(this.cachedFile);
            }
            if(status && localFileExists)
            {
                File.Delete(this.cachedFile);
                File.WriteAllBytes(this.cachedFile, downloadedFile);
                this.localFileExists = true;
            } else
            {
                File.WriteAllBytes(this.cachedFile, downloadedFile);
                this.localFileExists = true;
            }
            return status;
        }

        public void cacheGameInfos()
        {
            if (this.localFileExists)
            {
                this.dbCache = new List<GameDbData>();
                string[] strings = File.ReadAllLines(this.cachedFile);
                foreach(string dataString in strings)
                {
                    int sep = 9;
                    char delimiter = Convert.ToChar(sep);
                    string[] tmpString = dataString.Split(delimiter);

                    GameDbData tmpGameData = new GameDbData();
                    tmpGameData.serial = tmpString[0];
                    tmpGameData.compatibility = int.Parse(tmpString[1]);
                    tmpGameData.version = tmpString[2];
                    tmpGameData.hex = tmpString[3];
                    tmpGameData.dateTested = tmpString[4];
                    tmpGameData.name = tmpString[5];
                    tmpGameData.region = tmpString[6];
                    this.dbCache.Add(tmpGameData);
                }
            } else
            {
                this.dbCache = null;
            }
        }

        public GameDbData findGameInfo(string serial)
        {
            serial = serial.Replace("-", "");
            if(this.dbCache != null)
            {
                foreach(GameDbData data in this.dbCache)
                {
                    if(data.serial == serial)
                    {
                        return data;
                    }
                }
                return null;
            } else
            {
                return null;
            }
        }
    }

    class GameDbData
    {
        #region class values definitions
        public string serial { get; set; }
        public int compatibility { get; set; }
        public string version { get; set; }
        public string hex { get; set; }
        public string dateTested { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public readonly string[] fields = new[] { "serial", "compatibility", "version", "hex", "dateTested", "name", "region"};
        #endregion
    }    
}
