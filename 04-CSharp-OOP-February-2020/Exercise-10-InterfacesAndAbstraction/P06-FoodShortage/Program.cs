using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input.Length==4)
                {
                    buyers.Add(new Citizen() { Name = input[0] });
                }
                else
                {
                    buyers.Add(new Rebel() { Name = input[0] });
                }
            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name=="End")
                {
                    break;
                }
                if (buyers.Any(x=>x.Name==name))
                {
                    buyers.FirstOrDefault(x => x.Name == name).BuyFood();
                }
               
            }

            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
