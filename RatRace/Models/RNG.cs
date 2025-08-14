using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public static class RNG
    {
        private static Random _rng;

        public static int Range(int min, int max)
        {
            _rng = new Random();
            return _rng.Next(min, max);
        }
    }
}
