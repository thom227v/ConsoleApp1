using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class CheckoutService
    {
        private readonly IPaymentProcessor paymentProcessor;

        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            this.paymentProcessor = paymentProcessor;
        }

        public void DisplayPaymentProcessorName()
        {
            paymentProcessor.Process(100.00m);
        }
    }
}
