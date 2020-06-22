using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Stack<int> box = new Stack<int>(Console
            .ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        int rackCounter = 1;
                
        int rackCapacity = int.Parse(Console.ReadLine());
        int currentRackCapacity = 0;

        while (box.Any())
        {
            currentRackCapacity += box.Peek();
            if (currentRackCapacity  <= rackCapacity)
            {
               box.Pop();
            }
            else
            {
                rackCounter++;
                currentRackCapacity = 0;
            }
        }
        Console.WriteLine(rackCounter);
    }
}


