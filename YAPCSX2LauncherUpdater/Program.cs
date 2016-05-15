using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAPCSX2LauncherUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            if(File.Exists("YAPCSX2LauncherUpdate.zip"))
            {
                Console.WriteLine("Updating YAPCSX2Launcher...");
                System.IO.Compression.ZipFile.ExtractToDirectory("YAPCSX2LauncherUpdate.zip", "..\\");
                Console.WriteLine("Update Completed");
            }
        }
    }
}
