using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
//Load the Settings and Games Class to know what we are doing
using YAPCSX2Launcher.Utilities.GamesManager;
using YAPCSX2Launcher.Utilities.SettingsManager;

namespace YAPCSX2Launcher.Utilities.SQLManager
{
    class SQLMngr
    {
        #region sqlite adapters and connection strings
        /* SQL connection related variables */
        private string dbLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\YAPCSX2Launcher\\YAPCSX2Launcher.db3";
        private string sqlConnectionString;
        private SQLiteConnection sqlConnection;
        private SQLiteDataAdapter sqlDataAdapter;
        #endregion
        #region datatables and datasets
        /* DataTables & DataSets */
        public DataTable gamesDataTable = new DataTable();
        public DataSet gamesDataSet = new DataSet();
        public DataTable screenshotsDataTable = new DataTable();
        public DataSet screenshotsDataSet = new DataSet();
        public DataTable settingsDataTable = new DataTable();
        public DataSet settingsDataSet = new DataSet();
        public DataTable gameSettingsDataTable = new DataTable();
        public DataSet gameSettingsDataSet = new DataSet();
        #endregion
        #region datatables and datasets clones
        /* And the clones */
        public DataTable gamesDataTableClone;
        //public DataSet gameDataSetClone;
        public DataTable screenshotsDataTableClone;
        //public DataSet screenshotsDataSetClone;
        public DataTable settingsDataTableClone;
        //public DataSet settingsDataSetClone;
        //public DataTable gameSettingsDataTableClone;
        //public DataSet gameSettingsDataSetClone;
        #endregion
        #region queries
        /* SQLite Queries: general */
        private SQLiteCommand cleanDbQuery = new SQLiteCommand("VACUUM");//optimizeWholeDb (DONE)
        private SQLiteCommand cleanTableQuery = new SQLiteCommand("VACUUM @tablename");//optimizeDbTable (DONE)
        /* SQLite Queries: settings */
        private SQLiteCommand getSettingsQuery = new SQLiteCommand("SELECT * FROM settings WHERE id = 1"); //getSettings (DONE)
        private SQLiteCommand saveSettingsQuery = new SQLiteCommand("INSERT INTO settings (id, pcsx2folder, pcsx2datafolder, pcsx2executable, viewmode, gamepadsupport, gamepadokbutton, gamepadcancelbutton, sorting, ordering, remoteinfo) VALUES(@id, @pcsx2folder, @pcsx2datafolder, @pcsx2executable, @viewmode, @gamepadsupport, @gamepadokbutton, @gamepadcancelbutton, @sorting, @ordering, @remoteinfo)"); //saveSettings (DONE)
        private SQLiteCommand updateSettingsQuery = new SQLiteCommand("UPDATE settings SET pcsx2folder = @pcsx2folder, pcsx2datafolder = @pcsx2datafolder, pcsx2executable = @pcsx2executable, viewmode = @viewmode, gamepadsupport = @gamepadsupport, gamepadokbutton = @gamepadokbutton, gamepadcancelbutton = @gamepadcancelbutton, sorting = @sorting, remoteinfo = @remoteinfo, ordering = @ordering WHERE id = 1"); //updateSettings (DONE)
        /* SQLite Queries: games */
        private string getGamesQuery = "SELECT * FROM games ORDER BY {0} {1}"; //getGameDb (DONE)
        private SQLiteCommand gameAddQuery = new SQLiteCommand("INSERT INTO games(serial, name, filelocation, compatibility, region, cover) VALUES (@serial, @name, @filelocation, @compatibility, @region, @cover)");//addGameToDb (Done)
        private SQLiteCommand updatePlayTimeQuery = new SQLiteCommand("UPDATE games SET timeplayed = timeplayed+@timeplayed WHERE id = @gameid"); //updateGamePlayTime (DONE)
        private SQLiteCommand removeGameQuery = new SQLiteCommand("DELETE FROM games WHERE id = @gameid"); //removeGame (DONE)
        private SQLiteCommand updateGameData = new SQLiteCommand("UPDATE games SET serial = @serial, name = @name, filelocation = @filelocation, compatibility = @compatibility, region = @region, cover = @cover WHERE id = @gameid"); //editGame (DONE)
        private SQLiteCommand updateCoverQuery = new SQLiteCommand("UPDATE games set cover = @cover WHERE id = @id"); //updateGameCover (DONE)
        private SQLiteCommand getGameQuery = new SQLiteCommand("SELECT * FROM games WHERE id = @id"); //getGame (DONE)
        /* SQLite Queries: screenshots*/
        private SQLiteCommand addScreenshotQuery = new SQLiteCommand("INSERT INTO screenshots (gameid, screenshot) VALUES (@gameid,@screenshot)");//addScreenshot (DONE)
        private SQLiteCommand removeScreenshotQuery = new SQLiteCommand("DELETE FROM screenshots WHERE id = @screenshotid");//removeScreenShot (DONE)
        private SQLiteCommand removeAllScreenshotsQuery = new SQLiteCommand("DELETE FROM screenshots WHERE gameid = @gameid");//removeAllScreenshots (DONE)
        private SQLiteCommand getScreenshotsQuery = new SQLiteCommand("SELECT * FROM screenshots WHERE gameid = @gameid");//getGameScreenshots (DONE)
        private SQLiteCommand getSingleScreenshotQuery = new SQLiteCommand("SELECT * FROM screenshots WHERE id = @screenshotid");//getSingleScreenshot (DONE)
        /* SQLite Queries: gamesconfigs*/
        private SQLiteCommand getGameConfigsQuery = new SQLiteCommand("SELECT * FROM gamesconfigs WHERE gameid = @gameid");//getGameConfigs (DONE)
        private SQLiteCommand removeGameConfigsQuery = new SQLiteCommand("DELETE FROM gamesconfigs WHERE gameid = @gameid");//removeGameConfigs (DONE)
        private SQLiteCommand addGameConfigsQuery = new SQLiteCommand("INSERT INTO gamesconfigs (gameid, configfolder, bios, enableCheats, fromcd, disableHacks, fullboot, nogui) VALUES (@gameid, @configfolder, @bios, @enablecheats, @fromcd, @disablehacks, @fullboot, @nogui)");//addGameConfigs (DONE)
        private SQLiteCommand updateGameConfigsQuery = new SQLiteCommand("UPDATE gamesconfigs SET configfolder = @configfolder, bios = @bios, enablecheats = @enablecheats, fromcd = @fromcd, disablehacks = @disablehacks, fullboot = @fullboot, nogui = @nogui WHERE gameid = @gameid");//updateGameConfigs (DONE)
        /* SQLite Queries: Mixed tables Queries */
        //Needed? Probably not as of now
        #endregion
        #region db extraction to disk
        /* First run only, extract the DB structure into the user folder */
        //NOTE: Make sure the user input is right before executing this cause we will use this as check for first run as well
        public void extractDb()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //foreach (var resourceName in assembly.GetManifestResourceNames())
            //MessageBox.Show(resourceName);

