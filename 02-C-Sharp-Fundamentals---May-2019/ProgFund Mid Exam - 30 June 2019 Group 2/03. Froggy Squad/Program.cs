using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> frogs = Console.ReadLine().Split(' ').ToList();

        string print = string.Empty; ;

        while (true)
        {
            string[] cmd = Console.ReadLine().Split(' ');
            if (cmd[0] == "Print")
            {
                print = cmd[1];
                break;
            }
            switch (cmd[0])
            {
                case "Join":
                    frogs.Add(cmd[1]);
                    break;
                case "Jump":
                    if (int.Parse(cmd[2])>0&& int.Parse(cmd[2])<frogs.Count)
                    {
                        frogs.Insert(int.Parse(cmd[2]), cmd[1]);
                    }                    
                    break;
                case "Dive":
                    if (int.Parse(cmd[1]) >= 0 && int.Parse(cmd[1]) < frogs.Count)
                    {
                        frogs.RemoveAt(int.Parse(cmd[1]));
                    }
                    break;
                case "First":
                    if (int.Parse(cmd[1]) > frogs.Count)
                    {
                        Console.WriteLine(string.Join(" ", frogs));
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", frogs.Take(int.Parse(cmd[1]))));
                    }
                    break;
                case "Last":
                    if (int.Parse(cmd[1]) > frogs.Count)
                    {
                        Console.WriteLine(string.Join(" ", frogs));
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", frogs.Skip(frogs.Count - int.Parse(cmd[1]))));
                    }
                    break;
            }
        }
        if (print == "Reversed")
        {
            frogs.Reverse();
            Console.WriteLine("Frogs: " + string.Join(" ", frogs));
        }
        else
        {
            Console.WriteLine("Frogs: " + string.Join(" ", frogs));
        }
    }
}

