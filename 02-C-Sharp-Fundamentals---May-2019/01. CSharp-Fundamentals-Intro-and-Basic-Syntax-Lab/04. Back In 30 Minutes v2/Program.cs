using System;

namespace _04._Back_In_30_Minutes_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            if (minutes+30>59)
            {
                if (hours+1>=24)
                {
                    hours = 0;
                }
                else
                {
                    hours++;
                }                
                minutes = minutes + 30 - 60;
            }
            else
            {
                minutes += 30;
            }
            if (minutes>9)
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            
        }
    }
}
