using System;

namespace _08._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * length * height;
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line=="Done")
                {
                    break;
                }
                freeSpace -= int.Parse(line);
                if (freeSpace<0)
                {
                    Console.WriteLine($"No more free space! You need {freeSpace} Cubic meters more.");
                }
            }
            if (freeSpace>=0)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
        }
    }
}
