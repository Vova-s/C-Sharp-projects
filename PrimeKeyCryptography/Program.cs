using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using static System.Console;

namespace PrimeKeyCryptography
{
    class Program
    {

        static void Main(string[] args)
        {
            ulong p = CreatePrime();
            WriteLine("p : " + p);
            ulong g = CreateG(p);
            WriteLine("g : " + g);
            ulong x = ChooseX(p);
            WriteLine("x : " + x);
            ulong y = CalculateY(x, p, g);
            ulong k = CalculateK(p);
            ulong a = CalculateA(g, p, k);
            WriteLine("y : " + y);
            WriteLine($"open key is =({p}, {g}, {y})");
            Write("Input text tot code : "); string text = ReadLine();
            long a1 = (long)a;
            long mod = (long)p;
            long rez = Euclid(a1, mod);
            Encoding(rez, y, p, g, text, k, a, x);
            WriteLine("rez : " + rez);


        }
        public static ulong CreatePrime()
        {
            Random rnd = new Random();
            ulong prime = (ulong)rnd.Next(100, 10000);
            prime += 1 - (prime % 2);
            ulong sqrt = (ulong)Math.Ceiling(Math.Sqrt(Convert.ToDouble(prime)));
            bool cnt;
            do
            {
                cnt = true;
                for (ulong i = 3; i <= sqrt; i += 2)
                    if (prime % i == 0)
                    {
                        cnt = false;
                        break;
                    }
                if (!cnt)
                    prime += 2;

            } while (!cnt);

            return prime;
        }
        public static ulong CreateG(ulong prime)
        {
            ulong primeN = prime;
            List<ulong> numbers = new List<ulong>();
            ulong g = new ulong();
            for (ulong i = 1; i < primeN; i++)
            {
                numbers.Clear();
                for (ulong j = 0; j < primeN - 1; j++)
                {
                    ulong PrS = (ulong)System.Numerics.BigInteger.ModPow(i, j, primeN);
                    numbers.Add(PrS);
                }
                List<ulong> CheckNumbers = numbers.Distinct().ToList();
                if (numbers.Count == CheckNumbers.Count)
                {
                    g = i;
                    break;
                }
            }
            return g;
        }
        public static ulong ChooseX(ulong prime)
        {
            Random rnd = new Random();
            ulong p = prime;
            ulong x = (ulong)rnd.Next(2, (int)p);
            return x;
        }
        public static ulong CalculateY(ulong x, ulong prime, ulong g)
        {
            ulong p = prime;
            ulong y = (ulong)BigInteger.ModPow(g, x, p);
            return y;
        }

        public static ulong CalculateA(ulong g, ulong prime, ulong k)
        {
            ulong p = prime;
            ulong a = (ulong)BigInteger.ModPow(g, k, p);
            return a;
        }
        public static ulong CalculateK(ulong prime)
        {
            Random rnd = new Random();
            ulong p = prime;
            ulong k = (ulong)rnd.Next(2, (int)p - 1);
            return k;
        }

        public static ulong Encoding(long rez, ulong y, ulong prime, ulong g, string text, ulong k, ulong a, ulong x)
        {
            Random rnd = new Random();
            List<ulong> calcB = new List<ulong>();
            ulong y1 = y;
            ulong p = prime;
            ulong g1 = g;
            ulong b = 0;
            string str = "";
            WriteLine("k : " + k);
            WriteLine("a : " + a);
            for (int i = 0; i < text.Length; i++)
            {

                int M = (int)text[i];
                b = (ulong)(BigInteger.ModPow(y, k, p) * M % p) % p;
                calcB.Add(b);
                WriteLine($"encoded text is : ({a}, {b})");
                ulong M1 = (ulong)(BigInteger.ModPow(rez, x, prime) * b % p) % p;
                char M2 = (char)M1;
                str += M2;
            }
            WriteLine("decoded text is : " + str);
            return b;
        }


        static long Euclid(long x, long mod)
        {
            long a = x, m = mod;
            List<long> q = new List<long>();
            while (m % a != 0)
            {
                q.Add(m / a);
                long tmp = m;
                m = a;
                a = tmp % a;
            }
            long pPrev = 0;
            long pCurr = 1;
            foreach (var el in q)
            {
                long pNew = -el * pCurr + pPrev;
                pPrev = pCurr;
                pCurr = pNew;
            }
            return pCurr;
        }

    }
}