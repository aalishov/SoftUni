using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double metres = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double secondsIvan = metres * timePerMeter;
            double delay = Math.Floor(metres / 15) * 12.5;
            double totalTime = secondsIvan + delay;
            if (totalTime<record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTime-record:f2} seconds slower.");
            }
        }
    }
}
