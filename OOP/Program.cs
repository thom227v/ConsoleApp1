using OOP.Models;
using System.Globalization;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Vehicles
            Vehicles();

            // Task 2: Animals
            Animals();

            // Task 3: Payments
            Payments();

            // Task 4: Shapes
            Shapes();

            // Task 5: RPG Characters
            RPGGame();
        }

        public static void Vehicles()
        {
            Bicycle bike = new Bicycle();
            Car car = new Car();
            bike.Drive();
            car.Drive();
        }

        public static void Animals()
        {
            Lion lion = new Lion();
            Elephant elephant = new Elephant();
            Parrot parrot = new Parrot();
            lion.MakeSound();
            elephant.MakeSound();
            parrot.MakeSound();
        }

        public static void Payments()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            creditCardPayment.ProcessPayment();
            PayPalPayment payPalPayment = new PayPalPayment();
            payPalPayment.ProcessPayment();
        }

        public static void Shapes()
        {
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            Console.WriteLine(circle.GetArea());
            Console.WriteLine(rectangle.GetArea());
        }

        public static void RPGGame()
        {
            Mage mage = new Mage();
            mage.Mana = 100;
            mage.Health = 100;
            Warrior warrior = new Warrior();
            warrior.Strength = 50;
            warrior.Health = 100;
            Console.WriteLine($"Mage attacks with power: {mage.Attack()}, the warrior has {warrior.Health - mage.Attack()} health left");
            Console.WriteLine($"Warrior attacks with power: {warrior.Attack()}, the mage has {mage.Health - warrior.Attack()} health left");
            Console.WriteLine("The Warrior wins");

        }
    }
}
