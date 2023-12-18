using System.IO;
using System;
using static System.Console;

namespace FileAnalysisTool
{
    class Program
    {

        struct number
        {
            private int num;

            public number(int num)
            {
                this.num = num;
            }
            public int getNum => num;
            public void PrintToy(StreamWriter file)
            {
                file.Write($"{num,5}");
            }
            public void printToy()
            {
                Write($"{num,5}");
            }
        }
        static StreamReader Data;
        static StreamWriter MyFileA, MyFileB, MyFileC, MyFileD, MyFileE, MyFileF;
        static void Main(string[] args)
        {

            try
            {
                Data = new StreamReader("Data.txt");
                MyFileA = new StreamWriter("rez_a.txt");
                MyFileB = new StreamWriter("rez_b.txt");
                MyFileC = new StreamWriter("rez_c.txt");
                MyFileD = new StreamWriter("rez_d.txt");
                MyFileE = new StreamWriter("rez_e.txt");
                MyFileF = new StreamWriter("rez_f.txt");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return;
            }
            CheckDataLines();

            Data.Close();
            MyFileA.Close();
            MyFileB.Close();
            MyFileC.Close();
            MyFileD.Close();
            MyFileE.Close();
            MyFileF.Close();

            static void CheckDataLines()
            {

                while (!Data.EndOfStream)
                {

                    string[] Line = Data.ReadLine().Split(" ");
                    int i = 0;

                    for (i = 0; i < Line.Length; i++)
                    {
                        number n = new number(int.Parse(Line[i]));
                        n.printToy();

                        a(n); b(n); c(n); d(n);
                        bool intoNum;
                        intoNum = true;
                        for (int j = 0; j < i; j++)
                        {
                            if (Line[i] == Line[j])
                            {
                                intoNum = false;
                                break;
                            }
                        }
                        if (intoNum)
                        {
                            f(n);
                        }
                    }

                    for (i = 0; i <= Line.Length - 1; i++)
                    {
                        number n = new number(int.Parse(Line[Line.Length - 1 - i]));
                        e(n);
                    }




                }
                static void a(number n)
                {
                    if (n.getNum >= 0)
                    {
                        n.PrintToy(MyFileA);
                    }
                }
                static void b(number n)
                {
                    if (n.getNum % 2 == 0)
                    {
                        n.PrintToy(MyFileB);
                    }
                }
                static void c(number n)
                {
                    if (n.getNum % 3 == 0 && n.getNum % 5 == 0)
                    {
                        n.PrintToy(MyFileC);
                    }
                }
                static void d(number n)
                {
                    if (n.getNum >= 0 && (Math.Sqrt(n.getNum)) - Math.Truncate(Math.Sqrt(n.getNum)) == 0)
                    {
                        n.PrintToy(MyFileD);
                    }
                }
                static void e(number n)
                {

                    n.PrintToy(MyFileE);

                }
                static void f(number n)
                {
                    n.PrintToy(MyFileF);
                }
            }
        }
    }
}