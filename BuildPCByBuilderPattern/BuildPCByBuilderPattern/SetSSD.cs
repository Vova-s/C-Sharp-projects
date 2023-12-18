using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetSSD:ComponentsPC
    {
        private int Capacity;
        private string Type;
        private string ModelName;

        public SetSSD(string modelname, int capacity, string type, double price)

        {
            this.ModelName = modelname;
            this.Capacity = capacity;
            this.Type = type;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("SSD:");
            Console.WriteLine($"\t Model name : {ModelName}\n" + $"\tCapacity: {Capacity}GB\t \n\t Type: {Type}\n" + $"\t price: {Price}$");
        }
    }
}
