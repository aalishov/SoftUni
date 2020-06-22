using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);
            HashSet<int> nNums = new HashSet<int>();
            HashSet<int> mNums = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                nNums.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                mNums.Add(int.Parse(Console.ReadLine()));
            }

            StringBuilder print = new StringBuilder();

            foreach (var num in nNums)
            {
                if (mNums.Contains(num))
                {
                    print.Append(num + " ");
                }
            }
            Console.WriteLine(print);
        }
    }
}
