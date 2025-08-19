using InterfacesTasks.Interfaces;

namespace InterfacesTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Payment Interface
            Payments();

            // Task 2: Docomentations Interface
            Docomentations();

            // Task 3: Vehicle Interface
            Vehicles();

            // Task 4: Animal noises
            Animals();

            // Task 5: RPG weaponsystem
            RPGGame();
        }

        public static void Payments()
        {
            PayPalPayment payPalPayment = new PayPalPayment();
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            payPalPayment.ProcessPayment(1000);
            creditCardPayment.ProcessPayment(2000);
        }

        public static void Docomentations()
        {
            Invoice invoice = new Invoice();
            invoice.Print();
            Report report = new Report();
            report.Print();
            Letter letter = new Letter();
            letter.Print();
        }

        public static void Vehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car(),
                new Motorcycle()
            };
            Car car = new Car();
            car.Start();
            Motorcycle motorcycle = new Motorcycle();
            motorcycle.Start();
        }

        public static void Animals()
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            Cow cow = new Cow();
            dog.MakeSound();
            cat.MakeSound();
            cow.MakeSound();
        }

        public static void RPGGame()
        {
            Sword sword = new Sword();
            Console.WriteLine("Your sword does {0}", sword.AttackDamage);
            sword.Upgrade();
            Console.WriteLine("After upgrading your sword, it now does {0} damage", sword.AttackDamage);
            Bow bow = new Bow();
            Console.WriteLine("Your Bow does between 5 and 15 damage");
            bow.Upgrade();
            Console.WriteLine("After upgrading your bow, it now does 15 damage");
            Staff staff = new Staff();
            Console.WriteLine("Your sword does {0}", staff.MagicPower);
            staff.Upgrade();
            Console.WriteLine("After upgrading your staff, it now does {0} damage", staff.MagicPower);
        }
    }
}
