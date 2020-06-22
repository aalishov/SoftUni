using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            HashSet<int> uniqueN = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                nums.Add(int.Parse(line));
                uniqueN.Add(int.Parse(line));
            }
            foreach (var num in uniqueN)
            {
                if (nums.Count(x=>x==num)%2==0)
                {
                    Console.WriteLine(num);
                    break;
                }
            }
        }
    }
}
