using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Mage : Character
    {
        public int Mana { get; set; }
        public override int Attack()
        {
            return Mana / 2;
        }
    }
}
