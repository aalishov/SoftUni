using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            SortedDictionary<char, int> word = new SortedDictionary<char, int>();

            foreach (var c in line)
            {
                if (!word.ContainsKey(c))
                {
                    word.Add(c, 0);
                }
                word[c]++;
            }

            foreach (var (key,value) in word)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
