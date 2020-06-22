using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
        while (true)
        {
            string[] cmd = Console.ReadLine().Split(' ');
            if (cmd[0] == "end")
            {
                break;
            }
            if (cmd[0] == "Insert")
            {
                int index = int.Parse(cmd[2]);
                int element = int.Parse(cmd[1]);
                input.Insert(index, element);
            }
            else
            {
                int element = int.Parse(cmd[1]);
                input.RemoveAll(x => x == element);
            }
        }
        Console.WriteLine(string.Join(" ", input));
    }
}

