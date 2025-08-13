using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Context
    {
        public static string[] GetDataDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return Directory.GetDirectories(currentDirectory);
        }

        public static string ReadDataFolder()
        {
            string[] currentDirectory = GetDataDirectory();

            foreach (string dir in currentDirectory)
            {
                if (dir.Contains("Data"))
                {
                    return Path.Combine(dir, "Data");

                }
            }
            return "Error finding diretory";
        }


        public static List<int> ReadCurrentDiceValues()
        {
            string[] currentDirectory = GetDataDirectory();
            string data = "";

            foreach (string dir in currentDirectory)
            {
                if (dir.Contains("Yatzy"))
                {
                    string path = Path.Combine(dir, "CurrentDice.txt");

                    using (StreamReader sr = new StreamReader(path))
                    {
                        data = sr.ReadToEnd();
                    }
                }
            }

            List<int> diceValues = data.Split('\n')
                .Where(x => !string.IsNullOrEmpty(x) && !x.StartsWith("#"))
                .ToList().ConvertAll(int.Parse);
            //List<string> diceValues = data.Split('\n').Skip(1).ToList();
            //List<int> fixedList = diceValues.Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList().ConvertAll(int.Parse);
            return diceValues;
        }

        public static Leaderboard ReadCurrentLeaderboardValues()
        {
            string[] currentDirectory = GetDataDirectory();
            string data = "";

            foreach (string dir in currentDirectory)
            {
                if (dir.Contains("Yatzy"))
                {
                    string path = Path.Combine(dir, "Leaderboard.json");
                    using (StreamReader sr = new StreamReader(path))
                    {
                        data = sr.ReadToEnd();
                    }
                }
            }
            Leaderboard leaderboard = JsonSerializer.Deserialize<Leaderboard>(data);
            return leaderboard;
        }

        public static void WriteCurrentLeaderboardValues(Leaderboard leaderboard)
        {
            string[] currentDirectory = GetDataDirectory();
            foreach (string dir in currentDirectory)
            {
                if (dir.Contains("Yatzy"))
                {
                    string filePath = Path.Combine(dir, "Leaderboard.json");
                    string json = JsonSerializer.Serialize(leaderboard);
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(json);
                    }
                }
            }
        }

        public static void WriteToCurrentDiceValues(List<int> dice)
        {
            string[] currentDirectory = GetDataDirectory();
            foreach (string dir in currentDirectory)
            {
                if (dir.Contains("Yatzy"))
                {
                    string filePath = Path.Combine(dir, "CurrentDice.txt");
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        //writer.WriteLine(dice.Count());
                        foreach (int die in dice)
                        {
                            writer.WriteLine(die);
                        }
                    }
                }
            }
        }

        public static int GetCurrentDiceAmount()
        {
            string[] currentDirectory = GetDataDirectory();
            string line = "";
            foreach (string dir in currentDirectory)
            {
                if (dir.Contains("Yatzy"))
                {

                    string path = Path.Combine(dir, "CurrentDice.txt");
                    using (StreamReader sr = new StreamReader(path))
                    {
                        line = sr.ReadLine();
                    }
                }
            }
            return Convert.ToInt32(line);
        }
    }
}
