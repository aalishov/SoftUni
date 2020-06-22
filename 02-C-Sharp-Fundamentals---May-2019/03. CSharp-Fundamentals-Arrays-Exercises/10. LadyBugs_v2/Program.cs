using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[] arr = new int[fieldSize];
        int[] ladyBugs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < ladyBugs.Length; i++)
        {
            if (ladyBugs[i]>=0&& ladyBugs[i]<fieldSize)
            {
                arr[ladyBugs[i]] = 1;
            }            
        }
        //Console.WriteLine(string.Join(' ', arr));
        while (true)
        {
            string[] line = Console.ReadLine().Split(' ').ToArray();
            if (line[0] == "end")
            {
                break;
            }
            int index = int.Parse(line[0]);
            string direction = line[1];
            int steps = int.Parse(line[2]);

            direction = CheckDirection(direction, steps);
            steps = Math.Abs(steps);
            if (index >= 0 && index < arr.Length)
            {
                switch (direction)
                {
                    case "left":
                        if (arr[index] == 1)
                        {
                            if (index - steps > 0)
                            {
                                int freePosition = index - steps;
                                if (arr[freePosition] == 1)
                                {
                                    for (int i = freePosition; i >= 0; i -= steps)
                                    {
                                        if (arr[i] == 0)
                                        {
                                            freePosition = i;
                                            break;
                                        }
                                    }
                                }
                                arr[freePosition] = 1;
                            }
                        }
                        arr[index] = 0;
                        //Console.WriteLine(string.Join(' ', arr));
                        break;
                    case "right":
                        if (arr[index] == 1)
                        {
                            if (index + steps < arr.Length)
                            {
                                int freePosition = index + steps;
                                if (arr[freePosition] == 1)
                                {
                                    for (int i = freePosition; i < arr.Length; i += steps)
                                    {
                                        if (arr[i] == 0)
                                        {
                                            freePosition = i;
                                            break;
                                        }
                                    }

                                }
                                arr[freePosition] = 1;
                            }
                        }
                        arr[index] = 0;
                        //Console.WriteLine(string.Join(' ', arr));
                        break;
                }
            }

        }
        Console.WriteLine(string.Join(' ', arr));
    }

    private static string CheckDirection(string direction, int steps)
    {
        if (steps < 0)
        {
            switch (direction)
            {
                case "left":
                    direction = "right";
                    break;
                case "right":
                    direction = "left";
                    break;
            }
        }

        return direction;
    }
}

