using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class NotificationService
    {
        private readonly IEmailSender emailSender;
        private readonly ILogger log;

        public NotificationService(IEmailSender emailSender, ILogger log)
        {
            this.emailSender = emailSender;
            this.log = log;

            emailSender.SendEmail("Benjamin", "Car Warranty", "We have been trying to contact you about your car warranty");
            log.Log("Email sent successfully.");
        }

    }
}