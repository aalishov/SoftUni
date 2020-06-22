using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
        int maxCapacity = int.Parse(Console.ReadLine());
        while (true)
        {
            string[] cmd = Console.ReadLine().Split(' ');
            if (cmd[0]=="end")
            {
                break;
            }
            if (cmd[0]=="Add")
            {
                input.Add(int.Parse(cmd[1]));
            }
            else
            {
                int passenger = int.Parse(cmd[0]);
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i]+ passenger<=maxCapacity)
                    {
                        input[i] += passenger;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(string.Join(" ",input));

    }
}

