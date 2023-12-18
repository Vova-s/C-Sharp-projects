using System;
using System.Threading;


namespace VehicleManagementSystem
{
    public class Buyer : Person
    {
        private double Balance { get; set; }
        public Car car { get; private set; }

        public override void printFullInfo()
        {
            Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nAge: {Age}\nBalance: {Balance}\n");
        }

        public void takeMoney(double money)
        {
            Balance += money;
        }

        public void checkBalance()
        {
            Console.WriteLine(Balance);
        }

        public void buyCar(Car car)
        {
            if (Balance < car.Price)
                Console.WriteLine("Insufficient funds to buy this car");
            else
            {
                this.car = car;
                Balance -= car.Price;
                Car.setOwner(car, this);
            }
        }
    }

    public abstract class Transport
    {
        public int MaxSpeed { get; protected set; }
        public float Price { get; protected set; }

        public Transport(int maxSpeed, float price)
        {
            Console.WriteLine("Called public constructor of the abstract class Transport");

            if (price <= 0)
            {
                Console.WriteLine("Price cannot be <= 0");
                return;
            }
            MaxSpeed = maxSpeed;
            Price = price;
        }
    }

    public class Car : Transport
    {
        public Drive Drive { get; protected set; }
        public Person Owner { get; protected set; }

        public Car(Drive drive, int maxSpeed, float price) : base(maxSpeed, price)
        {
            Console.WriteLine("Called public constructor of the abstract class Car");

            Drive = drive;
        }

        public static void setOwner(Car car, Person person)
        {
            car.Owner = person;
        }

        public Transmission Transmission { get; set; }
        public double Mileage { get; set; }
        public double AccelerationInSec { get; set; }
        public double PowerkW { get; set; }
    }

    public enum Drive
    {
        frontwheel,
        rear,
        fourwheel
    }

    public enum Transmission
    {
        mechanical,
        machine
    }

    public class CarICE : Car
    {
        public static DateTime datecreationfirstCarICE { get; private set; }
        public byte Enginecapacity { get; private set; }
        public Fuel Fuel { get; private set; }

        public CarICE(byte Enginecapacity, Fuel fuel, Drive drive, int maxSpeed, float price) : base(drive, maxSpeed, price)
        {
            Console.WriteLine("Called public constructor of CarICE");
            this.Enginecapacity = Enginecapacity;
            Fuel = fuel;
        }

        static CarICE()
        {
            datecreationfirstCarICE = DateTime.Now;
            Console.WriteLine("Called static constructor of CarICE, date of the first ICE car creation " + datecreationfirstCarICE.ToShortDateString());
        }
    }

    public enum Fuel
    {
        Gas,
        Gasoline,
        Diesel
    }

    public class ElectricCar : Car, IDisposable
    {
        public static int numbercars = 10000;

        private bool disposed = false;

        public ushort PowerReserve { get; private set; }
        public ushort ChargingTimeInHour { get; private set; }

        private ElectricCar(ushort powerReserve, ushort chargingTimeInHour, Drive drive, int maxSpeed, float price) : base(drive, maxSpeed, price)
        {
            Console.WriteLine("Called private constructor of ElectricCar, a new electric car is created, number of available cars = " + numbercars);
            PowerReserve = powerReserve;
            ChargingTimeInHour = chargingTimeInHour;
            numbercars--;
        }

        public static ElectricCar createElectricCar(ushort powerReserve, ushort chargingTimeInHour, Drive drive, int maxSpeed, float price)
        {
            if (numbercars == 0)
            {
                Console.WriteLine("Cannot create more ElectricCars");
                return null;
            }
            else if (price <= 0)
            {
                Console.WriteLine("Price cannot be <= 0");
                return null;
            }
            return new ElectricCar(powerReserve, chargingTimeInHour, drive, maxSpeed, price);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                Console.WriteLine("Releasing managed resources in base class");
                numbercars++;
                PowerReserve = 0;
                ChargingTimeInHour = 0;
                Owner = null;
                MaxSpeed = 0;
                Price = 0;
                Drive = default;
            }

            disposed = true;
        }

        ~ElectricCar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Destructor of ElectricCar class is called");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(10);
            Dispose(false);
        }
    }

    public class Person
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }

        private byte age;
        public byte Age
        {
            get => age;

            set
            {
                if (value < 0)
                    throw new Exception("Age cannot be < 0");
                age = value;
            }
        }

        public Person()
        {
            Console.WriteLine("Called default constructor - without parameters");
        }

        public virtual void printFullInfo()
        {
            Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nAge: {Age}");
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetSurname(string Surname)
        {
            this.Surname = Surname;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a Person
            Person person = new Person();
            person.SetName("John");
            person.SetSurname("Doe");
            person.Age = 30;

            // Print person's info
            person.printFullInfo();
            Console.WriteLine();

            // Create a CarICE
            CarICE carICE = new CarICE(150, Fuel.Gasoline, Drive.frontwheel, 180, 30000);

            // Create a Buyer
            Buyer buyer = new Buyer();
            buyer.SetName("Alice");
            buyer.SetSurname("Smith");
            buyer.Age = 25;

            // Print buyer's info
            buyer.printFullInfo();
            Console.WriteLine();

            // Buyer takes money
            buyer.takeMoney(40000);
            Console.WriteLine("Buyer's balance after taking money:");
            buyer.checkBalance();
            Console.WriteLine();

            // Buyer buys a car
            buyer.buyCar(carICE);

            // Print buyer's info after buying a car
            buyer.printFullInfo();
            Console.WriteLine("Buyer's balance after buying a car:");
            buyer.checkBalance();

            // Print car's info
            Console.WriteLine("Car Owner: " + carICE.Owner);
            Console.WriteLine();

            // Create an ElectricCar
            ElectricCar electricCar = ElectricCar.createElectricCar(250, 8, Drive.rear, 200, 35000);

            // Dispose the ElectricCar
            electricCar.Dispose();

            // Wait for a moment to see the destructor message
            Thread.Sleep(500);

            Console.WriteLine("\nEnd of program.");
        }
    }

}