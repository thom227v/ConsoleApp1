using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Yatzy
    {
        public static void PlayYatzy(GameState gameState)
        {
            int rounds = 15;
            for (int round = 0; round < rounds; round++) // 15 rounds (15 choices on yatzy board)
            {
                foreach (var player in gameState.players)
                {
                    Console.WriteLine($"\n--- {player.name}'s turn ---");
                    Die die = new Die();                                     // roll players first dice
                    DisplayDice();
                    int rerolls = 0;
                    List<int> currentDice = Context.ReadCurrentDiceValues();
                    while (rerolls < 5)
                    {
                        Console.Write($"""
                            {player.name}, Type \"reroll\" to reroll all dice, 
                            "stop" to keep dice and score, 
                            or anything enter else to remove dice in index:
                            """);
                        string input = Console.ReadLine();
                        if (input.Trim().ToLower() == "stop") // if player ends game
                        {
                            GameChoosing(currentDice, player);
                            break;
                        }
                        else if (input.Trim().ToLower() == "reroll") // if player rerolls all dice
                        {
                            die = new Die();
                            currentDice = Context.ReadCurrentDiceValues();
                            DisplayDice();
                            rerolls++;
                        }
                        else // reroll dice using indexing
                        {
                            currentDice = MatchWhichDicesToRemove();
                            die.DiceToRoll(currentDice.Count(), currentDice);
                            currentDice = Context.ReadCurrentDiceValues();
                            DisplayDice();
                            rerolls++;
                        }
                    }
                    if (rerolls == 4) // if player is out of rerolls, force to make a choice
                    {
                        Console.WriteLine($"{player.name}, youu no more rolls left, please choose a category to score: ");
                        GameChoosing(currentDice, player);
                    }
                    Context.SaveGameState(gameState);
                }
            }
        }

        static List<int> MatchWhichDicesToRemove()
        {
            List<int> dice = Context.ReadCurrentDiceValues();
            bool gameChoiceState = true;
            int[] inputNumbers = new int[0];
            do // loop until player has choosen to stop removing dice
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
                    try // try and remove dice from list if it exists 
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

        public static void GameChoosing(List<int> dice, PlayerState player = null)
        {
            if (player == null)
            {
                Console.WriteLine("Error: player does not have any context");
                return;
            }
            // build list of available options left for the player
            List<(string key, string label)> available = new List<(string key, string label)>(); // key for input verification and label for readability for user
            if (player.choices.Ones == 0) available.Add(("1", "1's"));
            if (player.choices.Twos == 0) available.Add(("2", "2's"));
            if (player.choices.Threes == 0) available.Add(("3", "3's"));
            if (player.choices.Fours == 0) available.Add(("4", "4's"));
            if (player.choices.Fives == 0) available.Add(("5", "5's"));
            if (player.choices.Sixes == 0) available.Add(("6", "6's"));
            if (player.choices.Pair == 0) available.Add(("7", "1 pair"));
            if (player.choices.TwoPairs == 0) available.Add(("8", "2 pair"));
            if (player.choices.ThreeOfAKind == 0) available.Add(("9", "three of a kind"));
            if (player.choices.FourOfAKind == 0) available.Add(("10", "four of a kind"));
            if (player.choices.SmallStraight == 0) available.Add(("11", "small straight"));
            if (player.choices.LargeStraight == 0) available.Add(("12", "big straight"));
            if (player.choices.FullHouse == 0) available.Add(("13", "house"));
            if (player.choices.Chance == 0) available.Add(("14", "chance"));
            if (player.choices.Yatzy == 0) available.Add(("15", "YATZY"));

            if (available.Count == 0)
            {
                Console.WriteLine("No available choice left for you to choose. Your turn is skipped.");
                return;
            }
            while (true)
            {
                Console.WriteLine("What do you choose:");
                foreach (var (key, label) in available)
                    Console.WriteLine($"{key} for {label}");
                string input = Console.ReadLine();
                if (!available.Any(a => a.key == input))
                {
                    Console.WriteLine("Invalid or already used category. Please choose from the available options.");
                    continue;
                }
                //score logic
                switch (input)
                {
                    case "1":
                        player.choices.Ones = dice.Count(d => d == 1) * 1;
                        break;
                    case "2":
                        player.choices.Twos = dice.Count(d => d == 2) * 2;
                        break;
                    case "3":
                        player.choices.Threes = dice.Count(d => d == 3) * 3;
                        break;
                    case "4":
                        player.choices.Fours = dice.Count(d => d == 4) * 4;
                        break;
                    case "5":
                        player.choices.Fives = dice.Count(d => d == 5) * 5;
                        break;
                    case "6":
                        player.choices.Sixes = dice.Count(d => d == 6) * 6;
                        break;
                    case "7": 
                        player.choices.Pair = 0;
                        for (int i = 6; i >= 1; i--)
                        {
                            if (dice.Count(x => x == i) >= 2)
                            {
                                player.choices.Pair = i * 2;
                                break;
                            }
                        }
                        break;
                    case "8": 
                        int firstPair = 0, secondPair = 0;
                        for (int i = 6; i >= 1; i--)
                        {
                            if (dice.Count(x => x == i) >= 2)
                            {
                                if (firstPair == 0) firstPair = i;
                                else if (secondPair == 0 && i != firstPair) { secondPair = i; break; }
                            }
                        }
                        if (firstPair != 0 && secondPair != 0)
                            player.choices.TwoPairs = firstPair * 2 + secondPair * 2;
                        else
                            player.choices.TwoPairs = 0;
                        break;
                    case "9": 
                        player.choices.ThreeOfAKind = 0;
                        for (int i = 6; i >= 1; i--)
                        {
                            if (dice.Count(x => x == i) >= 3)
                            {
                                player.choices.ThreeOfAKind = i * 3;
                                break;
                            }
                        }
                        break;
                    case "10":
                        player.choices.FourOfAKind = 0;
                        for (int i = 6; i >= 1; i--)
                        {
                            if (dice.Count(x => x == i) >= 4)
                            {
                                player.choices.FourOfAKind = i * 4;
                                break;
                            }
                        }
                        break;
                    case "11": 
                        player.choices.SmallStraight = (new List<int> { 1, 2, 3, 4, 5 }.All(dice.Contains)) ? 15 : 0;
                        break;
                    case "12": 
                        player.choices.LargeStraight = (new List<int> { 2, 3, 4, 5, 6 }.All(dice.Contains)) ? 20 : 0;
                        break;
                    case "13": 
                        int three = 0, two = 0;
                        for (int i = 6; i >= 1; i--)
                        {
                            if (dice.Count(x => x == i) >= 3 && three == 0) three = i;
                            else if (dice.Count(x => x == i) >= 2 && i != three && two == 0) two = i;
                        }
                        player.choices.FullHouse = (three != 0 && two != 0) ? three * 3 + two * 2 : 0;
                        break;
                    case "14": 
                        player.choices.Chance = dice.Sum();
                        break;
                    case "15": 
                        player.choices.Yatzy = (dice.Distinct().Count() == 1) ? 50 : 0;
                        break;
                }
                // check if player is intiltelt to bonus yet
                if ((player.choices.Ones + player.choices.Twos + player.choices.Threes + player.choices.Fours + player.choices.Fives + player.choices.Sixes) >= 63)
                    player.choices.Bonus = 50;
                else
                    player.choices.Bonus = 0;

                // update the totalScore
                player.totalScore = player.choices.Ones + player.choices.Twos + player.choices.Threes + player.choices.Fours + player.choices.Fives + player.choices.Sixes + player.choices.Bonus + player.choices.Pair + player.choices.TwoPairs + player.choices.ThreeOfAKind + player.choices.FourOfAKind + player.choices.SmallStraight + player.choices.LargeStraight + player.choices.FullHouse + player.choices.Chance + player.choices.Yatzy;
                break;
            }
        }

        //public static void MatchTypes(int type, List<int> dice, Action<Leaderboard, int> setScore) // need research
        //{
        //    int count = dice.Count(die => die == type);
        //    Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //    setScore(leaderboard, count * type);
        //    Context.WriteCurrentLeaderboardValues(leaderboard);
        //}

        //public static void MatchPairs(List<int> dice) // number 9 
        //{
        //    int highestPair = 0;
        //    for (int i = 6; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 2)
        //        {
        //            highestPair = i;
        //            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //            leaderboard.Pair = highestPair * 2;
        //            Context.WriteCurrentLeaderboardValues(leaderboard);
        //            break;
        //        }
        //    }
        //}

        //public static void MatchTwoPairs(List<int> dice)
        //{
        //    int firstHighestPair = 0;
        //    for (int i = 6; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 2)
        //        {
        //            firstHighestPair = i;
        //            break;
        //        }
        //    }

        //    int secondHighestPair = 0;
        //    for (int i = firstHighestPair - 1; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 2)
        //        {
        //            secondHighestPair = i;
        //            break;
        //        }
        //    }

        //    if (firstHighestPair is not 0 && secondHighestPair is not 0)
        //    {
        //        int firstCount = dice.Count(x => x == firstHighestPair);
        //        int secondCount = dice.Count(x => x == secondHighestPair);
        //        if (firstCount >= 2 && secondCount >= 2)
        //        {
        //            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //            leaderboard.TwoPairs = firstHighestPair * 2 + secondHighestPair * 2;
        //            Context.WriteCurrentLeaderboardValues(leaderboard);
        //        }
        //    }
        //}
        //public static void MatchThreeOfAKind(List<int> dice)
        //{
        //    int highest = 0;
        //    for (int i = 6; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 3)
        //        {
        //            highest = i;
        //            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //            leaderboard.ThreeOfAKind = highest * 3;
        //            Context.WriteCurrentLeaderboardValues(leaderboard);
        //            break;
        //        }
        //    }
        //}

        //public static void MatchFourOfAKind(List<int> dice)
        //{
        //    int highest = 0;
        //    for (int i = 6; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 4)
        //        {
        //            highest = i;
        //            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //            leaderboard.FourOfAKind = highest * 4;
        //            Context.WriteCurrentLeaderboardValues(leaderboard);
        //            break;
        //        }
        //    }
        //}

        //public static void MatchSmallStraight(List<int> dice)
        //{
        //    List<int> smallStraight = new List<int> { 1, 2, 3, 4, 5 };
        //    if (smallStraight.All(dice.Contains))
        //    {
        //        Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //        leaderboard.SmallStraight = 1 + 2 + 3 + 4 + 5;
        //        Context.WriteCurrentLeaderboardValues(leaderboard);
        //    }
        //}

        //public static void MatchLargeStraight(List<int> dice)
        //{
        //    List<int> largeStraight = new List<int> { 2, 3, 4, 5, 6 };
        //    if (largeStraight.All(dice.Contains))
        //    {
        //        Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //        leaderboard.LargeStraight = 2 + 3 + 4 + 5 + 6;
        //        Context.WriteCurrentLeaderboardValues(leaderboard);
        //    }
        //}

        //public static void MatchFullHouse(List<int> dice)
        //{
        //    int firstHighestNum = 0;
        //    for (int i = 6; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 2)
        //        {
        //            firstHighestNum = i;
        //        }
        //    }
        //    int secondHighestNum = 0;
        //    for (int i = firstHighestNum; i >= 1; i--)
        //    {
        //        if (dice.Count(x => x == i) >= 3)
        //        {
        //            secondHighestNum = i;

        //        }
        //    }

        //    if (firstHighestNum == 0 || secondHighestNum == 0)
        //    {
        //        int firstHighestNum2 = 0;
        //        for (int i = 6; i >= 1; i--)
        //        {
        //            if (dice.Count(x => x == i) >= 3)
        //            {
        //                firstHighestNum2 = i;
        //            }
        //        }
        //        int secondHighestNum2 = 0;
        //        for (int i = firstHighestNum2; i >= 1; i--)
        //        {
        //            if (dice.Count(x => x == i) >= 2)
        //            {
        //                secondHighestNum2 = i;
        //            }
        //        }

        //        if (firstHighestNum2 == 0 || secondHighestNum2 == 0)
        //        {
        //            Console.WriteLine("You do not have a full house.");
        //            return;
        //        }
        //        else
        //        {
        //            Leaderboard leaderboard2 = Context.ReadCurrentLeaderboardValues();
        //            leaderboard2.FullHouse = firstHighestNum2 * 3 + secondHighestNum2 * 2;
        //            Context.WriteCurrentLeaderboardValues(leaderboard2);
        //            return;
        //        }
        //    }
        //    Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //    leaderboard.FullHouse = firstHighestNum * 2 + secondHighestNum * 3;
        //    Context.WriteCurrentLeaderboardValues(leaderboard);
        //    return;
        //}

        //public static void MatchChance(List<int> dice)
        //{
        //    int total = dice.Sum();
        //    Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //    leaderboard.Chance = total;
        //    Context.WriteCurrentLeaderboardValues(leaderboard);
        //}

        //public static void MatchYatzy(List<int> dice)
        //{
        //    if (dice.Distinct().Count() == 1)
        //    {
        //        Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
        //        leaderboard.Yatzy = 50;
        //        Context.WriteCurrentLeaderboardValues(leaderboard);
        //    }
        //    else
        //    {
        //        Console.WriteLine("You do not have a Yatzy.");
        //    }
        //}

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