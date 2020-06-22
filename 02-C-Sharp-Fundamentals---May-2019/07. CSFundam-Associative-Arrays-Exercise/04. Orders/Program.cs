using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Product> products = new Dictionary<string, Product>();
        string product = string.Empty;
        while ((product=Console.ReadLine())!="buy")
        {
            string[] info = product.Split(' ');
            string name = info[0];
            double price = double.Parse(info[1]);
            int quantity = int.Parse(info[2]);

            if (products.ContainsKey(name))
            {
                products[name].Quantity += quantity;
                products[name].Prices =price;
            }
            else
            {
                products.Add(name, new Product(name, price, quantity));
            }
        }
        foreach (var p in products)
        {
            Console.WriteLine(p.Value.ToString());
        }
    }
}
public class Product
{
    public string Name { get; set; }
    public double Prices { get; set; }
    public int Quantity { get; set; }
    public Product(string name, double price, int quantity)
    {
        Name = name;
        Prices = price;
        Quantity = quantity;
    }
    public override string ToString()
    {
        return string.Format($"{Name} -> {(Prices * Quantity):f2}");
    }
}

