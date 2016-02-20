using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libraries to read and write XML
using System.Xml;
using System.IO;
//Dictionary for settings
//using System.Windows.Forms;

namespace YAPCSX2Launcher.Utilities.XMLManager
{
    class XMLManager
    {
        public void XMLWriteWizzardConfig(string[] xmlValues, string xmlFile)
        {
            XmlWriter XMLWriter = XmlWriter.Create(xmlFile);
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
            XMLWriter.WriteStartElement("conf");
            XMLWriter.WriteAttributeString("name", "viewmode");
            XMLWriter.WriteString("list"); //values: list || grid
            XMLWriter.WriteEndElement();

            //Complete the writing
            XMLWriter.WriteEndDocument();
            XMLWriter.Close();
            return;
        }

        public void XMLWriteConfig(Dictionary<string,string> xmlValues, string xmlFile)
        {
            XmlWriter XMLWriter = XmlWriter.Create(xmlFile);
            XMLWriter.WriteStartDocument();
            XMLWriter.WriteStartElement("settings");

            //TODO: Finish
            return;
        }

        public Dictionary<string,string> XMLLoadConfig(string xmlFile)
        {
            //Create a 2 dimensions array to fill with the settings
            Dictionary<string, string> settingsArray = new Dictionary<string, string>();

            XmlTextReader reader = new XmlTextReader(xmlFile);
            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element && reader.Name == "conf")
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
    }
}
