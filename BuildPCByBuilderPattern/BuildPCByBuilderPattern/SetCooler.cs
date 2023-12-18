using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetCooler:ComponentsPC
    {
        private int MaximalSpeed;
        private string Socket;
        private string ModelName;

        public SetCooler(string modelname, string socket, int maximalspeed, double price)

        {
            this.ModelName = modelname;
            this.MaximalSpeed = maximalspeed;
            this.Socket = socket;
            Price = price;
        }
        public override void Characteristic()
        {
            Console.WriteLine("Cooler:");
            Console.WriteLine($"\t Model name : {ModelName}\n" + $"\tMaximal Speed: {MaximalSpeed}RPM\t \n\t Socket: {Socket}" + $"\n\t Price: {Price}$");
        }
    }
}
