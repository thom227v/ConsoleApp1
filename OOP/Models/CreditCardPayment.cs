using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; }
        public override void ProcessPayment()
        {
            Console.WriteLine("Pay with credit card");
        }
    }
}
