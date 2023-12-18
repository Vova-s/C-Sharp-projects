using System;
using static System.Console;
using static System.Math; 

namespace MathematicalExpressionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("input x: "); double x = Convert.ToDouble(ReadLine());
            Write("input y: "); double y = Convert.ToDouble(ReadLine());
            Write("input z: "); double z = Convert.ToDouble(ReadLine());
            double zn, ch, n, m, a, b;
            ch = x * y * z;
            if (ch != 0)
            {
                if ((2 * ch) % 180 != 0)
                {
                    zn = Sin((2 * ch * PI) / 180);
                    a = ch / zn;
                    WriteLine("a = " + a);
                    m = a + x * y;
                    if (m > 0)
                    {
                        n = Pow(Log(m), 1.0 / 3);
                        if (n != Pow(a, 4))
                        {
                            b = 1.0 / (Pow(a, 4) + n);
                            WriteLine("b = " + b);
                        }
                        else
                        {
                            WriteLine("Error");
                        }
                    }
                    else
                    {
                        WriteLine("Error");
                    }
                }
                else
                {
                    WriteLine("Error");
                }
            }
            else
            {
                WriteLine("Error");
            }
        }
    }
}
