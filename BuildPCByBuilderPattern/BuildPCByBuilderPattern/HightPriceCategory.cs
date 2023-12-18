using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class HightPriceCategory:IBuilder
    {
        public override void CPU()
        {
            computer.ADD(new SetCPU("AMD Ryzen 7 7800", 8, 16, 4.2, 96, 16399));
        }
        public override void GPU()
        {
            computer.ADD(new SetGPU("MSI GeFOrce GTX 4090TI", 24, 384, 1200, 87599));
        }
        public override void MotherBoard()
        {
            computer.ADD(new SetMotherboard("Asus Rog Stix", 8, "EATX", "LGA1700", 48833));
        }
        public override void PSU()
        {
            computer.ADD(new SetPSU("Asus ROG thor", 1600, "EATX", "Water", 35700));
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
            computer.ADD(new SetCooler("Cooler master", "socket", 3200, 5000));
        }
    }
}
