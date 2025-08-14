using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
        public class PlayerState
        {
            public string id { get; set; }
            public string name { get; set; }
            public Choices choices { get; set; } = new Choices();
            public int totalScore { get; set; }
        }
}
