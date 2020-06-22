using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(MinNumber(a,b,c));
        }
        private static int MinNumber(int a, int b, int c)
        {
            int min = int.MaxValue;
            if (a<min)
            {
                min = a;
            }
            if (b<min)
            {
                min = b;
            }
            if (c<min)
            {
                min = c;
            }
            return min;
        }
    }
}
