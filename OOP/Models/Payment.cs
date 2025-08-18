using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Payment
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public virtual void ProcessPayment()
        {
            Console.WriteLine("Processing generic payment");
        }
    }
}
