using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class Bookmaker
    {
        public List<Bet> Bets { get; set; }

        public Bet PlaceBet(Race race, Rat rat, Player player, int money)
        {
            return new Bet
            {
                Money = money,
                Player = player,
                Race = race,
                Rat = rat
            };
        }

        public void PayOutWinnings(Bet bet)
        {

        }
    }
}
