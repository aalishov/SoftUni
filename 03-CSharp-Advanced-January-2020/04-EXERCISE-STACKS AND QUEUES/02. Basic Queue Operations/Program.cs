using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] line = Console.ReadLine().Split();
        int n = int.Parse(line[0]);
        int s = int.Parse(line[1]);
        int x = int.Parse(line[2]);

        Queue<int> num = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

        for (int i = 0; i < s; i++)
        {
            num.Dequeue();
        }

        bool isContainX = num.Contains(x);
        if (isContainX)
        {
            Console.WriteLine(isContainX.ToString().ToLower());
        }
        else
        {
            if (!num.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(num.ToList().Min());
            }
        }
    }
}

