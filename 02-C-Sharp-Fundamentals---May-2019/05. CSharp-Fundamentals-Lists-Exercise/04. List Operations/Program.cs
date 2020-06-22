using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

        while (true)
        {
            string[] comands = Console.ReadLine().Split(' ');
            string cmd = comands[0];
            if (cmd == "End")
            {
                break;
            }
            switch (cmd)
            {
                case "Add":
                    list = Add(list, int.Parse(comands[1]));
                    break;
                case "Insert":
                    if (Check(int.Parse(comands[2]), list.Count))
                    {
                        list = Insert(list, int.Parse(comands[1]), int.Parse(comands[2]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;
                case "Remove":
                    if (Check(int.Parse(comands[1]), list.Count))
                    {
                        Remove(list, int.Parse(comands[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;
                case "Shift":
                    if ( int.Parse(comands[2])> list.Count)
                    {
                        list = Shift(list, comands[1], int.Parse(comands[2])%list.Count);
                    }
                    else
                    {
                        list = Shift(list, comands[1], int.Parse(comands[2]));
                    }
                   
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", list));

    }

    private static bool Check(int index, int count)
    {
        if (index < 0 || index >= count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static List<int> Shift(List<int> list, string direction, int count)
    {

        if (direction == "left")
        {
            var movedElement = list.Take(count).ToList();
            list.RemoveRange(0, count);
            list.AddRange(movedElement);
        }
        else
        {
            var movedElement = list.Take(list.Count - count).ToList();
            list.RemoveRange(0, list.Count - count);
            list.AddRange(movedElement);
        }
        return list;
    }

    private static List<int> Remove(List<int> list, int index)
    {
        list.RemoveAt(index);
        return list;
    }

    private static List<int> Insert(List<int> list, int number, int index)
    {
        list.Insert(index, number);
        return list;
    }

    private static List<int> Add(List<int> list, int number)
    {
        list.Add(number);
        return list;
    }
}

