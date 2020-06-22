using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> guests =new List<string>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length==3)
            {
                string guest = input[0];
                if (!guests.Contains(guest))
                {
                    guests.Add(guest);
                }
                else
                {
                    Console.WriteLine($"{guest} is already in the list!");
                }
            }
            else
            {
                string guest = input[0];
                if (guests.Contains(guest))
                {
                    guests.Remove(guest);
                }
                else
                {
                    Console.WriteLine($"{guest} is not in the list!" );
                }
            }
        }
        for (int i = 0; i < guests.Count; i++)
        {
            Console.WriteLine(guests[i]);
        };
    }
}

