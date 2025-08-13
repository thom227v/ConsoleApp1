using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    public class Yatzy
    {
        public static void PlayYatzy()
        {
            Die die = new Die();
            int rollsLeft = 6;
            for (int i = 0; i < rollsLeft; i++)
            {
                DisplayDice();
                List<int> list = MatchWhichDicesToRemove();
                die.DiceToRoll(list.Count(), list);
            }
        }

        static List<int> MatchWhichDicesToRemove()
        {
            List<int> dice = Context.ReadCurrentDiceValues();
            bool gameChoiceState = true;
            int[] inputNumbers = new int[0];
            do
            {
                Console.WriteLine("Which dice do you want to remove? (1-5), type stop to choose something to do");
                string input = Console.ReadLine();
                if (input.ToLower() == "stop")
                {
                    GameChoosing(dice);
                }

                try
                {
                    inputNumbers = input.Split(' ', ',').Select(int.Parse).ToArray();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Can only enter numbers with space between");
                }

                int subtractAmount = 1;

                foreach (int inputValue in inputNumbers)
                {
                    try
                    {
                        dice.RemoveAt(inputValue - subtractAmount);
                        subtractAmount++;
                        gameChoiceState = false;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Die does not exist");
                    }
                }
            }
            while (gameChoiceState);

            return dice;
        }

        public static void DisplayDice()
        {
            List<int> dice = Context.ReadCurrentDiceValues();
            Console.WriteLine("Your current dices");
            foreach (int currentDie in dice)
            {
                Console.WriteLine(currentDie);
            }
        }

        public static void GameChoosing(List<int> dice)
        {
            Console.WriteLine("What do you choose?");
            Console.WriteLine("""
                1 for 1's
                2 for 2's
                3 for 3's
                4 for 4's
                5 for 5's
                6 for 6's
                7 for 1 pair
                8 for 2 pair
                9 for three of a kind
                10 for four of a kind
                11 for small straight
                12 for big straight
                13 for house
                14 for chance 
                15 for YATZY
                """);

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Which type of die number should be inserted?");
                    MatchTypes(1, dice, (leaderboard, score) => leaderboard.Ones = score);
                    return;
                case "2":
                    Console.WriteLine("Which type of die number should be inserted?");
                    MatchTypes(2, dice, (leaderboard, score) => leaderboard.Twos = score);
                    return;
                case "3":
                    Console.WriteLine("Which type of die number should be inserted?");
                    MatchTypes(3, dice, (leaderboard, score) => leaderboard.Threes = score);
                    return;
                case "4":
                    Console.WriteLine("Which type of die number should be inserted?");
                    MatchTypes(4, dice, (leaderboard, score) => leaderboard.Fours = score);
                    return;
                case "5":
                    Console.WriteLine("Which type of die number should be inserted?");
                    MatchTypes(5, dice, (leaderboard, score) => leaderboard.Fives = score);
                    return;
                case "6":
                    Console.WriteLine("Which type of die number should be inserted?");
                    MatchTypes(6, dice, (leaderboard, score) => leaderboard.Sixes = score);
                    return;
                case "7":
                    MatchPairs(dice);
                    return;
                case "8":
                    MatchTwoPairs(dice);
                    return;
                case "9":
                    MatchThreeOfAKind(dice);
                    return;
                case "10":
                    MatchFourOfAKind(dice);
                    return;
                case "11":
                    MatchSmallStraight(dice);
                    return;
                case "12":
                    MatchLargeStraight(dice);
                    return;
                case "13":
                    MatchFullHouse(dice); // need repair
                    return;
                case "14":
                    MatchChance(dice);
                    return;
                case "15":
                    MatchYatzy(dice);
                    return;
            }
            PlayYatzy();

        }



        public static void MatchTypes(int type, List<int> dice, Action<Leaderboard, int> setScore) // need research
        {
            int count = dice.Count(die => die == type);
            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
            setScore(leaderboard, count * type);
            Context.WriteCurrentLeaderboardValues(leaderboard);
        }

        public static void MatchPairs(List<int> dice) // number 9 
        {
            int highestPair = 0;
            for (int i = 6; i >= 1; i--)
            {
                if (dice.Count(x => x == i) >= 2)
                {
                    highestPair = i;
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.Pair = highestPair * 2;
                    Context.WriteCurrentLeaderboardValues(leaderboard);
                    break;
                }
            }
        }

        public static void MatchTwoPairs(List<int> dice)
        {
            int firstHighestPair = 0;
            for (int i = 6; i >= 1; i--)
            {
                if (dice.Count(x => x == i) >= 2)
                {
                    firstHighestPair = i;
                    break;
                }
            }

            int secondHighestPair = 0;
            for (int i = firstHighestPair - 1; i >= 1; i--)
            {
                if (dice.Count(x => x == i) >= 2)
                {
                    secondHighestPair = i;
                    break;
                }
            }

            if (firstHighestPair is not 0 && secondHighestPair is not 0)
            {
                int firstCount = dice.Count(x => x == firstHighestPair);
                int secondCount = dice.Count(x => x == secondHighestPair);
                if (firstCount >= 2 && secondCount >= 2)
                {
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.TwoPairs = firstHighestPair * 2 + secondHighestPair * 2;
                    Context.WriteCurrentLeaderboardValues(leaderboard);

                }
            }
        }
        public static void MatchThreeOfAKind(List<int> dice)
        {
            int highest = 0;
            for (int i = 6; i >= 1; i--)
            {
                if (dice.Count(x => x == i) >= 3)
                {
                    highest = i;
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.ThreeOfAKind = highest * 3;
                    Context.WriteCurrentLeaderboardValues(leaderboard);
                    break;
                }
            }
        }
        public static void MatchFourOfAKind(List<int> dice)
        {
            int highest = 0;
            for (int i = 6; i >= 1; i--)
            {
                if (dice.Count(x => x == i) >= 4)
                {
                    highest = i;
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.FourOfAKind = highest * 4;
                    Context.WriteCurrentLeaderboardValues(leaderboard);
                    break;
                }
            }
        }

        public static void MatchSmallStraight(List<int> dice)
        {
            List<int> smallStraight = new List<int> { 1, 2, 3, 4, 5 };
            if (smallStraight.All(dice.Contains))
            {
                Action<Leaderboard, int> setScore = (leaderboard, score) => leaderboard.SmallStraight = score;
            }
        }

        public static void MatchLargeStraight(List<int> dice)
        {
            List<int> largeStraight = new List<int> { 2, 3, 4, 5, 6 };
            if (largeStraight.All(dice.Contains))
            {
                Action<Leaderboard, int> setScore = (leaderboard, score) => leaderboard.LargeStraight = score;
            }
        }

        public static void MatchFullHouse(List<int> dice)
        {
            var groupedDice = dice.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            if (groupedDice.Count == 2 && groupedDice.Any(g => g.Value == 3))
            {
                Action<Leaderboard, int> setScore = (leaderboard, score) => leaderboard.FullHouse = score;
            }
        }

        public static void MatchChance(List<int> dice)
        {
            int total = dice.Sum();
            Action<Leaderboard, int> setScore = (leaderboard, score) => leaderboard.Chance = score;
        }

        public static void MatchYatzy(List<int> dice)
        {
            if (dice.Distinct().Count() == 1)
            {
                Leaderboard leaderboard = new Leaderboard();
                leaderboard.Yatzy = 50;
                Context.WriteCurrentLeaderboardValues(leaderboard);
            }
            else
            {
                Console.WriteLine("You do not have a Yatzy.");
            }
        }

        public static void CalculateScore(List<int> dice)
        {
            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
            leaderboard.Ones = dice.Count(x => x == 1);
            leaderboard.Twos = dice.Count(x => x == 2) * 2;
            leaderboard.Threes = dice.Count(x => x == 3) * 3;
            leaderboard.Fours = dice.Count(x => x == 4) * 4;
            leaderboard.Fives = dice.Count(x => x == 5) * 5;
            leaderboard.Sixes = dice.Count(x => x == 6) * 6;
            Context.WriteCurrentLeaderboardValues(leaderboard);
        }

        public static void ResetLeaderboard()
        {
            Leaderboard leaderboard = new Leaderboard
            {
                Ones = 0,
                Twos = 0,
                Threes = 0,
                Fours = 0,
                Fives = 0,
                Sixes = 0,
                Bonus = 0,
                Pair = 0,
                TwoPairs = 0,
                ThreeOfAKind = 0,
                FourOfAKind = 0,
                SmallStraight = 0,
                LargeStraight = 0,
                FullHouse = 0,
                Chance = 0,
                Yatzy = 0
            };
            Context.WriteCurrentLeaderboardValues(leaderboard);
        }
    }
}