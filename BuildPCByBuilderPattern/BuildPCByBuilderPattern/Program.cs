using System;

namespace Lab4_sem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();
            IBuilder builder1 = new LowPriceCategory();
            creator.buildComputer(builder1);
        }
    }
}
