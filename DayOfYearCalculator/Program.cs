namespace DayOfYearCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input day: ");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input month: ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int totalDays = 0;
            int daysLeft = 0;

            if (year > 0 && month > 0 && month <= 12 && day > 0 && day <= 31)
            {
                if (year % 4 == 0 && year % 100 == 0 && year % 400 != 0)
                {
                    if (month == 2 && day > 28)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        for (int i = 0; i < month - 1; i++)
                        {
                            totalDays += daysInMonth[i];
                        }
                        totalDays += day;

                        Console.WriteLine("This day is the " + totalDays + "th day of the year");
                        daysLeft = 365 - totalDays;
                        Console.WriteLine("Days left in the year: " + daysLeft);
                    }
                }
                else if (year % 4 == 0 || year % 400 == 0)
                {
                    if (month == 2 && day > 29)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine("dbcj"); // (Unclear, might want to remove or clarify this line)
                        int[] leapYearDaysInMonth = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                        for (int i = 0; i < month - 1; i++)
                        {
                            totalDays += leapYearDaysInMonth[i];
                        }
                        totalDays += day;

                        Console.WriteLine("This day is the " + totalDays + "th day of the year");
                        daysLeft = 366 - totalDays;
                        Console.WriteLine("Days left in the year: " + daysLeft);
                    }
                }
                else
                {
                    if (month == 2 && day > 28)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        for (int i = 0; i < month - 1; i++)
                        {
                            totalDays += daysInMonth[i];
                        }
                        totalDays += day;

                        Console.WriteLine("This day is the " + totalDays + "th day of the year");
                        daysLeft = 365 - totalDays;
                        Console.WriteLine("Days left in the year: " + daysLeft);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}