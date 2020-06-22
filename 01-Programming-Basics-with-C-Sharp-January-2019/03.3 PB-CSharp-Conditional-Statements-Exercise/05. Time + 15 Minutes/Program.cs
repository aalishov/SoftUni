using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinute = int.Parse(Console.ReadLine());

            int boolMinute = startMinute + 15;
            if (boolMinute > 59)
            {
                int newMinute = boolMinute % 60;
                if (newMinute>9)
                {
                    if (startHour + 1 >= 24)
                    {
                        Console.WriteLine($"0:{newMinute}");
                    }
                    else
                    {
                        Console.WriteLine($"{startHour + 1}:{newMinute}");
                    }
                }
                else
                {
                    if (startHour + 1 >= 24)
                    {
                        Console.WriteLine($"0:0{newMinute}");
                    }
                    else
                    {
                        Console.WriteLine($"{startHour + 1}:0{newMinute}");
                    }
                }
               
            }
            else
            {
                Console.WriteLine($"{startHour}:{boolMinute}");
            }
        }
    }
}
