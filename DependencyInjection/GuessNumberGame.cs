using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class GuessNumberGame : IGameEngine
    {
        public void Play()
        {
            Console.WriteLine("Playing Guess Number Game");
            Console.WriteLine("Guess 1 or 2");
            Random random = new Random();
            
            int number = random.Next(1, 3);
            bool isValidGuess = int.TryParse(Console.ReadLine(), out int  guess);
            while (guess != number)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out guess))
                {
                    if (guess == number)
                    {
                        Console.WriteLine("Congratulations! You guessed the number.");
                    }
                    else
                    {
                        Console.WriteLine("Wrong guess, try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}
