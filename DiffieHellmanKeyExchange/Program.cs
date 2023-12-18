using System;
using static System.Console;

namespace DiffieHellmanKeyExchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            ulong prime = CreatePrime();
            WriteLine("prime number: " + prime);
            int global = rnd.Next(2, 100);
            WriteLine("public number: " + global);
            int private_a = rnd.Next(2, 150);
            int private_b = rnd.Next(2, 200);
            long person1X = (long)System.Numerics.BigInteger.ModPow(global, private_a, prime);
            long person2Y = (long)System.Numerics.BigInteger.ModPow(global, private_b, prime);
            long secret_1 = diffie_person1(prime, global, private_a, person2Y);
            long secret_2 = diffie_person1(prime, global, private_b, person1X);
            WriteLine("secret key 1 : " + secret_1);
            WriteLine("secret key 2 : " + secret_2);
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
        public static long diffie_person1(ulong prime, int g, int private_a, long person2Y)
        {

            long secret1 = (long)System.Numerics.BigInteger.ModPow(person2Y, private_a, prime);
            return secret1;
        }
        public static long diffie_person2(ulong prime, int g, int private_b, long person1X)
        {

            long secret2 = (long)System.Numerics.BigInteger.ModPow(person1X, private_b, prime);
            return secret2;
        }
    }
}
