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

        public int CombinedRoll { get; set; }


        public Die(int amount)
        {
            if (amount == 2)
            {
                Random random = new Random();

                CombinedRoll = random.Next(1, 7) + random.Next(1, 7);
            }
            else
            {
                Random random = new Random();
                bool yatzy = true;
                do
                {
                    int total = 0;
                    for (int i = 0; i < amount; i++)
                    {
                        total += random.Next(1, 7);

                        RollAmount++;
                    }
                    if (total == (amount * 6))
                        yatzy = false;
                }
                while (yatzy);
            }
        }

        public Die()
        {
            Random random = new Random();
            CombinedRoll = random.Next(1, 7);
        }
    }
}