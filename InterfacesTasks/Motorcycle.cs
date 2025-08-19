using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Motorcycle : Vehicle, IDriveable
    {
        public void Start()
        {
            Console.WriteLine("The motercycle is now driving");
        }

        public void Stop()
        {
            Console.WriteLine("The Motercycle is now stopped");
        }
    }
}
