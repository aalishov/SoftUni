using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Oscars_ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int loan = int.Parse(Console.ReadLine());
            double statuettes = loan * 0.7;
            double catering = statuettes * 0.85;
            double sounding = catering * 0.5;
            double costs = loan + statuettes + catering + sounding;
            Console.WriteLine($"{costs:f2}");
        }
    }
}
