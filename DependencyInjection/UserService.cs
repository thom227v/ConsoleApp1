using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class UserService
    {
        private readonly ILogger log;

        public UserService(ILogger log)
        {
            this.log = log;
        }

        public void PostCurrentLogMessage()
        {
            log.Log("THIS IS AN EXAMPLE MESSAGE");
        }

    }
}
