using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Extra libraries for file reading
using System.IO;

namespace YAPCSX2Launcher.Utilities.Emulator
{
    class PCSX2Utility
    {
        /* DO WE REALLY NEED ALL THIS???? */
        private string readGameDatabase(string databasePath)
        {
            string dbContents = File.ReadAllText(databasePath);
            return dbContents;
        }

        private string[] filterDatabase(string databasePath)
        {
            bool firstLineTrigger = false;
            string tmpString = null;
            string[] dbData = new string[100000];
            string[] filteredDb = new string[100000];
            dbData = File.ReadAllLines(databasePath);
            Parallel.For(0, dbData.Length, x =>
            {
                //Useless to keep in memory part of the file that we do not need
                if(dbData[x] == "-- Game List")
                {
                    firstLineTrigger = true;
                }
                //Start the real mess only once the trigger is set....to the end of time
                if (firstLineTrigger)
                {
                    tmpString = lineFilter(dbData[x]);
                    if (tmpString != null)
                    {
                        filteredDb[x] = tmpString;
                    }
                }
            }
            );
            return null;
        }

        private string lineFilter(string stringToFilter)
        {
            string returnValue;
            //Line is a comment, return nothing
            if(stringToFilter.Remove(2) == "//")
            {
                returnValue = null;
            } else
            {
                returnValue = stringToFilter;
            }
            return returnValue;
        }

        private string isSerialField(string stringToCheck)
        {
            return stringToCheck;
        }
    }
}
