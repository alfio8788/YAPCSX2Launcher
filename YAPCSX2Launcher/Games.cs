using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Load in the SQLite block
using YAPCSX2Launcher.Utilities.SQLManager;

namespace YAPCSX2Launcher.Utilities.GamesManager
{
    #region Class: Games
    class Games
    {
        #region class definitions
        public int id { get; set; }
        public string name { get; set; }
        public string serial { get; set; }
        public int compatibility { get; set; }
        public string location { get; set; }
        public byte[] cover { get; set; }
        public string region { get; set; }
        public int timeplayed { get; set; }
        public GamesConfigs configs { get; set; }
        public List<Screenshot> screenshot { get; set; } /* Screenshot problems expected */
        public string[] valueFields = new[] { "id", "name", "serial", "compatibility", "location", "cover", "region", "timeplayed", "configs", "screenshot" };
        #endregion
        public bool addGameToDb(Games gameData)
        {
            SQLMngr sqlManager = new SQLMngr();
            int result = sqlManager.addGameToDb(gameData);
            if(result >= 1)
            {
                GamesConfigs gc = new GamesConfigs();
                gameData.configs.gameId = result;
                bool result2 = gc.addConfig(gameData.configs);
                if(result2)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        public Games getGame(int gameId)
        {
            //MessageBox.Show("(From Games.cs) Passed ID: " + gameId.ToString());
            GamesConfigs gc = new GamesConfigs();
            Screenshot ss = new Screenshot();
            SQLMngr sqlMngr = new SQLMngr();
            Games game = sqlMngr.getGame(gameId);
            game.configs = gc.getConfig(gameId);
            game.screenshot = ss.getScreenshots(gameId);
            return game;
        }

        public DataTable getGamesCatalogue()
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.getGameDb();
        }

        public bool removeGame(int gameId)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.removeGame(gameId);
        }

        public bool updateGame(Games gameData)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.editGame(gameData);
        }
    }
    #endregion
    #region Class: Screenshot
    class Screenshot
    {
        public int id { get; set; }
        public int gameid { get; set; }
        public byte[] screenshot { get; set; }

        public bool removeScreenshot(int screenshotId)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.removeScreenShot(screenshotId);
        }

        public bool addScreenshot(Screenshot screenshot)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.addScreenshot(screenshot);
        }

        public List<Screenshot> getScreenshots(int gameId)
        {
            List<Screenshot> ssList = new List<Screenshot>();
            SQLMngr sqlManager = new SQLMngr();
            DataTable screenshotsDt = sqlManager.getGameScreenshots(gameId);
            int ssNumber = screenshotsDt.Rows.Count;
            foreach(DataRow row in screenshotsDt.Rows)
            {
                Screenshot ss = new Screenshot();
                ss.id = int.Parse(row["id"].ToString());
                ss.screenshot = (byte[])row["screenshot"];
                ssList.Add(ss);
            }
            return ssList;
        }

        public bool removeAllScreenShotsForGame(int gameId)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.removeAllScreenshots(gameId);
        }
    }
    #endregion
    #region Class: GameConfigs
    class GamesConfigs
    {
        public int id { get; set; }
        public int gameId { get; set; }
        public string configFolder { get; set; }
        public string bios { get; set; }
        public bool enableCheats { get; set; }
        public bool fromcd { get; set; }
        public bool disableHacks { get; set; }
        public bool fullboot { get; set; }
        public bool nogui { get; set; }

        public bool addConfig(GamesConfigs configData)
        {
            //TODO: Implement checks
            SQLMngr addGameConfig = new SQLMngr();
            return addGameConfig.addGameConfigs(configData);
        }

        public bool updateConfig(GamesConfigs configData)
        {
            //TODO: Implement Checks
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.updateGameConfigs(configData);
        }

        public GamesConfigs getConfig(int gameId)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.getGameConfigs(gameId);
        }

        public bool removeConfig(int gameId)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.removeGameConfigs(gameId);
        }
    }
    #endregion
}