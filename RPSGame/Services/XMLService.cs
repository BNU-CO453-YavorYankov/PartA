using RPSGame.Services.Models;
using System;
using System.IO;
using System.Xml;

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
        private const string ROUNDS_WON_NODE = "rounds_won";
        private const string RESULT_NODE = "result";

        private string _dataFolderPath;

        public XMLService()
        {
            this._dataFolderPath = Path.GetFullPath($"{Environment.CurrentDirectory}/Data");
        }

        public void WriteXMLFile(GameStatServiceModel model)
        {
            var xmlFile = $"{this._dataFolderPath}/games_stat.xml";

            XmlDocument doc = new XmlDocument();

            if (File.Exists(xmlFile))
            {
                doc.Load(xmlFile);

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

            doc.Save(xmlFile);
        }
    }
}
