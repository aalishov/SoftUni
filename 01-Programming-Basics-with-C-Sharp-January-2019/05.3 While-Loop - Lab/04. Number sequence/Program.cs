using System;

namespace _04._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            while (true)
            {
                string line = Console.ReadLine();
                if (line=="END")
                {
                    break;
                }
                int num = int.Parse(line);
                if (num > max)
                {
                    max = num;
                }
                if (num<min)
                {
                    min = num;
                }                
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
