using System;
using System.Linq;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int[] strong = num.ToCharArray()
                .ToArray()
                .Select(x => int.Parse(x.ToString()))
                .ToArray();
            int sum = 0;
            for (int i = 0; i < strong.Length; i++)
            {
                sum += CalculateFactoriel(strong[i]);
            }
            if (int.Parse(num)==sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        public static int CalculateFactoriel(int num)
        {
            int result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
