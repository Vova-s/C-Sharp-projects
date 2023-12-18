using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetRAM : ComponentsPC
    {
        private int Capacity;
        private string MemoryType;
        private int Frequency;
        private string ModelName;

        public SetRAM(string modelname, int capacity, int frequency, string type, double price)

        {
            this.ModelName = modelname;
            this.Capacity = capacity;
            this.Frequency = frequency;
            this.MemoryType = type;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("RAM:");
            Console.WriteLine($"\t Model name : {ModelName}\n" + $"\tCapacity: {Capacity}GB\t Frequency: {Frequency}\n\t Memory Type: {MemoryType}" + $"\n\t price: {Price}$");
        }
    }
}
