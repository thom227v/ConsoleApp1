using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Bicycle : Vehicle
    {
        public bool HasBell { get; set; }
        public override void Drive()
        {
            Console.WriteLine("The bicycle is pedaling");
        }
    }
}
