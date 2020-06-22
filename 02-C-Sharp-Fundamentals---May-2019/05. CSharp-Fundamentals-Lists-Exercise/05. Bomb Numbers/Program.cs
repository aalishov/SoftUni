using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> nums = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
        int[] bomb = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int bombsCount = nums.Count(x => x == bomb[0]);
        
        Console.WriteLine(nums.Sum());
    }
}

