using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int fNum = int.Parse(Console.ReadLine());
            int lNum = int.Parse(Console.ReadLine());
            string s = string.Empty;
            int sum = 0;
            for (int i = fNum; i <= lNum; i++)
            {
                sum += i;
                s += string.Format($"{i} ");
            }
            Console.WriteLine(s);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
