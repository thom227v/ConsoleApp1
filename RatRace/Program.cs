using RatRace.Models;
using Humanizer;
using System.ComponentModel;

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
            Race race = new Race();

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
                for (int i = 1; i < playerCount + 1; i++)
                {
                    Console.Write($"Enter the name of the {i.ToOrdinalWords()} player: ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                        i--;
                    }
                    else
                    {
                        if (input.Length > 17 || input.Length < 1)
                        {
                            Console.WriteLine("Name must be between 1 and 17 characters long. Please enter a valid name.");
                            i--;
                            continue;
                        }
                        else if (raceManager.Players.Any(p => p.Name == input)) // if the name already exists
                        {
                            Console.WriteLine("This name is already taken. Please choose a different name.");
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


            bool createRatsStatus = true;
            do
            {
                Console.Clear();
                Console.Write("Enter the amount of rats you wise to use in the track, or enter rats for already prefixed rat names: ");
                string amountInput = Console.ReadLine();
                if (amountInput.ToLower() == "rats")
                {
                    Rat rat1 = new Rat()
                    {
                        Name = "Benjamin",
                        Position = 1
                    };
                    raceManager.Rats.Add(rat1);
                    Rat rat2 = new Rat()
                    {
                        Name = "Tarkov",
                        Position = 2
                    };
                    raceManager.Rats.Add(rat2);
                    Rat rat3 = new Rat()
                    {
                        Name = "Emil",
                        Position = 3
                    };
                    raceManager.Rats.Add(rat3);
                    createRatsStatus = false;
                }

                bool isValidInput = int.TryParse(amountInput, out int ratCount);
                if (!isValidInput || ratCount < 1 || ratCount > 10)
                {
                    Console.WriteLine("Can only enter numbers between 1 and 10");
                    continue;
                }
                for (int i = 0; i < ratCount; i++)
                {
                    Console.Write($"Enter the name of the {i.ToOrdinalWords()} rat: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                        i--;
                    }
                    else
                    {
                        if (input.Length > 17 || input.Length < 1)
                        {
                            Console.WriteLine("Name must be between 1 and 17 characters long. Please enter a valid name.");
                            i--;
                            continue;
                        }
                        else if (raceManager.Players.Any(p => p.Name == input)) // if the name already exists
                        {
                            Console.WriteLine("This name is already taken. Please choose a different name.");
                            i--;
                            continue;
                        }

                        int position = raceManager.Rats.Count + 1;
                        raceManager.Rats.Add(raceManager.CreateRat(input, position));
                        Console.WriteLine($"Rat {input}, has now been created with the starting position of {position}");
                        createRatsStatus = false;
                    }
                }
            }
            while (createRatsStatus);



            bool trackInformationStatus = true;
            do
            {
                Console.Clear();
                Console.Write("Enter the name of the track you wise to create: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }
                else
                {
                    if (input.Length > 17 || input.Length < 1)
                    {
                        Console.WriteLine("Name must be between 1 and 17 characters long. Please enter a valid name.");
                        continue;
                    }
                    else if (raceManager.Tracks.Any(p => p.Name == input)) // if the name already exists
                    {
                        Console.WriteLine("This name is already taken. Please choose a different track name.");
                        continue;
                    }

                    Console.Write("Enter the length of the track (recommended length is 150-600)");
                    bool isValidInput = int.TryParse(Console.ReadLine(), out int length);
                    if (!isValidInput)
                    {
                        Console.WriteLine("Length is needed");
                        continue;
                    }
                    else if (length < 150 || length > 600)
                    {
                        Console.WriteLine("Length must be between 150 and 600. Please enter a valid length.");
                        continue;
                    }
                    raceManager.Tracks.Add(raceManager.CreateTrack(input, length));
                    Console.WriteLine($"Track {input} with length {length} has been created.");
                    trackInformationStatus = false;
                    race = raceManager.CreateRace(raceManager.Races.Count + 1, raceManager.Rats, raceManager.Tracks.First(track => track.Name == input));
                }
            }
            while (trackInformationStatus);

            Console.Clear();
            int countPlayersAmount = raceManager.Players.Count;
            for (int i = 0; i < countPlayersAmount; i++)
            {
                Console.Clear();
                bool playerPlacesBetsStatus = true;
                do
                {
                    Console.WriteLine($"Player {raceManager.Players[i].Name}, you have {raceManager.Players[i].Money} money left to bet with.");
                    Console.Write("Please enter the name of the rat you wish to bet on, or type 'exit' to leave the betting phase: ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                    {
                        playerPlacesBetsStatus = false;  
                        continue;
                    }
                    Rat? rat = raceManager.Rats.FirstOrDefault(r => r.Name == input);
                    if (rat == null)
                    {
                        Console.WriteLine("Invalid rat name. Please try again.");
                        i--;
                        continue;
                    }

                    Console.Write("Enter the amount of money you wish to bet: ");
                    bool isValidBet = int.TryParse(Console.ReadLine(), out int betAmount);
                    if (!isValidBet || betAmount <= 0 || betAmount > raceManager.Players[i].Money)
                    {
                        Console.WriteLine("Invalid bet amount. Please try again.");
                        i--;
                        continue;
                    }

                    Bookmaker bookmaker = new Bookmaker();
                    Bet bet = bookmaker.PlaceBet(race: race, rat: rat, player: raceManager.Players[i], betAmount);

                    raceManager.Players[i].Bets.Add(bet);
                    raceManager.Players[i].Money -= betAmount;

                } while (playerPlacesBetsStatus);
            }


            //int startCooldown = 5;
            //for (int i = startCooldown; i >= 0; i--)
            //{
            //    Console.Clear();
            //    Console.WriteLine($"{i.Seconds()} seconds left before the game starts");
            //    Thread.Sleep(100);
            //}
        }
    }
}