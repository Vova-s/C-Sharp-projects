using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetCase:ComponentsPC
    {
        private string ModelName;

        public SetCase(string modelname, double price)

        {
            this.ModelName = modelname;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("Case:");
            Console.WriteLine($"\t Model name : {ModelName}" + $"\n\t Price: {Price}$");
        }
    }
}
