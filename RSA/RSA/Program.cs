using System;
using static System.Console;
using System.Collections.Generic;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            long p = CreatePrime();
            long q = CreatePrime();
            long n = p * q;
            long fi = (p - 1) * (q - 1);
            long e = CreatePrimeE(fi);
            long d = Euclid(e, fi);
            string decoded = "";
            Write("input text : "); string text = ReadLine();
            
            for (int i = 0; i < text.Length; i++)
            {
                int M = (int)text[i];
                long c = ModPow(M, e, n);
                Write($"({c}) ");
                long m1 = ModPow(c, d, n);
                decoded +=(char) m1;
                
            }
            WriteLine();
            Write(decoded);

        }
        public static long Pow(long a, long n, long k,long r) 
        {
            long ax = n & 0x01;
            long res = 0;
            if (n == 0)
            {
                res = r;
            }
            else if (ax == 1)
            {
               res = Pow((a * a) % k, n >> 1, k, (r * a) % k);
            }
            else 
            {
               res = Pow((a * a) % k, n >> 1, k, r);
            }
            return res;
        }

        public static long ModPow(long a, long n, long k) 
        {
            long res = Pow(a, n, k, 1);
            return res;
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
            return pCurr ;
        }
        public static long CreatePrime()
        {
            Random rnd = new Random();
            long prime = (long)rnd.Next(100, 10000);
            prime += 1 - (prime % 2);
            long sqrt = (long)Math.Ceiling(Math.Sqrt(Convert.ToDouble(prime)));
            bool cnt;
            do
            {
                cnt = true;
                for (long i = 3; i <= sqrt; i += 2)
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
        public static long CreatePrimeE(long fi)
        {
            Random rnd = new Random();
            long prime = (long)rnd.Next(1, (int)fi);
            prime += 1 - (prime % 2);
            long sqrt = (long)Math.Ceiling(Math.Sqrt(Convert.ToDouble(prime)));
            bool cnt;
            do
            {
                cnt = true;
                for (long i = 3; i <= sqrt; i += 2)
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
    }
}
