using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    abstract public class IBuilder
    {
        protected Computer computer = new Computer();
        public abstract void CPU();
        public abstract void GPU();
        public abstract void PSU();
        public abstract void RAM();
        public abstract void MotherBoard();
        public abstract void HDD();
        public abstract void SSD();
        public abstract void Cooler();
        public abstract void Case();
        public void Result() 
        {
            computer.GetResult();
        }
    }
}
