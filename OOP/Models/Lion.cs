using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Lion : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Roar");
        }
    }
}
