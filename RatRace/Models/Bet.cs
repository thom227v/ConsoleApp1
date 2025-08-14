using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class Bet
    {
        //private int _money;
        //private Player _player;
        //private Race _race;
        //private Rat _rat;

        public int Money { get; set; }
        public Player Player { get; set; }
        public Race Race { get; set; }
        public Rat Rat { get; set; }

        public void PayWinnings()
        {

        }
    }
}
