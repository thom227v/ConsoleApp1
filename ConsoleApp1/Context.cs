using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Context
    {
        // findes yatzy directory
        public static string GetYatzyDataDirectory()
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Yatzy");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        // dice data
        public static List<int> ReadCurrentDiceValues()
        {
            string dir = GetYatzyDataDirectory();
            string path = Path.Combine(dir, "CurrentDice.txt");
            if (!File.Exists(path))
                return new List<int>();
            string data = File.ReadAllText(path);
            List<int> diceValues = data.Split('\n')
                .Where(x => !string.IsNullOrEmpty(x) && !x.StartsWith("#"))
                .ToList().ConvertAll(int.Parse);
            return diceValues;
        }

        public static void WriteToCurrentDiceValues(List<int> dice)
        {
            string dir = GetYatzyDataDirectory();
            string filePath = Path.Combine(dir, "CurrentDice.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int die in dice)
                {
                    writer.WriteLine(die);
                }
            }
        }

        // leaderboard data
        public static Leaderboard ReadCurrentLeaderboardValues()
        {
            string dir = GetYatzyDataDirectory();
            string path = Path.Combine(dir, "Leaderboard.json");
            if (!File.Exists(path))
                return new Leaderboard();
            string data = File.ReadAllText(path);
            Leaderboard leaderboard = JsonSerializer.Deserialize<Leaderboard>(data);
            return leaderboard;
        }

        public static void WriteCurrentLeaderboardValues(Leaderboard leaderboard)
        {
            string dir = GetYatzyDataDirectory();
            string filePath = Path.Combine(dir, "Leaderboard.json");
            string json = JsonSerializer.Serialize(leaderboard);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(json);
            }
        }

        // gamestate data
        public static string GetGameFilePath(int gameId)
        {
            string dir = GetYatzyDataDirectory();
            return Path.Combine(dir, $"game_{gameId}.json");
        }


        public static void SaveGameState(GameState gameState)
        {
            string path = GetGameFilePath(gameState.game_id);
            string json = JsonSerializer.Serialize(gameState, new JsonSerializerOptions { WriteIndented = true });
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(json);
            }
        }


        // load gamestate or creates new gamestate
        public static GameState LoadGameState(int gameId)
        {
            string path = GetGameFilePath(gameId);
            if (!File.Exists(path)) return null;
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<GameState>(json);
            }
        }

        public static void ExportLeaderboardToCsv(GameState gameState)
        {
            string dir = GetYatzyDataDirectory();
            string csvPath = Path.Combine(dir, "leaderboard.csv");
            bool writeHeader = !File.Exists(csvPath); // if leaderboard csv does not exist, false
            using (var writer = new StreamWriter(csvPath, append: true)) // write leaderboard.json data to csv
            {
                if (writeHeader)
                    writer.WriteLine("game_id,date,player_id,player_name,totalScore");
                foreach (var player in gameState.players)
                {
                    writer.WriteLine($"{gameState.game_id},{gameState.date},{player.id},{player.name.Replace(" ", "")},{player.totalScore}");
                }
            }
        }


    }
}
