using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeFirst = int.Parse(Console.ReadLine());
            int timeSecond = int.Parse(Console.ReadLine());
            int timeThird = int.Parse(Console.ReadLine());

            int totalTime = timeFirst + timeSecond + timeThird;

            int minutes = totalTime % 60;
            int hour = totalTime / 60;
            if (minutes>9)
            {
                Console.WriteLine($"{hour}:{minutes}");
            }
            else
            {
                Console.WriteLine($"{hour}:0{minutes}");
            }
        }
    }
}
