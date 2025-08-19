using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Cat : IMakeSound, IFeedable
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow Meow");
        }

        public void Feed()
        {
            Console.WriteLine("The cat is now fed");
        }

    }
}
