using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class SetCPU:ComponentsPC
    {
        private string ModelCPU;
        private double Frequency;
        private double CacheSize;
        private int Cores;
        private int Threads;
        public SetCPU(string nameCPU, int cores, int threads, double frequency, int cacheSize, double price)

        {
            this.ModelCPU = nameCPU;
            this.Frequency = frequency;
            this.Cores = cores;
            this.Threads = threads;
            this.CacheSize = cacheSize;
            Price = price;
        }
        public override void Characteristic()
        {
           Console.WriteLine("CPU:");
           Console.WriteLine($"\t Model name: {ModelCPU}\n"+$"\tnumber of cores: {Cores}\n\tnumber of threads: {Threads}\n\tcore clock speed: { Frequency}Ghz\n" + $"\tl3 cache size: {CacheSize}Mb\n\tprice: {Price}$");
        }
    }
}
