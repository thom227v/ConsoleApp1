using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class RockPaperScissorsGame : IGameEngine
    {
        public void Play()
        {
            Console.WriteLine("Playing Rock Paper Scissors Game");
            Console.WriteLine("Enter your choice (rock, paper, scissors): ");
            string userChoice = Console.ReadLine()?.ToLower();
            if (string.IsNullOrEmpty(userChoice) ||
                (userChoice != "rock" && userChoice != "paper" && userChoice != "scissors"))
            {
                Console.WriteLine("Invalid choice. Please enter rock, paper, or scissors.");
                return;
            }
            Random random = new Random();
            string[] choices = { "rock", "paper", "scissors" };
            string computerChoice = choices[random.Next(choices.Length)];
            Console.WriteLine($"Computer chose: {computerChoice}");
            if (userChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((userChoice == "rock" && computerChoice == "scissors") ||
                     (userChoice == "paper" && computerChoice == "rock") ||
                     (userChoice == "scissors" && computerChoice == "paper"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
    }
}
