using System;

class Program
{
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int days = 0;
        int total = 0;
        for (int i = start; i >= 100; i-=10)
        {
            days++;
            int add = i - 26;
            total += add;
        }
        Console.WriteLine(days);
        if (total>26)
        {
            Console.WriteLine(total - 26);
        }
        else
        {
            Console.WriteLine(total);
        }
        
    }
}

