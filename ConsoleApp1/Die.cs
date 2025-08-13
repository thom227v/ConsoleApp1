using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp1
{
    public class Die
    {
        public int RollAmount { get; set; }
        public int CombinedRoll { get; set; }
        public List<int> Rolls { get; set; }

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
            Rolls = new List<int>() { 1, 1, 2, 2, 5 };
            Context.WriteToCurrentDiceValues(Rolls);
        }

        public void DiceToRoll(int amount, List<int> currentList = null)
        {
            if (currentList != null)
            {
                foreach (int roll in currentList)
                {
                    int index = Array.IndexOf(currentList.ToArray(), roll);
                    Console.WriteLine($"You rolled a {roll}\tindex; {index}");
                }
            }

            Random random = new Random();
            for (int i = amount; i < Rolls.Count(); i++)
            {
                currentList.Add(random.Next(1, 7));
            }
            Context.WriteToCurrentDiceValues(currentList);
        }
    }
}