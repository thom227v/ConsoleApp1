using System.ComponentModel.DataAnnotations;
using DependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task 1: Logger
            //Logging();
            // Task 2: Payment GateWay
            //PaymentGateWay();
            // Task 3: Emil sender
            //EmailSender();
            // Task 4: Data Repository
            DataRepo();
            // Task 5: Game Logic
            //GameLogic();
        }
        public static void Logging()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<ILogger, ConsoleLogger>();
            //serviceCollection.AddTransient<ILogger, FileLogger>(); // can change uncomment this line to instead use FileLogger
            serviceCollection.AddTransient<UserService>();
            var sp = serviceCollection.BuildServiceProvider();

            var userService = sp.GetRequiredService<UserService>();

            userService.PostCurrentLogMessage();
        }

        public static void PaymentGateWay()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IPaymentProcessor, PayPalPaymentProcessor>();
            //serviceCollection.AddTransient<IPaymentProcessor, FakePaymentProcessor>(); // this gives error, indicating that it will not work with dependency injection
            serviceCollection.AddTransient<CheckoutService>();

            var sp = serviceCollection.BuildServiceProvider();
            var checkoutService = sp.GetRequiredService<CheckoutService>();

            checkoutService.DisplayPaymentProcessorName();
        }

        public static void EmailSender()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IEmailSender, SmtpEmailSender>();
            //serviceCollection.AddTransient<IEmailSender, ConsoleEmailSender>();
            serviceCollection.AddTransient<ILogger, SmtpEmailSender>();
            //serviceCollection.AddTransient<ILogger, ConsoleEmailSender>();
            serviceCollection.AddTransient<NotificationService>();

            var sp = serviceCollection.BuildServiceProvider();
            var notificationService = sp.GetRequiredService<NotificationService>();
        }

        public static void DataRepo()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            //serviceCollection.AddTransient<IProductRepository, SqlProductRepository>(); // to use SqlProductRepository instead of InMemoryProductRepository
            //serviceCollection.AddTransient<InMemoryProductRepository>();
            serviceCollection.AddTransient<IProductRepository, InMemoryProductRepository>();
            serviceCollection.AddTransient<SqlProductRepository>();
            serviceCollection.AddTransient<ProductService>();
            
            var sp = serviceCollection.BuildServiceProvider();
            var productService = sp.GetRequiredService<ProductService>();
            var sqlProductRepository = sp.GetRequiredService<SqlProductRepository>();
            sqlProductRepository.AddProduct("Burger");
            sqlProductRepository.AddProduct("Pizza");
            sqlProductRepository.AddProduct("Pasta");

            foreach (var product in sqlProductRepository.GetAllProducts())
            {
                Console.WriteLine(product);
            }
        }


        public static void GameLogic()
        {
            Console.WriteLine("Type 1 for guessing number game, or type 2 for rock paper scissors game");

            string input = Console.ReadLine();
            if (input == "1")
            {
                PlayGuessNumberGame();
            }
            else if (input == "2")
            {
                PlayRockPaperScissorsGame();
            }
            else
            {
                Console.WriteLine("Invalid input. Please type 1 or 2.");
            }

        }

        public static void PlayGuessNumberGame()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IGameEngine, GuessNumberGame>();
            serviceCollection.AddTransient<GameRunner>();
            var sp = serviceCollection.BuildServiceProvider();
            var gameRunner = sp.GetRequiredService<GameRunner>();
        }
        public static void PlayRockPaperScissorsGame()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IGameEngine, RockPaperScissorsGame>();
            serviceCollection.AddTransient<GameRunner>();
            var sp = serviceCollection.BuildServiceProvider();
            var gameRunner = sp.GetRequiredService<GameRunner>();
        }
    }
}