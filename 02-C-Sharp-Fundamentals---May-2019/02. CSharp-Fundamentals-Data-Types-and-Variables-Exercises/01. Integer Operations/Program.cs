using System;
using System.Numerics;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
            BigInteger thirdNum = BigInteger.Parse(Console.ReadLine());
            BigInteger forthNumber = BigInteger.Parse(Console.ReadLine());

            BigInteger result = ((firstNum + secondNum) / thirdNum) * forthNumber;
            Console.WriteLine(result);
        }
    }
}
