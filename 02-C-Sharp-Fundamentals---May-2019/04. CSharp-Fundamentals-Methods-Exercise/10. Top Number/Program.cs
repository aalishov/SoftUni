using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i <= n; i++)
        {
            string num = i.ToString();
            if (SumOfDigitsDivide8(num) && IsContainOddDigit(num))
            {
                Console.WriteLine(num);
            }
        }
    }
    private static bool SumOfDigitsDivide8(string num)
    {
        return num.ToCharArray().Select(x => int.Parse(x.ToString())).Sum() % 8 == 0;
    }
    private static bool IsContainOddDigit(string num)
    {
        var numbers = num.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 1)
            {
                return true;
            }
        }
        return false;
    }
}

