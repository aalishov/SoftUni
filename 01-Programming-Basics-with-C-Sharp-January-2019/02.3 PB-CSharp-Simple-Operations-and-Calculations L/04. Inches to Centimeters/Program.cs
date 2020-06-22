using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            const double inch = 2.54;
            double inches = double.Parse(Console.ReadLine());
            double centimeters = inches * inch;
            Console.WriteLine($"{centimeters:f2}");
        }
    }
}
