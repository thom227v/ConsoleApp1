using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class PayPalPayment : Payment
    {
        public string Email { get; set; }

        public override void ProcessPayment()
        {
            Console.WriteLine("Pay with PayPal");
        }
    }
}
