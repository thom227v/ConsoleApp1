using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class RaceManager
    {
        public List<Track> Tracks { get; set; }
        public List<Player> Players { get; set; }
        public List<Race> Races { get; set; }
        public List<Rat> Rats { get; set; }

        public Race CreateRace(int raceId, List<Rat> rats, Track track)
        {
            return new Race
            {
                RaceId = raceId,
                Rats = rats,
                RaceTrack = track,
            };
        }

        public Track CreateTrack(string name, int trackLength)
        {
            return new Track
            {
                Name = name,
                TrackLength = trackLength
            };
        }

        public void ConductRace(Race race)
        {

        }

        public string ViewRaceReport(Race race)
        {

        }

        public Rat CreateRat(string name)
        {
            return new Rat
            {
                Name = name,
                Position = 0,
            };
        }

        public Player CreatePlayer(string name, int money)
        {
            return new Player
            {
                Name = name,
                Money = money,
                Bets = new List<Bet>()
            };
        }
    }
}
