using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Warrior : Character
    {
        public int Strength { get; set; }
        public override int Attack()
        {
            return Strength * 2;
        }
    }
}
