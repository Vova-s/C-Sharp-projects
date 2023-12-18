using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_sem3
{
    public class Creator
    {
        public void buildComputer(IBuilder builder)
        {
            builder.CPU();
            builder.Cooler();
            builder.GPU();
            builder.PSU();
            builder.MotherBoard();
            builder.RAM();
            builder.HDD();
            builder.SSD();
            builder.Case();
            builder.Result();
        }
    }
}
