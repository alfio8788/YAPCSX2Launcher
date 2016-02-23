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
    }
}
