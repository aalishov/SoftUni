﻿using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int j = 0; j < line.Length; j++)
                {
                    elements.Add(line[j]);
                }
            }

            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
