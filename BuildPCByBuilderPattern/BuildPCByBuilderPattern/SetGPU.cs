using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetGPU:ComponentsPC
    {
        private int MemoryCapacity;
        private int BusWidth;
        private int TPD;
        private string ModelName;
        
        public SetGPU (string modelname, int memorycapacity, int buswidth, int tpd, double price)

        {
            this.ModelName = modelname;
            this.MemoryCapacity = memorycapacity;
            this.BusWidth = buswidth;  
            this.TPD = tpd;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("GPU:");
            Console.WriteLine($"\t Model name: {ModelName}\n" + $"\tMemory Capacity: {MemoryCapacity}Gb\n\tBus Width: {BusWidth}bit\n\tTPD: {TPD}W" + $"\n\tprice: {Price}$");
        }
    }
}
