using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger num = BigInteger.Parse(Console.ReadLine());
        int mNum = int.Parse(Console.ReadLine());
        Console.WriteLine(BigInteger.Multiply(num,mNum));
    }
}
