using System;

namespace _05._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int target= 10_000;
            string line = Console.ReadLine();
            int steps = 0;
            
            while (line!= "Going home" || steps>=10_000)
            {
                int num = int.Parse(line);
                steps += num;                
                if (steps >= target)
                {                    
                    Console.WriteLine($"Goal reached! Good job!");
                    break;
                }
                line = Console.ReadLine();
            }
            if(steps<target)
            {
                steps += int.Parse(Console.ReadLine());
                if (steps >= target)
                {
                    Console.WriteLine($"Goal reached! Good job!");
                    
                }
                else
                {
                    Console.WriteLine($"{target - steps} more steps to reach goal.");
                }                
            }

        }
    }
}
