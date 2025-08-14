using RatRace.Models;

namespace RatRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("""
                ---------------------------------
                 ----Welcome to the Rat Race----
                ---------------------------------
                """);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            bool gameCreateStatus = true;
            do
            {
                Console.WriteLine("""
                Enter play to start a new game
                """);
                string input = Console.ReadLine();
                if (input.ToLower() == "play")
                {
                    gameCreateStatus = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'play' to start a new game.");
                }
            }
            while (gameCreateStatus);

            RaceManager raceManager = new RaceManager();
            int playerCount = 0;

            bool playerAmountStatus = true;
            do
            {
                playerAmountStatus = false;
                Console.Write("Enter the amount of players (2-5 players): ");
                bool isValidInput = int.TryParse(Console.ReadLine(), out playerCount);
                if (!isValidInput || playerCount > 6 || playerCount < 1)
                {
                    Console.WriteLine("Can only enter numbers");
                    playerAmountStatus = true;
                }
            }
            while (playerAmountStatus);

            bool playerInformationStatus = true;
            do
            {
                Console.Clear();
                for (int i = 0; i < playerCount; i++)
                {
                    Console.Write("Enter the name of the first player: ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                        playerInformationStatus = true;
                        i--;
                    }
                    else
                    {
                        if (input.Length > 17 || input.Length < 1)
                        {
                            Console.WriteLine("Name must be between 1 and 17 characters long. Please enter a valid name.");
                            playerInformationStatus = true;
                            i--;
                            continue;
                        }
                        else if (raceManager.Players.Any(p => p.Name.Equals(input, StringComparison.OrdinalIgnoreCase))) // if the name already exists
                        {
                            Console.WriteLine("This name is already taken. Please choose a different name.");
                            playerInformationStatus = true;
                            i--;
                            continue;
                        }

                        int startBalance = 1000;
                        raceManager.Players.Add(raceManager.CreatePlayer(input, startBalance));
                        Console.WriteLine($"Welcome {input}, you will be starting with a balance of {startBalance}");
                        playerInformationStatus = false;
                    }
                }
            }
            while (playerInformationStatus);


            bool trackInformationStatus = true;
            do
            { 
                Console.Clear();
                Console.WriteLine("Enter the length of the track");
            }
            while (trackInformationStatus);

        }

    }
}
