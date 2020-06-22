using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            int num = 1;
            while (count<n)
            {
                if (num % 2 == 1)
                {
                    sum += num;
                    count++;
                    Console.WriteLine(num);
                }
                num++;
            }
                
                
            
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
