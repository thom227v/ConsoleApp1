using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Context
    {
        public static string GetDataDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] specificDirectory = Directory.GetDirectories(currentDirectory);

            foreach (string file in specificDirectory)
            {
                if (file.Contains("Data"))
                    return file;
            }
            return null;
        }
    }
}
