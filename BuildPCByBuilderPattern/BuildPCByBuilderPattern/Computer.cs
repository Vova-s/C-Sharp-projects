using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab4_sem3
{
    public class Computer
    {
        public double FinalPrice;
        private List<ComponentsPC> components = new List<ComponentsPC>();
        public void ADD(ComponentsPC component) 
        {
            components.Add(component);
        }
        public void GetResult() 
        {
            WriteLine("******** Computer Parts ********\n");

            foreach (ComponentsPC component in components)
            {
                component.Characteristic();
                FinalPrice += component.Price;
            }

            WriteLine($"\n----------------------------------------\nTotal price: { FinalPrice}₴\n");
        }
    }
}
