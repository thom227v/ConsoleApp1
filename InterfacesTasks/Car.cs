using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Car : Vehicle, IDriveable
    {
        public void Start()
        {
            Console.WriteLine("The car is now driving");
        }

        public void Stop()
        {
            Console.WriteLine("The car is now stopped");
        }
    }
}
