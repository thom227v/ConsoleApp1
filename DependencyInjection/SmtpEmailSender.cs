using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class SmtpEmailSender : IEmailSender, ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging message...");
        }

        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine("Sending email to {0} about the topic '{1}'", to, subject);
        }

    }
}
