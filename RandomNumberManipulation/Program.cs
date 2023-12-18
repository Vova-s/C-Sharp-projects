namespace RandomNumberManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            double b, a, sum;
            sum = 0;
            Random rnd = new Random();
            Write("n : "); int n = int.Parse(ReadLine());
            for (int i = 1; i <= n; i++)
            {
                a = rnd.Next(-100, 100) + rnd.NextDouble();
                WriteLine($"a[{i}] {a}");
                sum += a;
                b = a / (1.0 + (sum * sum));
                WriteLine($"b[{i}] {b}");
            }
        }
    }
}