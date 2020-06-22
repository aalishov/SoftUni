using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int food = int.Parse(Console.ReadLine());
        Queue<int> orders = new Queue<int>(Console
            .ReadLine()
            .Split(' ')
            .Select(int.Parse));
        Console.WriteLine(orders.ToArray().Max());

        while (orders.Any() && orders.Peek() <= food)
        {
            food -= orders.Dequeue();
        }

        if (!orders.Any())
        {
            Console.WriteLine("Orders complete");
        }
        else
        {
            Console.WriteLine($"Orders left: {string.Join(" ",orders.ToArray())}");
        }
    }
}

