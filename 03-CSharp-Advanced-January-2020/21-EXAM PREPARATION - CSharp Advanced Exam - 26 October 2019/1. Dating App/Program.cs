using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Stack<int> male = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        Queue<int> female = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        int matches = 0;

        while (female.Count > 0)
        {
            if (female.Peek() <= 0)
            {
                female.Dequeue();
                continue;
            }
            if (female.Peek() % 25 == 0)
            {
                female.Dequeue();
                female.Dequeue();
                continue;
            }
            if (male.Count > 0)
            {
                if (male.Peek() <= 0)
                {
                    male.Pop();
                    continue;
                }
                if (male.Peek() % 25 == 0)
                {
                    male.Pop();
                    male.Pop();
                    continue;
                }
                if (male.Peek() == female.Peek())
                {
                    male.Pop();
                    female.Dequeue();
                    matches++;
                }
                else
                {
                    female.Dequeue();
                    if (male.Peek() - 2 > 0)
                    {
                        int maleN = male.Pop() - 2;
                        male.Push(maleN);
                    }
                    else
                    {
                        male.Pop();
                    }
                }
            }
            else
            {
                break;
            }
        }
        Console.WriteLine($"Matches: {matches}");
        if (male.Count > 0)
        {
            Console.WriteLine($"Males left: {string.Join(", ", male)}");
        }
        else
        {
            Console.WriteLine("Males left: none");
        }
        if (female.Count > 0)
        {
            Console.WriteLine($"Females left: {string.Join(", ", female)}");
        }
        else
        {
            Console.WriteLine("Females left: none");
        }
    }
}
