using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class GameState
    {
        public int game_id { get; set; }
        public string date { get; set; }
        public string mode { get; set; } = "standard";
        public List<PlayerState> players { get; set; } = new List<PlayerState>();
    }

    public class PlayerState
    {
        public string id { get; set; }
        public string name { get; set; }
        public Choices choices { get; set; } = new Choices();
        public int totalScore { get; set; }
    }

    public class Choices
    {
        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public int Sixes { get; set; }
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
    }
}
