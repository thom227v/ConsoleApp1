﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
