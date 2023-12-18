using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetPSU:ComponentsPC
    {
        private int OutputWattage;
        private string FormFactor;
        private string CoolingMethod;
        private string ModelName;

        public SetPSU(string modelname, int outputwattage, string formfactor, string coolingmethod, double price)

        {
            this.OutputWattage = outputwattage;
            this.FormFactor = formfactor;
            this.CoolingMethod = coolingmethod;
            this.ModelName = modelname;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("PSU:");
            Console.WriteLine($"\t Model name : {ModelName}\n" + $"\tOutput Wattage Slots: {OutputWattage}\n\t Formfactor: {FormFactor}\t" + $"\n\t price: {Price}$");
        }
    }
}
