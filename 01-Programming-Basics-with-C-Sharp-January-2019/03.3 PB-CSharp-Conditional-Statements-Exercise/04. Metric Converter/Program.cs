using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double value = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            if (input=="mm")
            {
                value /= 1000;
            }
            else if(input=="cm")
            {
                value /= 100;
            }

            if (output=="mm")
            {
                value *= 1000;
            }
            else if(output=="cm")
            {
                value *= 100;
            }
            Console.WriteLine($"{value:f3}");
           
        }
    }
}
