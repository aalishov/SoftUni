using System;

class Program
{
    static void Main(string[] args)
    {
        int divider = 1;
        int num = int.Parse(Console.ReadLine());
        if (num%2==0)
        {
            divider = 2;
        }
        if (num%3==0)
        {
            divider = 3;
        }
        if (num % 6 == 0)
        {
            divider = 6;
        }
        if (num % 7 == 0)
        {
            divider = 7;
        }
        if (num % 10 == 0)
        {
            divider = 10;
        }
        if (divider!=1)
        {
            Console.WriteLine($"The number is divisible by {divider}");
        }
        else
        {
            Console.WriteLine("Not divisible");
        }
       
    }
}

