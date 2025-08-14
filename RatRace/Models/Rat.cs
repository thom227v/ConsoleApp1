using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Models
{
    public class Rat
    {
        private int _position;
        public string Name { get; set; }
        public int Position { get; set; }

        public void ResetRat()
        {
            Name = string.Empty;
            Position = 0;
        }
        
        public int MoveRat()
        {
            return RNG.Range(1, 10);
        }


    }
}