            Stream dbData = Assembly.GetExecutingAssembly().GetManifestResourceStream("YAPCSX2Launcher.Resources.YAPCSX2Launcher.db3");
            FileStream dbOutput = new FileStream(dbLocation, FileMode.Create);
            dbData.CopyTo(dbOutput);
            dbData.Close();
            dbOutput.Close();
        }
        #endregion
        #region dbsetup, init and closing
        /* Sets the connection string based on the user data folder, needs to be called by initConnection()*/
        private void setConnectionString()
        {
            this.sqlConnectionString = string.Format("Data Source={0};Version=3;Compression=True", dbLocation);
        }

        /* Open the SQLite connection to the database */
        private void initConnection()
        {
            this.setConnectionString();
            this.sqlConnection = new SQLiteConnection(this.sqlConnectionString);
            this.sqlConnection.Open();
        }

        /* Closes the connection to the db */
        private void closeConnection()
        {
            this.sqlConnection.Close();
        }
        #endregion
        #region settings
        /* Saves the settings (NOTE: This is used only on the first launch) */
        public bool saveSettings(Configs setData)
        {
            bool status = true;
            this.initConnection();
            this.saveSettingsQuery.Prepare();
            this.saveSettingsQuery.Parameters.AddWithValue("@id", setData.id);
            this.saveSettingsQuery.Parameters.AddWithValue("@pcsx2folder", setData.pcsx2Folder);
            this.saveSettingsQuery.Parameters.AddWithValue("@pcsx2datafolder", setData.pcsx2DataFolder);
            this.saveSettingsQuery.Parameters.AddWithValue("@pcsx2executable", setData.pcsx2Executable);
            this.saveSettingsQuery.Parameters.AddWithValue("@viewmode", setData.viewMode.ToLower());
            this.saveSettingsQuery.Parameters.AddWithValue("@gamepadsupport", setData.gamepadSupport.ToString().ToLower());
            this.saveSettingsQuery.Parameters.AddWithValue("@gamepadokbutton", setData.gamepadOkButton);
            this.saveSettingsQuery.Parameters.AddWithValue("@gamepadcancelbutton", setData.gamepadCancelButton);
            this.saveSettingsQuery.Parameters.AddWithValue("@sorting", setData.sorting.ToUpper());
            this.saveSettingsQuery.Parameters.AddWithValue("@remoteinfo", setData.remoteInfo.ToString().ToLower());
            this.saveSettingsQuery.Parameters.AddWithValue("@ordering", setData.ordering.ToLower());
            this.saveSettingsQuery.Connection = this.sqlConnection;
            try
            {
                this.saveSettingsQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }

        /* Updates the settings */
        public bool updateSettings(Configs setData)
        {
            /*
            pcsx2folder = @pcsx2folder
            pcsx2datafolder = @pcsx2datafolder
            pcsx2executable = @pcsx2executable
            viewmode = @viewmode
            gamepadsupport = @gamepadsupport
            gamepadokbutton = @gamepadokbutton
            gamepadcancelbutton = @gamepadcancelbutton
            sorting = @sorting
            remoteinfo = @remoteinfo
            ordering = @ordering
            */
            bool status = true;
            this.initConnection();
            this.updateSettingsQuery.Prepare();
            this.updateSettingsQuery.Parameters.AddWithValue("@pcsx2folder", setData.pcsx2Folder);
            this.updateSettingsQuery.Parameters.AddWithValue("@pcsx2datafolder", setData.pcsx2DataFolder);
            this.updateSettingsQuery.Parameters.AddWithValue("@pcsx2executable", setData.pcsx2Executable);
            this.updateSettingsQuery.Parameters.AddWithValue("@viewmode", setData.viewMode.ToLower());
            this.updateSettingsQuery.Parameters.AddWithValue("@gamepadsupport",setData.gamepadSupport.ToString().ToLower());
            this.updateSettingsQuery.Parameters.AddWithValue("@gamepadokbutton", setData.gamepadOkButton.ToString());
            this.updateSettingsQuery.Parameters.AddWithValue("@gamepadcancelbutton", setData.gamepadCancelButton.ToString());
            this.updateSettingsQuery.Parameters.AddWithValue("@sorting", setData.sorting.ToUpper());
            this.updateSettingsQuery.Parameters.AddWithValue("@remoteinfo", setData.remoteInfo.ToString().ToLower());
            this.updateSettingsQuery.Parameters.AddWithValue("@ordering", setData.ordering.ToLower());
            this.updateSettingsQuery.Connection = this.sqlConnection;
            try
            {
                this.updateSettingsQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }

        /* Returns the saved settings */
        public DataTable getSettings()
        {
            this.initConnection();
            this.getSettingsQuery.Prepare();
            this.getSettingsQuery.Connection = this.sqlConnection;
            this.sqlDataAdapter = new SQLiteDataAdapter(this.getSettingsQuery);
            this.settingsDataSet.Reset();
            this.sqlDataAdapter.Fill(settingsDataSet);
            settingsDataTable = settingsDataSet.Tables[0];
            settingsDataTableClone = settingsDataTable.Copy();
            /* Close the connection before leaving */
            this.sqlConnection.Close();
            /* Get rid of the dataadapter as well */
            this.sqlDataAdapter.Dispose();
            return settingsDataTable;
        }
        #endregion
        #region games
        /* gets a game from db */
        public Games getGame(int gameId)
        {
            /*
            @id
            */
            this.initConnection();
            Games game = new Games();
            this.getGameQuery.Prepare();
            this.getGameQuery.Parameters.AddWithValue("@id", gameId);
            this.getGameQuery.Connection = this.sqlConnection;
            this.sqlDataAdapter = new SQLiteDataAdapter(this.getGameQuery);
            DataSet gameDataSet = new DataSet();
            gameDataSet.Reset();
            DataTable gameDataTable = new DataTable();
            this.sqlDataAdapter.Fill(gameDataSet);
            gameDataTable = gameDataSet.Tables[0];
            //MessageBox.Show(gameConfigsDataTable.Rows.Count.ToString());
            game.id = int.Parse(gameDataTable.Rows[0]["id"].ToString());
            game.name = gameDataTable.Rows[0]["name"].ToString();
            game.serial = gameDataTable.Rows[0]["serial"].ToString();
            game.location = gameDataTable.Rows[0]["filelocation"].ToString();
            game.region = gameDataTable.Rows[0]["region"].ToString();
            game.cover = (byte[])gameDataTable.Rows[0]["cover"];
            game.compatibility = int.Parse(gameDataTable.Rows[0]["compatibility"].ToString());
            game.timeplayed = int.Parse(gameDataTable.Rows[0]["timeplayed"].ToString());
            this.closeConnection();
            gameDataSet.Dispose();
            gameDataTable.Dispose();
            return game;
        }
        /* Adds a game to the Database */
        public int addGameToDb(Games gameData)
        {
            /*
            @serial
            @name
            @filelocation
            @compatibility
            @region
            @cover
            */
            long lastId = 0;
            this.initConnection();
            this.gameAddQuery.Prepare();
            this.gameAddQuery.Parameters.AddWithValue("@serial", gameData.serial);
            this.gameAddQuery.Parameters.AddWithValue("@name", gameData.name);
            this.gameAddQuery.Parameters.AddWithValue("@filelocation", gameData.location);
            this.gameAddQuery.Parameters.AddWithValue("@compatibility", gameData.compatibility);
            this.gameAddQuery.Parameters.AddWithValue("@region", gameData.region);
            this.gameAddQuery.Parameters.AddWithValue("@cover", gameData.cover);
            this.gameAddQuery.Connection = this.sqlConnection;
            try
            {
                this.gameAddQuery.ExecuteNonQuery();
                lastId = this.sqlConnection.LastInsertRowId;
                //MessageBox.Show(lastId.ToString());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                lastId = 0;
            }
            this.closeConnection();
            return int.Parse(lastId.ToString());
        }

        /* Removes a game from the Database */
        public bool removeGame(int gameId)
        {
            bool status = true;
            this.initConnection();
            this.removeGameQuery.Prepare();
            this.removeGameQuery.Parameters.AddWithValue("@gameid", gameId);
            this.removeGameQuery.Connection = this.sqlConnection;
            /* Before executing this we need to remove both the configurations and the screenshots */
            status = (this.removeAllScreenshots(gameId)) ? this.removeGameConfigs(gameId) : false;
            if (status)
            {
                try
                {
                    this.removeGameQuery.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    status = false;
                }
            }
            return status;
        }

        /* Updates game data on the Database */
        public bool editGame(Games gameData)
        {
            /*
            @serial
            @name
            @filelocation
            @compatibility
            @region
            @cover
            @gameid
            */
        bool status = true;
            this.initConnection();
            this.updateGameData.Prepare();
            this.updateGameData.Parameters.AddWithValue("@serial", gameData.serial);
            this.updateGameData.Parameters.AddWithValue("@name", gameData.name);
            this.updateGameData.Parameters.AddWithValue("@filelocation", gameData.location);
            this.updateGameData.Parameters.AddWithValue("@compatibility", gameData.compatibility);
            this.updateGameData.Parameters.AddWithValue("@region", gameData.region);
            this.updateGameData.Parameters.AddWithValue("@cover", gameData.cover);
            this.updateGameData.Parameters.AddWithValue("@gameid", gameData.id);
            this.updateGameData.Connection = this.sqlConnection;
            try
            {
                this.updateGameData.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            return status;
        }

        /* Gets the gamesDb */
        public DataTable getGameDb()
        {
            /*
            @columnorder
            @orderdirection
            */
            Configs settings = new Configs().getSettings();
            this.initConnection();
            SQLiteCommand getGamesQuery2 = new SQLiteCommand(string.Format(getGamesQuery, "name", "asc"));
            //TODO: Fix, sorting has incorrect values
            //TODO: Add setting for this as it is not implemented at all
            getGamesQuery2.Prepare();
            getGamesQuery2.Connection = this.sqlConnection;
            //string sqlQuery = this.getGamesQuery.ToString();
            this.sqlDataAdapter = new SQLiteDataAdapter(getGamesQuery2);
            this.gamesDataSet.Reset();
            this.sqlDataAdapter.Fill(gamesDataSet);
            gamesDataTable = gamesDataSet.Tables[0];
            gamesDataTableClone = gamesDataTable.Copy();
            /* Close the connection before leaving */
            this.sqlConnection.Close();
            /* Get rid of the dataadapter as well */
            this.sqlDataAdapter.Dispose();
            return gamesDataTable;
        }

        /* Updates Game Cover */
        public bool updateGameCover(int gameId, byte[] cover)
        {
            /*
            @cover
            */
            bool status = true;
            this.initConnection();
            this.updateCoverQuery.Prepare();
            this.updateCoverQuery.Parameters.AddWithValue("@serial", gameId);
            this.updateCoverQuery.Parameters.AddWithValue("@cover", cover);
            this.updateCoverQuery.Connection = this.sqlConnection;
            try
            {
                this.updateCoverQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }

        /* Updates the played time of a game
        ** INPUT: int gameId (the id of the game that needs to be updated, int playtimeSeconds (the seconds to add to the played time)
        ** OUTPUT: bool status (success or fail)
        */
        public bool updateGamePlayTime(int gameId, int playtimeSeconds)
        {
            /* OPEN CONNECTION */
            this.initConnection();
            bool status = true;
            this.updatePlayTimeQuery.Prepare();
            this.updatePlayTimeQuery.Parameters.AddWithValue("@timeplayed", playtimeSeconds);
            this.updatePlayTimeQuery.Parameters.AddWithValue("@gameid", gameId);
            this.updatePlayTimeQuery.Connection = this.sqlConnection;
            try
            {
                this.updatePlayTimeQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
                status = false;
            }
            /* Close connection*/
            this.closeConnection();
            return status;
        }
        #endregion
        #region screenshots
        /* Adds a screenshot to the Database */
        public bool addScreenshot(Screenshot screenshotData)
        {
            /*
            @gameid
            @screenshot
            */
            bool status = true;
            this.initConnection();
            this.addScreenshotQuery.Prepare();
            this.addScreenshotQuery.Parameters.AddWithValue("@gameid", screenshotData.gameid);
            this.addScreenshotQuery.Parameters.AddWithValue("@name", screenshotData.screenshot);
            this.addScreenshotQuery.Connection = this.sqlConnection;
            try
            {
                this.addScreenshotQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }

        /* Gets the screenshots of the choosen game */
        public DataTable getGameScreenshots(int gameId)
        {
            /*
            @gameid
            */
            this.initConnection();
            this.getScreenshotsQuery.Prepare();
            this.getScreenshotsQuery.Parameters.AddWithValue("@gameid", gameId);
            this.getScreenshotsQuery.Connection = this.sqlConnection;
            //string sqlQuery = this.getScreenshotsQuery.ToString();
            this.sqlDataAdapter = new SQLiteDataAdapter(this.getScreenshotsQuery);
            this.screenshotsDataSet.Reset();
            this.sqlDataAdapter.Fill(screenshotsDataSet);
            screenshotsDataTable = screenshotsDataSet.Tables[0];
            screenshotsDataTableClone = screenshotsDataTable.Copy();
            /* Close the connection before leaving */
            this.sqlConnection.Close();
            /* Get rid of the dataadapter as well */
            this.sqlDataAdapter.Dispose();
            return screenshotsDataTable;
        }
        
        /* Gets a single screenshot from the Database */
        public Screenshot getSingleScreenshot(int screenshotId)
        {
            /*
            @screenshotid
            */
            this.initConnection();
            this.getSingleScreenshotQuery.Prepare();
            this.getSingleScreenshotQuery.Parameters.AddWithValue("@screenshotid", screenshotId);
            this.getSingleScreenshotQuery.Connection = this.sqlConnection;
            //string sqlQuery = this.getSingleScreenshotQuery.ToString();
            this.sqlDataAdapter = new SQLiteDataAdapter(this.getSingleScreenshotQuery);
            DataSet singleScreenshotDataSet = new DataSet();
            singleScreenshotDataSet.Reset();
            DataTable singleScreenshotDataTable = new DataTable();
            this.sqlDataAdapter.Fill(singleScreenshotDataSet);
            singleScreenshotDataTable = singleScreenshotDataSet.Tables[0];
            Screenshot screenshot = new Screenshot();
            screenshot.id = int.Parse(singleScreenshotDataTable.Rows[0]["id"].ToString());
            screenshot.gameid = int.Parse(singleScreenshotDataTable.Rows[0]["gameid"].ToString());
            screenshot.screenshot = (byte[])singleScreenshotDataTable.Rows[0]["screenshot"];
            this.closeConnection();
            /* Get rid of all the stuff left behind */
            singleScreenshotDataSet.Dispose();
            singleScreenshotDataTable.Dispose();
            return screenshot;
        }

        /* Removes a single screenshot based on it's id */
        public bool removeScreenShot(int screenshotId)
        {
            bool status = true;
            this.initConnection();
            this.removeScreenshotQuery.Prepare();
            this.removeScreenshotQuery.Parameters.AddWithValue("@screenshotid", screenshotId);
            this.removeScreenshotQuery.Connection = this.sqlConnection;
            try
            {
                this.removeScreenshotQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
                status = false;
            }
            //Call a db optimization
            this.optimizeDbTable("screenshots");
            this.closeConnection();
            return status;
        }

        /* Remove all the screenshots where the gameid matches the given one */
        public bool removeAllScreenshots(int gameId)
        {
            bool status = true;
            this.initConnection();
            this.removeAllScreenshotsQuery.Prepare();
            this.removeAllScreenshotsQuery.Parameters.AddWithValue("@gameid", gameId);
            this.removeAllScreenshotsQuery.Connection = this.sqlConnection;
            try
            {
                this.removeAllScreenshotsQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            //Call a db optimization
            this.optimizeDbTable("screenshots");
            this.closeConnection();
            return status;
        }
        #endregion
        #region gamesconfigs
        /* get the configurations for a game from the Database */
        public GamesConfigs getGameConfigs(int gameId)
        {
            //MessageBox.Show(gameId.ToString());
            /* @gameid */
            GamesConfigs gameConfigs = new GamesConfigs();
            this.initConnection();
            this.getGameConfigsQuery.Prepare();
            this.getGameConfigsQuery.Parameters.AddWithValue("@gameid", gameId);
            this.getGameConfigsQuery.Connection = this.sqlConnection;
            this.sqlDataAdapter = new SQLiteDataAdapter(this.getGameConfigsQuery);
            //string sqlQuery = this.getGameConfigsQuery.ToString();
            //this.sqlDataAdapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            DataSet gameConfigsDataSet = new DataSet();
            gameConfigsDataSet.Reset();
            DataTable gameConfigsDataTable = new DataTable();
            this.sqlDataAdapter.Fill(gameConfigsDataSet);
            gameConfigsDataTable = gameConfigsDataSet.Tables[0];
            //MessageBox.Show(gameConfigsDataTable.Rows.Count.ToString());
            gameConfigs.id = int.Parse(gameConfigsDataTable.Rows[0]["id"].ToString());
            gameConfigs.gameId = int.Parse(gameConfigsDataTable.Rows[0]["gameid"].ToString());
            gameConfigs.configFolder = gameConfigsDataTable.Rows[0]["configfolder"].ToString();
            gameConfigs.bios = gameConfigsDataTable.Rows[0]["bios"].ToString();
            gameConfigs.enableCheats = bool.Parse(gameConfigsDataTable.Rows[0]["enablecheats"].ToString());
            gameConfigs.fromcd = bool.Parse(gameConfigsDataTable.Rows[0]["fromcd"].ToString());
            gameConfigs.disableHacks = bool.Parse(gameConfigsDataTable.Rows[0]["disablehacks"].ToString());
            gameConfigs.fullboot = bool.Parse(gameConfigsDataTable.Rows[0]["fullboot"].ToString());
            gameConfigs.nogui = bool.Parse(gameConfigsDataTable.Rows[0]["nogui"].ToString());
            this.closeConnection();
            gameConfigsDataSet.Dispose();
            gameConfigsDataTable.Dispose();
            return gameConfigs;
        }

        /* Removes configurations for a game from the Database */
        public bool removeGameConfigs(int gameId)
        {
            /* @gameid */
            bool status = true;
            this.initConnection();
            this.removeGameConfigsQuery.Prepare();
            this.removeGameConfigsQuery.Parameters.AddWithValue("@gameid", gameId);
            this.removeGameConfigsQuery.Connection = this.sqlConnection;
            try
            {
                this.removeGameConfigsQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }

        /* Adds Configurations for a game to the Database */
        public bool addGameConfigs(GamesConfigs configsData)
        {
            /*
            @gameid
            @configfolder
            @bios
            @enablecheats
            @fromcd
            @disablehacks
            @fullboot
            @nogui
            */
            bool status = true;
            this.initConnection();
            this.addGameConfigsQuery.Prepare();
            this.addGameConfigsQuery.Parameters.AddWithValue("@gameid", configsData.gameId);
            this.addGameConfigsQuery.Parameters.AddWithValue("@configfolder", configsData.configFolder);
            this.addGameConfigsQuery.Parameters.AddWithValue("@bios", configsData.bios);
            this.addGameConfigsQuery.Parameters.AddWithValue("@enablecheats", configsData.enableCheats.ToString().ToLower());
            this.addGameConfigsQuery.Parameters.AddWithValue("@fromcd", configsData.fromcd.ToString().ToLower());
            this.addGameConfigsQuery.Parameters.AddWithValue("@disablehacks", configsData.disableHacks.ToString().ToLower());
            this.addGameConfigsQuery.Parameters.AddWithValue("@fullboot", configsData.fullboot.ToString().ToLower());
            this.addGameConfigsQuery.Parameters.AddWithValue("@nogui", configsData.nogui.ToString().ToLower());
            this.addGameConfigsQuery.Connection = this.sqlConnection;
            try
            {
                this.addGameConfigsQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }

        /* Updates Configurations in the Database for a Game */
        public bool updateGameConfigs(GamesConfigs configsData)
        {
            /*
            @configfolder
            @bios
            @enablecheats
            @fromcd
            @disablehacks
            @fullboot
            @nogui
            @gameid
            */
            bool status = true;
            this.initConnection();
            this.updateGameConfigsQuery.Prepare();
            this.updateGameConfigsQuery.Parameters.AddWithValue("@configfolder", configsData.configFolder);
            this.updateGameConfigsQuery.Parameters.AddWithValue("@bios", configsData.bios);
            this.updateGameConfigsQuery.Parameters.AddWithValue("@enablecheats", configsData.enableCheats.ToString().ToLower());
            this.updateGameConfigsQuery.Parameters.AddWithValue("@fromcd", configsData.fromcd.ToString().ToLower());
            this.updateGameConfigsQuery.Parameters.AddWithValue("@disablehacks", configsData.disableHacks.ToString().ToLower());
            this.updateGameConfigsQuery.Parameters.AddWithValue("@fullboot", configsData.fullboot.ToString().ToLower());
            this.updateGameConfigsQuery.Parameters.AddWithValue("@nogui", configsData.nogui.ToString().ToLower());
            this.updateGameConfigsQuery.Parameters.AddWithValue("@gameid", configsData.gameId);
            this.updateGameConfigsQuery.Connection = this.sqlConnection;
            try
            {
                this.updateGameConfigsQuery.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                status = false;
            }
            this.closeConnection();
            return status;
        }
        #endregion
        #region db optimisation
        private void optimizeDbTable(string tableName)
        {
            this.initConnection();
            this.cleanTableQuery.Prepare();
            this.cleanTableQuery.Parameters.AddWithValue("@tablename", tableName);
            this.cleanTableQuery.Connection = this.sqlConnection;
            this.cleanTableQuery.ExecuteNonQuery();
            this.closeConnection();
        }

        private void optimizeWholeDb()
        {
            this.initConnection();
            this.cleanDbQuery.Prepare();
            this.cleanDbQuery.Connection = this.sqlConnection;
            this.cleanDbQuery.ExecuteNonQuery();
            this.closeConnection();
        }
        #endregion
    }
}