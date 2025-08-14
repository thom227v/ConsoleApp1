using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class Race
    {
        private Rat _winner;
        private string _log;
        public int RaceId { get; set; }
        public List<Rat> Rats { get; set; }
        public Track RaceTrack { get; set; }

        public void ConductRace()
        {

        }

        public Rat GetWinner()
        {
            return null;

        }

        public string GetRaceReport()
        {
            return null;
        }

        private void LogRace()
        {

        }
    }
}
