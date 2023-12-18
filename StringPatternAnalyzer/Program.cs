namespace StringPatternAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Input : "); string a = Convert.ToString(ReadLine());
            int len1 = a.Length;
            string n = string.Empty;
            int s1 = 0;
            int s = 0;
            WriteLine("*************** A ***************");
            for (int i = 2; i < len1; i++)
            {
                n = "" + a[i - 2] + a[i - 1] + a[i];
                if (n.Contains("abc"))
                {
                    s++;
                }
            }
            WriteLine("s" + s);
            WriteLine("*************** B ***************");
            for (int i = 2; i < len1; i++)
            {
                n = "" + a[i - 2] + a[i - 1] + a[i];
                if (n.Contains("aba"))
                {
                    s1++;
                }
            }
            WriteLine("s" + s1);
        }
    }
}