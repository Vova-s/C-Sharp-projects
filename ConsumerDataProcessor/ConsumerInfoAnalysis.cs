using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace ConsumerDataProcessor
{
    class main
    {
        static StreamWriter MyFileA;
        static Random rnd = new Random();
        static data gendata = new data();
        static void Main()
        {
            try
            {

                MyFileA = new StreamWriter("Rez_a.txt");


            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return;
            }

            Console.OutputEncoding = System.Text.Encoding.Default;
            List<consumers> cons = new List<consumers>();
            cons = CreateDB4consumers();
            Printconsumer(cons);
            sort(cons);
            MyFileA.Close();
        }
        static List<consumers> CreateDB4consumers()
        {
            DateTime date_credit = new DateTime(rnd.Next(2000, 2021), rnd.Next(12) + 1, rnd.Next(29) + 1, rnd.Next(9, 17), rnd.Next(60), rnd.Next(60));
            List<consumers> cons = new List<consumers>();
            for (byte i = 0; i < gendata.getNamesCount(); i++)
            {
                cons.Add(new consumers((byte)(i + 1), gendata.getSurname(i),
                   gendata.getName(i), gendata.getLast_Names(i), date_credit, rnd.Next(1000, 100000)));

            }
            return cons;
        }
        static void Printconsumer(List<consumers> ListOfcons)
        {
            foreach (consumers S in ListOfcons)
            {
                S.printconsumers();
                WriteLine();
            }
            WriteLine();
        }
        static void sort(List<consumers> cons)
        {
            double sum = 0;
            for (int i = 0; i < gendata.getNamesCount(); i++)
            {
                sum += cons[i].get_sum_loan();
            }
            double result = sum / gendata.getNamesCount();
            MyFileA.WriteLine("avg loan : " + result + " UAH ");
        }
    }
}