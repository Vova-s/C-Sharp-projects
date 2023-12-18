using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetMotherboard:ComponentsPC
    {
        private int MemorySlots;
        private string FormFactor;
        private string Chipset;
        private string ModelName;

        public SetMotherboard(string modelname, int MemorySlots, string formfactor, string chipset, double price)

        {
            this.MemorySlots = MemorySlots;
            this.FormFactor = formfactor;
            this.Chipset = chipset;
            this.ModelName = modelname;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("Motherboard:");
            Console.WriteLine($"\t Model name : {ModelName}\n" + $"\tMemory Slots: {MemorySlots}\t Formfactor: {FormFactor}\n\t Chipset: {Chipset}" + $"\n\t price: {Price}$");
        }

    }
}
