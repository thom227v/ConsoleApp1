using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Invoice : IPrintable, ISaveable
    {
        public void Print()
        {
            Console.WriteLine("This is an invoice");
        }

        public void Save(string path)
        {
            Console.WriteLine($"Saving invoice to {path}");
        }
    }
}
