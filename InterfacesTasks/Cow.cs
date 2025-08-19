using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Cow : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Moo Moo");
        }
    }
}
