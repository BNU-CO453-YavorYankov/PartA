using RPSGame.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RPSGame.Services
{
    /// <summary>
    /// XML service read and write xml file where 
    /// players` stat is stored.
    /// </summary>
    public class XMLService
    {
        private const string GAMES_STAT_NODE = "games_stat";
        private const string GAME_NODE = "game";
        private const string PLAYER_NAME_NODE = "player_name";
        private const string RESULT_NODE = "result";

        /// <summary>
        /// Full path to Data folder.
        /// </summary>
        private string _dataFolderPath;
        private string _xmlFile;
        public XMLService()
        {
            this._dataFolderPath = Path.GetFullPath($"{Environment.CurrentDirectory}/Data");
            this._xmlFile = $"{this._dataFolderPath}\\games_stat.xml";
        }

        /// <summary>
        /// Create new XML with game stat if there is no existing
        /// </summary>
        /// <param name="model">last game stat</param>
        public void WriteXMLFile(GameStatServiceModel model)
        {
            XmlDocument doc = new XmlDocument();

            if (File.Exists(this._xmlFile))
            {
                doc.Load(this._xmlFile);

                // <game>
                XmlElement gameElement = doc.CreateElement(string.Empty, GAME_NODE, string.Empty);
                doc.DocumentElement.AppendChild(gameElement);

                // <player_name>{player name as text}</player_name>
                XmlElement playerNameElement = doc.CreateElement(string.Empty, PLAYER_NAME_NODE, string.Empty);
                XmlText playerNameAsText = doc.CreateTextNode(model.PlayerName);
                playerNameElement.AppendChild(playerNameAsText);
                gameElement.AppendChild(playerNameElement);

                // <result>{result can be win/lose/draw}</result>
                XmlElement resultElement = doc.CreateElement(string.Empty, RESULT_NODE, string.Empty);
                XmlText resultAsText = doc.CreateTextNode(model.Result);
                resultElement.AppendChild(resultAsText);
                gameElement.AppendChild(resultElement);
            }
            else
            {
                // <games_stat>
                XmlElement gamesStatElement = doc.CreateElement(string.Empty, GAMES_STAT_NODE, string.Empty);
                doc.AppendChild(gamesStatElement);

                // <game>
                XmlElement gameElement = doc.CreateElement(string.Empty, GAME_NODE, string.Empty);
                gamesStatElement.AppendChild(gameElement);

                // <player_name>{player name as text}</player_name>
                XmlElement playerNameElement = doc.CreateElement(string.Empty, PLAYER_NAME_NODE, string.Empty);
                XmlText playerNameAsText = doc.CreateTextNode(model.PlayerName);
                playerNameElement.AppendChild(playerNameAsText);
                gameElement.AppendChild(playerNameElement);

                // <result>{result can be win/lose/draw}</result>
                XmlElement resultElement = doc.CreateElement(string.Empty, RESULT_NODE, string.Empty);
                XmlText resultAsText = doc.CreateTextNode(model.Result);
                resultElement.AppendChild(resultAsText);
                gameElement.AppendChild(resultElement);
            }

            doc.Save(this._xmlFile);
        }

        /// <summary>
        /// Load the XML file if there is so,
        /// select game elements,
        /// then go through each game element and 
        /// add new key value pair from its data.
        /// </summary>
        public List<KeyValuePair<string, string>> ReadXML()
        {
            // Due to a dictionary cannot has duplicate keys, 
            // we use list of type key value pair 
            var results = new List<KeyValuePair<string, string>>();

            if (File.Exists(this._xmlFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this._xmlFile);

                var xmlList = doc.SelectNodes("/games_stat/game");
                foreach (XmlNode game in xmlList)
                {
                    string player_name = game["player_name"].InnerText;
                    string result = game["result"].InnerText;

                    results.Add(
                        new KeyValuePair<string, string>(player_name, result));
                }
            }

            return results;
        }
    }
}
