using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //Blue -> dress,jeans,hat
                string[] line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = line[0];
                string[] clothesCollection = line[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var clothes in clothesCollection)
                {
                    if (!wardrobe[color].ContainsKey(clothes))
                    {
                        wardrobe[color].Add(clothes, 0);
                    }
                    wardrobe[color][clothes]++;
                }
            }
            string[] search = Console.ReadLine().Split(' ');
            string searchColor = search[0];
            string searchClothes = search[1];
            bool isFound = false;
            if (wardrobe.ContainsKey(searchColor))
            {
                if (wardrobe[searchColor].ContainsKey(searchClothes))
                {
                    isFound = true;
                }
            }

            foreach (var (colorKey, colorValue) in wardrobe)
            {
                Console.WriteLine($"{colorKey} clothes:");
                foreach (var (clothesKey, numberValue) in colorValue)
                {
                    if (isFound && colorKey == searchColor && clothesKey == searchClothes)
                    {
                        Console.WriteLine($"* {clothesKey} - {numberValue} (found!)");
                        isFound = false;
                    }
                    else
                    {

                        Console.WriteLine($"* {clothesKey} - {numberValue}");
                    }
                }
            }
        }
    }
}
