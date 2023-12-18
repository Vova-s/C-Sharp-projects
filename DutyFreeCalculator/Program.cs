using System;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;


namespace DutyFreeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = Kata.DutyFree(17, 10, 500);
            Write(result);
        }

    }
    public class Kata
    {
        public static int DutyFree(int normPrice, int Discount, int hol)
        {
            double saving = (double)normPrice * Discount / 100;
            double needed = hol / saving;
            return (int)needed;
        }
    }
}