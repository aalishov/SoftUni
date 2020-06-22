using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        const int DollMagicNeeded = 150;
        const int WoodenTrainMagicNeeded = 250;
        const int TeddyBearMagicNeeded = 300;
        const int BicycleMagicNeeded = 400;

        SortedDictionary<string, int> toys = new SortedDictionary<string, int>();
        toys.Add("Doll", 0);
        toys.Add("Wooden train", 0);
        toys.Add("Teddy bear", 0);
        toys.Add("Bicycle", 0);

        List<int> magicNeeded = new List<int> { DollMagicNeeded, WoodenTrainMagicNeeded, TeddyBearMagicNeeded, BicycleMagicNeeded };

        Stack<int> materials = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        Queue<int> magicValue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));

        while (materials.Any() && magicValue.Any())
        {
            int lastMaterials = materials.Peek();
            int firstMagicValue = magicValue.Peek();
            if (lastMaterials == 0)
            {
                materials.Pop();
            }
            if (firstMagicValue == 0)
            {
                magicValue.Dequeue();
                continue;
            }
            int totalMagicValue = firstMagicValue * lastMaterials;

            if (magicNeeded.Contains(totalMagicValue))
            {
                switch (totalMagicValue)
                {
                    case 150:
                        toys["Doll"]++;
                        break;
                    case 250:
                        toys["Wooden train"]++;
                        break;
                    case 300:
                        toys["Teddy bear"]++;
                        break;
                    case 400:
                        toys["Bicycle"]++;
                        break;
                }

                materials.Pop();
                magicValue.Dequeue();
                continue;
            }
            if (totalMagicValue < 0)
            {
                int sum = firstMagicValue + lastMaterials;
                materials.Pop();
                magicValue.Dequeue();
                materials.Push(sum);
                continue;
            }
            if (totalMagicValue > 0)
            {
                magicValue.Dequeue();
                materials.Pop();
                materials.Push(lastMaterials + 15);
                continue;
            }          

        }
        bool isConsidered = (toys["Doll"] > 0 && toys["Wooden train"] > 0) || (toys["Teddy bear"] > 0 && toys["Bicycle"] > 0);
        if (isConsidered)
        {
            Console.WriteLine("The presents are crafted! Merry Christmas!");
        }
        else
        {
            Console.WriteLine("No presents this Christmas!");
        }
        if (materials.Count > 0)
        {
            Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
        }
        if(magicValue.Count > 0)
        {
            Console.WriteLine($"Magic left: {string.Join(", ", magicValue)}");
        }

        foreach (var (key, value) in toys.Where(x => x.Value > 0))
        {
            Console.WriteLine($"{key}: {value}");
        }
    }
}

