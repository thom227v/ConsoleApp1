using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Die
    {
        public int RollAmount { get; set; }

        public Die(int amount)
        {
            Random random = new Random();
            int count = 0;
            bool yatzy = true;
            do
            {
                int total = 0;
                for (int i = 0; i < amount; i++)
                {
                    total += random.Next(1, 7);

                    RollAmount++;
                }
                if (total == (amount*6))
                    yatzy = false;
            }
            while (yatzy);
        }
    }
}