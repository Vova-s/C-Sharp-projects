using System;
using static System.Console;
using System.Collections.Generic;

namespace FoodExpirationSimulatorByStatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product bread = new Product("Bread", 4);
            Product Milk = new Product("Milk", 0);
            Product sausege = new Product("Sausage", 3);
            bread.Eat();
            Milk.Eat();
            Milk.Eat();
            sausege.Eat();

        }
    }
    public class Product
    {
        public string name;
        public int daysToExpire;
        public Status status = new Healthy();
        public List<Product> allFood = new List<Product>();
        public Product(string name, int daysToExpire)
        {
            this.name = name;
            this.daysToExpire = daysToExpire;
            allFood.Add(this);
            Console.WriteLine($"{name} has been successfully added.");
        }
        public void Eat()
        {
            if (allFood.Contains(this))
            {
                status.Eat(this);
            }
            else
            {
                Console.WriteLine($"There is no {name} in the fridge.");
            }
        }
    }
    public interface Status
    {
        public void Eat(Product product);
    }
    public class Healthy : Status
    {
        public void Eat(Product product)
        {
            if (product.daysToExpire > 0)
            {
                Console.WriteLine($"{product.name} is safe to eat.It expires in {product.daysToExpire} day(s)");

                product.daysToExpire--;
            }
            else
            {
                product.status = new Harmful();
            }
        }
    }
    public class Harmful : Status
    {
        public void Eat(Product product)

        {
            WriteLine($"{product.name} has expired. If you eat, you will die soon.\nEat it anyway ? ");
            if (ReadLine() == "yes")
            {
                Write("You're dead.");
                Environment.Exit(0);
            }
            else
            {
                product.allFood.Remove(product);
                WriteLine($"{product.name} has been successfully thrown away.");
            }
        }
    }
}