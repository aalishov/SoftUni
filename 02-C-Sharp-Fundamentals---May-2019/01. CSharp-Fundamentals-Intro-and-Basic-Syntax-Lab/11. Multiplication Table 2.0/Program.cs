using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            if (f > 10)
            {
                Console.WriteLine($"{n} X {f} = {n * f}");
            }
            else
            {
                for (int i = f; i <= 10; i++)
                {
                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }

        }
    }
}
