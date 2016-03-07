using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Screenshot[] screenshot { get; set; }
        #endregion
        public bool addGameToDb(Games gameData)
        {
            SQLMngr sqlManager = new SQLMngr();
            return sqlManager.addGameToDb(gameData); ;
        }

        public Games getGame(int gameId)
        {
            GamesConfigs gc = new GamesConfigs();
            Screenshot ss = new Screenshot();
            DataTable gameDt = new DataTable();
            gameDt = getGamesCatalogue();
            Games game = new Games();
            game.id = int.Parse(gameDt.Rows[gameId - 1]["id"].ToString());
            game.name = gameDt.Rows[gameId - 1]["name"].ToString();
            game.serial = gameDt.Rows[gameId - 1]["serial"].ToString();
            game.compatibility = int.Parse(gameDt.Rows[gameId - 1]["compatibility"].ToString());
            game.location = gameDt.Rows[gameId - 1]["filelocation"].ToString();
            game.cover = (byte[])gameDt.Rows[gameId -1]["cover"];
            game.region = gameDt.Rows[gameId -1]["region"].ToString();
            game.timeplayed = int.Parse(gameDt.Rows[gameId - 1]["timeplayed"].ToString());
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

        public Screenshot[] getScreenshots(int gameId)
        {
            SQLMngr sqlManager = new SQLMngr();
            DataTable screenshotsDt = sqlManager.getGameScreenshots(gameId);
            int ssNumber = screenshotsDt.Rows.Count;
            Screenshot[] screenshots = new Screenshot[ssNumber];
            int count = 0;
            foreach(DataRow row in screenshotsDt.Rows)
            {
                Screenshot ss = new Screenshot();
                ss.id = int.Parse(row["id"].ToString());
                ss.screenshot = (byte[])row["screenshot"];
                screenshots[count] = ss;
                count++;
            }
            return screenshots;
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