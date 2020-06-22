using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 0;
            decimal sum = 0;
            while (n>k)
            {
                decimal withdraw = decimal.Parse(Console.ReadLine());
                bool isPositive = sum + withdraw > 0;
                if (isPositive && withdraw>0)
                {
                    sum += withdraw;
                    Console.WriteLine($"Increase: {withdraw:f2}");
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                k++;
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
