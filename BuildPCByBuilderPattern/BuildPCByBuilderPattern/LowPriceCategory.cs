using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class LowPriceCategory:IBuilder
    {
        public override void CPU()
        {
            computer.ADD(new SetCPU ("Intel  Core i3-12100F", 4, 8, 4.2, 12,4444));
        }
        public override void GPU()
        {
            computer.ADD(new SetGPU("MSI GeFOrce GTX 1630", 4,64, 300, 7505));
        }
        public override void MotherBoard()
        {
            computer.ADD(new SetMotherboard("Asus Rog Stix", 4, "mini", "1151", 3000));
        }
        public override void PSU()
        {
            computer.ADD(new SetPSU("Cooler Master", 4, "mini", "water", 2500));
        }
        public override void RAM()
        {
            computer.ADD(new SetRAM("HyperX Fury", 8, 3200, "DDR4", 3000));
        }
        public override void HDD()
        {
            computer.ADD(new SetHDD("Samsung", 1000, "in", 3000));
        }
        public override void SSD()
        {
            computer.ADD(new SetSSD("Hyperx", 2000, "in", 5000));
        }
        public override void Case()
        {
            computer.ADD(new SetCase("DeepCool", 5000));
        }
        public override void Cooler()
        {
            computer.ADD(new SetCooler("Cooler master","socket",3200, 5000));
        }
    }
}
