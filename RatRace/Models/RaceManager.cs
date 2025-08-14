using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class RaceManager
    {
        public List<Track> Tracks { get; set; } = new List<Track>();
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Race> Races { get; set; } = new List<Race>();
        public List<Rat> Rats { get; set; } = new List<Rat>();

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
            return null;

        }

        public Rat CreateRat(string name, int position)
        {
            return new Rat
            {
                Name = name,
                Position = position,
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
