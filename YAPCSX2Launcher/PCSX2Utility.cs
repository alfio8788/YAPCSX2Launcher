using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Extra libraries for file reading
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace YAPCSX2Launcher.Utilities.Emulator
{
    class PCSX2Utility
    {
        public static Dictionary<string,string> gameDb()
        {
            /* Load db from assembly */
            Dictionary<string, string> gameDictionary = new Dictionary<string, string>();
            string line;
            Assembly gameDb;
            StreamReader gameDbReader;
            gameDb = Assembly.GetExecutingAssembly();
            //DEBUG
            /*foreach(string abc in gameDb.GetManifestResourceNames())
            {
                if (abc.Contains("gamelist.txt"))
                {
                    MessageBox.Show(abc);
                }
            }*/
            
            gameDbReader = new StreamReader(gameDb.GetManifestResourceStream("YAPCSX2Launcher.Resources.gamelist.txt"));
            while((line = gameDbReader.ReadLine()) != null)
            {
                string[] currentLine = line.Split('\t');
                gameDictionary.Add(currentLine[0],currentLine[1]);
            }
            return gameDictionary;
        }

        //Accepted serial strings for games
        public static readonly string[] AcceptableSerials = {
            "SCUS", "SLUS", "PCPX", "SCAJ", "SCKA", "SCPS", "SLAJ", "SLKA", "SLPM", "SLPS", "TCPS", "PBPS", "SCED", "SCES", "SLED", "SLES", "TCES"
        };

        //Accepted Games exts
        public static readonly string[] AcceptableFormats = {
            ".ISO", ".MDF", ".BIN", ".NRG", ".IMG"
        };

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
                        Console.WriteLine("failed, string is empty");
                    }
                    result = text2.Trim();
                    return result;
                }
            }
            result = string.Empty;
            return result;
        }
    }
}
