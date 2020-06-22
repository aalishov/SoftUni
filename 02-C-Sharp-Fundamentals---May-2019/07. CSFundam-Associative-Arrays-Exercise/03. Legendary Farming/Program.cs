using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        int endValue = 0;

        Dictionary<string, int> materials = new Dictionary<string, int>();
        Dictionary<string, int> junk = new Dictionary<string, int>();
        materials.Add("fragments", 0);
        materials.Add("shards", 0);
        materials.Add("motes", 0);

        while (endValue<250)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int i = 0; i < line.Length; i+=2)
            {
                int quantity = int.Parse(line[i]);
                string material = line[i + 1].ToLower();

                switch (material)
                {
                    case "fragments":
                    case "shards":
                    case "motes":                        
                            materials[material] += quantity;                       
                        break;
                    default:
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material, quantity);
                        }
                        break;
                }
                endValue = materials.OrderByDescending(x => x.Value).FirstOrDefault().Value;
                if (endValue>=250)
                {
                    string obtainedItem = materials.OrderByDescending(x => x.Value).FirstOrDefault().Key;
                    if (obtainedItem == "fragments")
                    {
                        Console.WriteLine("Valanyr obtained!");
                        materials["fragments"] -= 250;
                    }
                    else if (obtainedItem == "shards")
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        materials["shards"] -= 250;
                    }
                    else
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        materials["motes"] -= 250;
                    }
                    break;
                }
            }                      

        }
        foreach (var e in materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{e.Key}: {e.Value}");
        }
        foreach (var e in junk.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{e.Key}: {e.Value}");
        }
    }
}


