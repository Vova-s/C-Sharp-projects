namespace FruitGardenSimulation
{
    public class WaterEventArgs : EventArgs
    {
        public int temperature;
        public int liters;

        public WaterEventArgs(int temperature, int liters)
        {
            this.temperature = temperature;
            this.liters = liters;
        }

        public WaterEventArgs() : this(0, 0) { }
    }


    #region Fruits section
    public abstract class Fruit
    {
        abstract public void GrowUp(Gardener g, WaterEventArgs wargs);
    }
    public class Apple : Fruit
    {
        public override void GrowUp(Gardener g, WaterEventArgs wargs)
        {
            Console.WriteLine("Apple is watering by " + g.name);
            if (wargs.temperature < 50)
                Console.WriteLine("Apple is growed up");
            else
                Console.WriteLine("Apple fells hot!!!");
        }
    }

    public class Plum : Fruit
    {
        public override void GrowUp(Gardener g, WaterEventArgs wargs)
        {
            Console.WriteLine("Plum is watering by " + g.name);
            if (wargs.temperature < 50)
                Console.WriteLine("Plum fells cold!!!");
            else
                Console.WriteLine("Plum is growed up");
        }
    }
    #endregion

    public delegate void WateringHandle(Gardener g, WaterEventArgs wargs);


    public class Gardener
    {
        public event WateringHandle GardnerWateringEvent;
        public string name;

        public Gardener(string name)
        {
            this.name = name;
        }

        public void Watering()
        {
            int t, l;
            WaterEventArgs wargs;
            try
            {
                Console.Write("Enter water temperature: ");
                t = Int32.Parse(Console.ReadLine());

                Console.Write("Enter liters amount: ");
                l = Int32.Parse(Console.ReadLine());
                wargs = new WaterEventArgs(t, l);
            }
            catch
            {
                wargs = new WaterEventArgs();
            }

            Console.WriteLine("Gardener {0} is watering fruits...\n", this.name);
            if (GardnerWateringEvent != null)
                GardnerWateringEvent((Gardener)this, wargs);
        }
    }

    class Garden
    {
        Fruit[] fruits;

        public Garden(Gardener gardener)
        {
            fruits = new Fruit[2];
            fruits[0] = new Apple();
            fruits[1] = new Plum();

            foreach (Fruit f in fruits)
                gardener.GardnerWateringEvent += new WateringHandle(f.GrowUp);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Gardener gardener = new Gardener("John");
            Garden gadren = new Garden(gardener);
            gardener.Watering();
            Console.ReadKey();
        }
    }
}