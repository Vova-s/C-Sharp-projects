using System;
using static System.Console;

namespace NextDayCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("input day : "); int day = int.Parse(ReadLine());
            Write("input month : "); int month = int.Parse(ReadLine());
            Write("input year : "); int year = int.Parse(ReadLine());
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            {
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    if (day == 31)
                    {
                        if (month == 12)
                        {
                            day = 1;
                            month = 1;
                            year += 1;
                            WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                        }
                        else
                        {
                            day = 1;
                            month += 1;
                            WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                        }
                    }
                    else
                    {
                        day += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                    }

                }
                else if (month == 2)
                {
                    if (day == 29)
                    {
                        day = 1;
                        month += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);

                    }
                    else
                    {
                        day += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                    }

                }
                else
                {
                    if (day == 30)
                    {
                        day = 1;
                        month += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);

                    }
                    else
                    {
                        day += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                    }
                }
            }
            else
            {
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {


                    if (day == 31)
                    {
                        if (month == 12)
                        {
                            day = 1;
                            month = 1;
                            year += 1;
                            WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                        }
                        else
                        {
                            day = 1;
                            month += 1;
                            WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                        }
                    }
                    else
                    {
                        day += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                    }

                }
                else if (month == 2)
                {
                    if (day > 28 || day <= 0)
                    {
                        WriteLine("error");
                    }
                    else
                    {

                        if (day == 28)
                        {
                            day = 1;
                            month += 1;
                            WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);

                        }
                        else
                        {
                            day += 1;
                            WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                        }
                    }
                }
                else
                {

                    if (day == 30)
                    {
                        day = 1;
                        month += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);

                    }
                    else
                    {
                        day += 1;
                        WriteLine("day :" + day + "\n" + "month : " + month + "\n" + "year : " + year);
                    }
                }

            }
        }
    }
}