using System;
using static System.Console;

namespace CleaningEquipmentFactorySystemByFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Cleaning factory: ");
            CleaningFactory factory = new DryCleaningFactory();
            factory.createManualCleaningHoover();
            factory = new DryandWetCleaningFactory();
            factory.createPortableCarHoover();

        }
    }
    public class PortableCarHoover
    {
    }
    public class ManualCleaningHoover
    {
    }
    public class RobotHoover
    {
    }
    public interface CleaningFactory
    {
        ManualCleaningHoover createManualCleaningHoover();
        PortableCarHoover createPortableCarHoover();
        RobotHoover createRobotHoover();
    }
    public class DryCleaningFactory : CleaningFactory
    {
        public DryCleaningFactory()
        {
            Console.WriteLine("\nProduction line has been changed to dry cleaning.");

        }
        public ManualCleaningHoover createManualCleaningHoover()
        {
            return new DryCleaningManualHoover();
        }
        public PortableCarHoover createPortableCarHoover()
        {
            return new DryCleaningPortableCarHoover();
        }
        public RobotHoover createRobotHoover()
        {
            return new DryCleaningRobotHoover();
        }
    }
    public class DryandWetCleaningFactory : CleaningFactory
    {
        public DryandWetCleaningFactory()
        {
            Console.WriteLine("\nProduction line has been changed to dry and wet cleaning.");

        }
        public ManualCleaningHoover createManualCleaningHoover()
        {
            return new DryWetCleaningManualHoover();
        }
        public PortableCarHoover createPortableCarHoover()
        {
            return new DryCleaningPortableCarHoover();
        }
        public RobotHoover createRobotHoover()
        {
            return new DryWetCleaningHoover();
        }
    }
    public class DryCleaningManualHoover : ManualCleaningHoover
    {
        public DryCleaningManualHoover()
        {
            Console.WriteLine("Manual cleaning hoover for dry cleaning has been created.");

        }
    }
    public class DryCleaningPortableCarHoover : PortableCarHoover
    {
        public DryCleaningPortableCarHoover()
        {
            Console.WriteLine("Portable car hoover for dry cleaning has been created.");

        }
    }
    public class DryCleaningRobotHoover : RobotHoover
    {
        public DryCleaningRobotHoover()
        {
            Console.WriteLine("Robot hoover for dry cleaning has been created.");
        }
    }
    public class DryWetCleaningManualHoover : ManualCleaningHoover
    {
        public DryWetCleaningManualHoover()

        {
            Console.WriteLine("Manual cleaning hoover for dry and wet cleaning has been created.");

        }
    }
    public class DryWetCleaningPortableCarHoover : PortableCarHoover
    {
        public DryWetCleaningPortableCarHoover()
        {
            Console.WriteLine("Portable car hoover for dry and wet cleaning has been created.");

        }
    }
    public class DryWetCleaningHoover : RobotHoover
    {
        public DryWetCleaningHoover()
        {
            Console.WriteLine("Robot hoover for dry and wet  cleaning has been created.");

        }
    }
}