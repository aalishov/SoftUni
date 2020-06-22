using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        string resourceName = string.Empty;
        Dictionary<string, int> resource = new Dictionary<string, int>();

        while ((resourceName = Console.ReadLine())!="stop")
        {
            int quantity = int.Parse(Console.ReadLine());
            if (resource.ContainsKey(resourceName))
            {
                resource[resourceName] += quantity;
            }
            else
            {
                resource.Add(resourceName, quantity);
            }
        }
        foreach (var r in resource)
        {
            Console.WriteLine($"{r.Key} -> {r.Value}");
        }
    }
}

