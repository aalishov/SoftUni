using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    const int Glass = 25;
    const int Aluminium = 50;
    const int Lithium = 75;
    const int CarbonFiber = 100;

    private static int glassCount = 0;
    private static int aluminiumCount = 0;
    private static int lithiumCount = 0;
    private static int carbonFiberCount = 0;

    static void Main()
    {
        Queue<int> liquid = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        Stack<int> item = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

        MixedItem(liquid, item);

        Output(liquid, item);
    }

    private static void MixedItem(Queue<int> liquid, Stack<int> item)
    {
        while (liquid.Any() && item.Any())
        {
            int firstLiquid = liquid.Peek();
            int lastItem = item.Peek();

            int sum = firstLiquid + lastItem;

            switch (sum)
            {
                case Glass:
                    glassCount++;
                    CaseCreateMaterial(liquid, item);
                    break;
                case Aluminium:
                    aluminiumCount++;
                    CaseCreateMaterial(liquid, item);
                    break;
                case Lithium:
                    lithiumCount++;
                    CaseCreateMaterial(liquid, item);
                    break;
                case CarbonFiber:
                    carbonFiberCount++;
                    CaseCreateMaterial(liquid, item);
                    break;
                default:
                    CaseCreateMaterial(liquid, item);
                    lastItem += 3;
                    item.Push(lastItem);
                    break;
            }
        }
    }

    private static void Output(Queue<int> liquid, Stack<int> item)
    {
        PrintIsBuildSpaceship(glassCount, aluminiumCount, lithiumCount, carbonFiberCount);

        string liquidPrint = liquid.Count > 0 ? string.Join(", ", liquid) : "none";
        Console.WriteLine($"Liquids left: {liquidPrint}");
        string itemPrint = item.Count > 0 ? string.Join(", ", item) : "none";
        Console.WriteLine($"Physical items left: {itemPrint}");

        Console.WriteLine($"Aluminium: {aluminiumCount}");
        Console.WriteLine($"Carbon fiber: {carbonFiberCount}");
        Console.WriteLine($"Glass: {glassCount}");
        Console.WriteLine($"Lithium: {lithiumCount}");
    }

    private static void PrintIsBuildSpaceship(int glassCount, int aluminiumCount, int lithiumCount, int carbonFiberCount)
    {
        if (glassCount > 0 && aluminiumCount > 0 && lithiumCount > 0 && carbonFiberCount > 0)
        {
            Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
        }
        else
        {
            Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
        }
    }

    private static void CaseCreateMaterial(Queue<int> liquid, Stack<int> item)
    {
        liquid.Dequeue();
        item.Pop();
    }
}

