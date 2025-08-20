using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class FakePaymentProcessor
    {
        public void Process(decimal amount)
        {
            Console.WriteLine("This is a fake payment processor with dummy text");
        }
    }
}
