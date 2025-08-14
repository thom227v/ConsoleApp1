using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class GameState
    {
        public int game_id { get; set; }
        public string date { get; set; }
        public List<PlayerState> players { get; set; } = new List<PlayerState>();
    }
}
