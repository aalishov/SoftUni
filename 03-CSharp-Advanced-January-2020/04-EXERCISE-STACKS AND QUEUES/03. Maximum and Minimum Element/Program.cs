using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Stack<int> nums = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            int[] cmd = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            switch (cmd.First())
            {
                case 1:
                    nums.Push(cmd.Last());
                    break;
                case 2:
                    if (nums.Any())
                    {
                        nums.Pop();
                    }
                    break;
                case 3:
                    if (nums.Any())
                    {
                        Console.WriteLine(nums.ToArray().Max());
                    }                    
                    break;
                case 4:
                    if (nums.Any())
                    {
                        Console.WriteLine(nums.ToArray().Min());
                    }
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", nums.ToArray()));
    }
}

