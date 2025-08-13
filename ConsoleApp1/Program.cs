using ConsoleApp1.Models;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter game number to resume or start (example: 1 for game_1):");
            string gameInput = Console.ReadLine();
            int gameId = 1;

            if (!int.TryParse(gameInput, out gameId)) // default to game 1 if input is invalid
            {
                Console.WriteLine("Invalid input, using game 1.");
                gameId = 1;
            }

            GameState gameState = Context.LoadGameState(gameId);

            if (gameState == null) // creates new gameState if LoadGameState returns null
            {
                gameState = new GameState
                {
                    game_id = gameId,
                    date = DateTime.Now.ToString("yyyy-MM-dd"),
                    players = new List<PlayerState>()
                };

                Console.WriteLine("How many players? (2-8):");
                int numPlayers = 2;

                if (!int.TryParse(Console.ReadLine(), out numPlayers) || numPlayers < 2 || numPlayers > 8) // default to 2 players if input is invalid
                {
                    Console.WriteLine("Invalid input, 2 players game");
                    numPlayers = 2;
                }

                for (int i = 1; i <= numPlayers; i++)
                {
                    Console.Write($"Enter name for player {i}: ");
                    string name = Console.ReadLine();
                    gameState.players.Add(new PlayerState { id = $"p{i:00}", name = name });
                }
                Context.SaveGameState(gameState);
            }
            else
            {
                Console.WriteLine($"Loaded game {gameId} from {gameState.date} with {gameState.players.Count} players."); // 'display information about game if loaded
            }

            Console.WriteLine("Press 1 for Yatzy, 2 for reset leaderboard, 3 for calculating leaderboard score, 4 for export leaderboard");
            switch (Console.ReadLine())
            {
                case "1":
                    Yatzy.PlayYatzy(gameState);
                    break;
                case "2":
                    Yatzy.ResetLeaderboard();
                    Console.WriteLine("Leaderboard has been reset.");
                    return;
                case "3":
                    Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
                    Console.WriteLine(leaderboard.TotalScore);
                    return;
                case "4":
                    ExportLeaderboardToCsv(gameState);
                    Console.WriteLine("Leaderboard exported to leaderboard.csv");
                    return;
                default:
                    Console.WriteLine("Invalid input, exiting...");
                    Thread.Sleep(2000);
                    return;
            }
        }

        public static void ExportLeaderboardToCsv(GameState gameState)
        {
            string dir = Context.GetYatzyDataDirectory();
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

        static double AddAndMultiply(int first, int second, int third)
        {
            return (first + second) * third;
        }

        static string CtoF(double celsius)
        {
            double fah = (celsius * 9 / 5) + 32;

            if (celsius < -271.15)
            {
                return "Temperature below absolute zero!";
            }

            return $"T = {celsius}F";
        }

        static string ElementaryOperations(int first, int second)
        {
            string result = string.Empty;
            result += $"{first + second}, ";
            result += $"{first - second}, ";
            result += $"{first * second}, ";
            result += $"{(double)first / second}";

            return result;
        }

        static bool IsResultTheSame(int a, int b)
        {
            if (a == b)
            {
                return true;
            }

            return false;
        }

        static int ModuloOperations(int first, int second, int third)
        {
            return (first % second) % third;
        }

        static double CubeOf(double num)
        {
            return num * num * num;
        }

        static string SwapTwoNumbers(double first, double second)
        {
            double[] tempArr = { first, second };

            Array.Reverse(tempArr);

            return tempArr[0].ToString() + tempArr[1].ToString();
        }

        static int AbsoluteValue(int num)
        {
            return Math.Abs(num);
        }

        static int DivisibleBy2Or3(int first, int second)
        {
            if ((first / 3 == 0 || first / 2 == 0) && (second / 3 == 0 || second / 2 == 0))
            {
                return first * second;
            }

            return first + second;
        }

        static bool IfConsistsOfUppercaseLetters(string text)
        {
            return text.All(char.IsUpper);
        }

        static bool IfGreaterThanThirdOne(int[] arr)
        {
            if ((arr[0] * arr[1]) < arr[2])
            {
                return false;
            }

            return true;
        }

        static bool IfNumberIsEven(int num)
        {
            return int.IsEvenInteger(num);
        }

        static bool IfSortedAscending(int[] arr)
        {
            int[] tempArr = arr.OrderBy(n => n).ToArray();

            if (tempArr == arr)
            {
                return true;
            }

            return false;
        }

        static string PositiveNegativeOrZero(double num)
        {
            if (double.IsNegative(num))
            {
                return "negative";
            }
            else if (num == 0)
            {
                return "zero";
            }

            return "positive";
        }

        static bool IfYearIsLeap(int year)
        {
            if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }

        static string NumberTable()
        {
            return "\r\n1\t2\t3\t4\t5\t6\t7\t8\t9\t10\r\n2\t4\t6\t8\t10\t12\t14\t16\t18\t20\r\n3\t6\t9\t12\t15\t18\t21\t24\t27\t30\r\n4\t8\t12\t16\t20\t24\t28\t32\t36\t40\r\n5\t10\t15\t20\t25\t30\t35\t40\t45\t50\r\n6\t12\t18\t24\t30\t36\t42\t48\t54\t60\r\n7\t14\t21\t28\t35\t42\t49\t56\t63\t70\r\n8\t16\t24\t32\t40\t48\t56\t64\t72\t80\r\n9\t18\t27\t36\t45\t54\t63\t72\t81\t90\r\n10\t20\t30\t40\t50\t60\t70\t80\t90\t100\r\n";
        }

    }
}