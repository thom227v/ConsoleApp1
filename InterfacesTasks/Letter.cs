using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Letter : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("This is a letter");
        }
    }
}
