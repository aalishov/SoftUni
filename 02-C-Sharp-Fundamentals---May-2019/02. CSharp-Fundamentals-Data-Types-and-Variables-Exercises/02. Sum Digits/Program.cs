using System;
using System.Linq;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int sum = line.ToCharArray().Select(x => int.Parse(x.ToString())).Sum();
            Console.WriteLine(sum);
        }
    }
}
