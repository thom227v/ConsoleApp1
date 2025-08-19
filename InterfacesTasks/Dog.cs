using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Dog : IMakeSound, IFeedable
    {
        public void Feed()
        {
            Console.WriteLine("The dog is now Fed");
        }

        public void MakeSound()
        {
            Console.WriteLine("Woof Woof");
        }
    }
}
