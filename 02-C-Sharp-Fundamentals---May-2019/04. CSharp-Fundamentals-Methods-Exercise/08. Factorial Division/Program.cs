using System;
using System.Numerics;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = Factorial(BigInteger.Parse(Console.ReadLine()));
            double b = Factorial(BigInteger.Parse(Console.ReadLine()));
            double result = a/ b;
            Console.WriteLine($"{result:f2}");
        }
        public static double Factorial(BigInteger a)
        {
            BigInteger result = 1;
            if (a == 0)
            {
                return 1;
            }
            else
            {
                for (BigInteger i = 1; i <= a; i++)
                {
                    result = BigInteger.Multiply(result, i);
                }
                return (double)result;
            }
        }
    }
}
