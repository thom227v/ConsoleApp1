using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1.Models
{
    public class Leaderboard
    {
        private int score;
        private int totalScore;

        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public int Sixes { get; set; }

        public int Score
        {
            get { return score; }
            set
            {
                score = Ones + Twos + Threes + Fours +
                    Fives + Sixes;
            }
        }

        public int Bonus { get; set; }
        public int Pair { get; set; }
        public int TwoPairs { get; set; }
        public int ThreeOfAKind { get; set; }
        public int FourOfAKind { get; set; }
        public int SmallStraight { get; set; }
        public int LargeStraight { get; set; }
        public int FullHouse { get; set; }
        public int Chance { get; set; }
        public int Yatzy { get; set; }

        public int TotalScore
        {
            get { return totalScore; }
            set
            {
                totalScore = score + Pair + TwoPairs +
                    ThreeOfAKind + FourOfAKind + SmallStraight +
                    LargeStraight + FullHouse + Chance + Yatzy;
            }
        }


        public static void IsBonusValid(List<int> dice)
        {
            Leaderboard leaderboard = Context.ReadCurrentLeaderboardValues();
            int sum = leaderboard.Ones + leaderboard.Twos + leaderboard.Threes + leaderboard.Fours + leaderboard.Fives + leaderboard.Sixes;

            if (sum >= 63)
            {
                leaderboard.Bonus = 50;
            }
            else
            {
                leaderboard.Bonus = 0;
            }
        }
    }
}
