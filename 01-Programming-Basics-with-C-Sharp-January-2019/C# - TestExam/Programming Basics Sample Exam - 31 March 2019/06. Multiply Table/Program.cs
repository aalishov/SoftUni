using System;
using System.Linq;

namespace _06._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine().ToString().ToCharArray().Select(x=>int.Parse(x.ToString())).ToArray();

            int first =line[2];
            int second =line[1];
            int third =line[0];

            for (int i = 1; i <= first; i++)
            {
                for (int j = 1; j <= second; j++)
                {
                    for (int k = 1; k <= third; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i*j*k};");
                    }
                }
            }
        }
    }
}
