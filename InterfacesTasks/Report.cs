using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Report : IPrintable, ISaveable
    {
        public void Print()
        {
            Console.WriteLine("This is an report");
        }

        public void Save(string path)
        {
            Console.WriteLine($"Saving the report in {path}");
        }
    }
}
