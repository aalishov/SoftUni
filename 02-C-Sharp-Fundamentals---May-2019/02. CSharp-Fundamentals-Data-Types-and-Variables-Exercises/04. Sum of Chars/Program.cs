using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < lines; i++)
        {
            sum += Console.ReadLine().ToCharArray().First();
        }
        Console.WriteLine($"The sum equals: {sum}");
    }
}

