using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> gifts = Console.ReadLine().Split(' ').ToList();


        while (true)
        {
            List<string> commands = Console.ReadLine().Split(' ').ToList();
            if (commands[0]+" "+commands[1] == "No Money")
            {
                break;
            }
            switch (commands[0])
            {
                case "OutOfStock":
                    for (int i = 0; i < gifts.Count; i++)
                    {
                        if (gifts[i] == commands[1])
                        {
                            gifts[i] = "None";
                        }
                    }
                    break;
                case "Required":
                    if (int.Parse(commands[2]) > 0 && int.Parse(commands[2]) < gifts.Count)
                    {
                        gifts[int.Parse(commands[2])] = commands[1];
                    }
                    break;
                case "JustInCase":
                    gifts[gifts.Count - 1] = commands[1];
                    break;
            }

        }
        string print = string.Empty;
        for (int i = 0; i < gifts.Count; i++)
        {
            if (gifts[i] != "None")
            {
                print += gifts[i] + " ";
            }
        }
        Console.WriteLine(print);
    }
}

