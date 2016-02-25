using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libraries to read and write XML
using System.Xml;
//Might be needed in the future
//using System.IO;
//Uncomment for debug (enables messageboxes)
//using System.Windows.Forms;

namespace YAPCSX2Launcher.Utilities.XMLManager
{
    class XMLManager
    {
        public void XMLWriteWizzardConfig(string[] xmlValues, string xmlFile)
        {
            XmlWriterSettings XMLWriterSettings = new XmlWriterSettings();
            XMLWriterSettings.Indent = true;
            XMLWriterSettings.IndentChars = "\t";
            XmlWriter XMLWriter = XmlWriter.Create(xmlFile, XMLWriterSettings);
            XMLWriter.WriteStartDocument();
            XMLWriter.WriteStartElement("settings");

            /* Folders */
            XMLWriter.WriteStartElement("conf");

            XMLWriter.WriteAttributeString("name", "PCSX2Folder");
            XMLWriter.WriteString(xmlValues[0]);
            XMLWriter.WriteEndElement();
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "PCSX2DataFolder");
            XMLWriter.WriteString(xmlValues[1]);
            XMLWriter.WriteEndElement();
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "PCSX2Executable");
            XMLWriter.WriteString(xmlValues[2]);
            XMLWriter.WriteEndElement();

            /* Default Settings */
            /* View Mode */
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "viewmode");
            XMLWriter.WriteString("list"); //values: list || grid || TV
            XMLWriter.WriteEndElement();
            /* Sorting */
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "sorting");
            XMLWriter.WriteString("alphabetical"); //values: alphabetical || serial
            XMLWriter.WriteEndElement();
            /* Remote info retrieve (DEFAULTS TO FALSE DUE TO POSSIBLE BANS */
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "remoteinfo");
            XMLWriter.WriteString("false"); //values: true || false
            XMLWriter.WriteEndElement();
            /* Controler support (late implementation) */
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "controlersupport");
            XMLWriter.WriteString("false"); //values: true || false
            XMLWriter.WriteEndElement();
            /* Controler support ok button */
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "controlersupportokbutton");
            XMLWriter.WriteString("1"); //values: button number
            XMLWriter.WriteEndElement();
            /* Controller support cancel button */
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "controllersupportcancelbutton");
            XMLWriter.WriteString("0"); //values: button number
            XMLWriter.WriteEndElement();

            //Complete the writing
            XMLWriter.WriteEndDocument();
            XMLWriter.Close();
            return;
        }

        public void XMLWriteConfig(Dictionary<string, string> xmlValues)
        {
            XmlWriterSettings XMLWriterSettings = new XmlWriterSettings();
            XMLWriterSettings.Indent = true;
            XMLWriterSettings.IndentChars = "\t";
            string configFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\YAPCSX2Launcher\\config.xml";
            XmlWriter XMLWriter = XmlWriter.Create(configFile, XMLWriterSettings);
            XMLWriter.WriteStartDocument();
            XMLWriter.WriteStartElement("settings");

            //TODO: Finish
            return;
        }

        public Dictionary<string, string> XMLLoadConfig()
        {
            string configFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\YAPCSX2Launcher\\config.xml";
            //Create a 2 dimensions array to fill with the settings
            Dictionary<string, string> settingsArray = new Dictionary<string, string>();

            XmlTextReader reader = new XmlTextReader(configFile);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "conf")
                {
                    //TODO: as of now settings only have 1 attribute so it's not prone to bug out, but in the future?
                    reader.MoveToNextAttribute();
                    //MessageBox.Show(reader.Value);
                    //MessageBox.Show(reader.ReadString());
                    settingsArray.Add(reader.Value, reader.ReadString());
                }
            }
            reader.Close();
            return settingsArray;
        }

        public Dictionary<string, string[]> XMLLoadGames(string xmlFile)
        {
            //TODO
            return null; /* C# likes to complain about no returning values */
        }

        public void XMLSaveGames(string[] gameData, string xmlFile)
        {
            XmlWriterSettings XMLWriterSettings = new XmlWriterSettings();
            XMLWriterSettings.Indent = true;
            XMLWriterSettings.IndentChars = "\t";
            XmlWriter XMLWriter = XmlWriter.Create(xmlFile, XMLWriterSettings);
            XMLWriter.Settings.Indent = true;
            XMLWriter.WriteStartDocument();
            XMLWriter.WriteStartElement("games");
            //serial
            XMLWriter.WriteStartElement("serial");
            XMLWriter.WriteString(gameData[0]);
            XMLWriter.WriteEndElement();
            //name
            XMLWriter.WriteStartElement("name");
            XMLWriter.WriteString(gameData[1]);
            XMLWriter.WriteEndElement();
            //region
            XMLWriter.WriteStartElement("region");
            XMLWriter.WriteString(gameData[2]);
            XMLWriter.WriteEndElement();
            //compatibility
            XMLWriter.WriteStartElement("compatibility");
            XMLWriter.WriteString(gameData[3]);
            XMLWriter.WriteEndElement();
            //location
            XMLWriter.WriteStartElement("location");
            XMLWriter.WriteString(gameData[4]);
            XMLWriter.WriteEndElement();
            //score
            XMLWriter.WriteStartElement("score");
            XMLWriter.WriteString(gameData[5]);
            XMLWriter.WriteEndElement();
            //description
            XMLWriter.WriteStartElement("description");
            XMLWriter.WriteString(gameData[6]);
            XMLWriter.WriteEndElement();
            //release
            XMLWriter.WriteStartElement("release");
            XMLWriter.WriteString(gameData[7]);
            XMLWriter.WriteEndElement();
            //publisher
            XMLWriter.WriteStartElement("publisher");
            XMLWriter.WriteString(gameData[8]);
            XMLWriter.WriteEndElement();
            //cover image
            XMLWriter.WriteStartElement("cover");
            XMLWriter.WriteString(gameData[9]);
            XMLWriter.WriteEndElement();
            //Screenshots
            XMLWriter.WriteStartElement("screenshots");
            XMLWriter.WriteString(gameData[10]);
            XMLWriter.WriteEndElement();

            //Close "games" element
            XMLWriter.WriteEndElement();
            //Close Document
            XMLWriter.WriteEndDocument();
            XMLWriter.Close();
            return;
        }
    }

}
