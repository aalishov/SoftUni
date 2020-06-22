using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<char, int> symbols = new Dictionary<char, int>();

        foreach (var c in line)
        {
            if (symbols.ContainsKey(c))
            {
                symbols[c]++;
            }
            else
            {
                symbols.Add(c, 1);
            }
        }

        if (symbols.ContainsKey(' '))
        {
            symbols.Remove(' ');
        }
        foreach (var c in symbols)
        {
            Console.WriteLine($"{c.Key} -> {c.Value}");
        }
    }
}

