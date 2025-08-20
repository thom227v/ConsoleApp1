using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Temp not logging to file");
        }
    }
}
