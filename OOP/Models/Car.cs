using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public override void Drive()
        {
            Console.WriteLine("The car is driving");
        }
    }
}
