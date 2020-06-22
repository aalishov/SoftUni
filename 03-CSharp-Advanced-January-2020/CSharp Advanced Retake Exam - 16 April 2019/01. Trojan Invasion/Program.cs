using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<int> waves = new List<int>();
    static void Main()
    {
        int wavesNum = int.Parse(Console.ReadLine());

        List<int> spartanDefence = new List<int>(ReadIntLine());

        
        Attack(wavesNum, spartanDefence);
        PrintOutput(spartanDefence, waves);
    }

    private static List<int> Attack(int wavesNum, List<int> spartanDefence)
    {
        for (int i = 0; i < wavesNum; i++)
        {
            waves = new List<int>(ReadIntLine());

            while (waves.Any() && spartanDefence.Any())
            {
                int plate = spartanDefence.First();
                int warrion = waves.Last();

                if (plate > warrion)
                {
                    spartanDefence[0] -= warrion;
                    waves.RemoveAt(waves.Count - 1);
                }
                else if (plate < warrion)
                {
                    waves[waves.Count - 1] -= plate;
                    spartanDefence.RemoveAt(0);
                }
                else
                {
                    spartanDefence.RemoveAt(0);
                    waves.RemoveAt(waves.Count - 1);
                }
            }

            if ((i + 1) % 3 == 0)
            {
                int addPlate = int.Parse(Console.ReadLine());
                spartanDefence.Add(addPlate);
            }

            if (!spartanDefence.Any())
            {
                break;
            }
        }

        return waves;
    }

    private static void PrintOutput(List<int> spartanDefence, List<int> waves)
    {
        if (spartanDefence.Any())
        {
            Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", spartanDefence)}");
        }
        else
        {
            waves.Reverse();
            Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
            Console.WriteLine($"Warriors left: {string.Join(", ", waves)}");
        }
    }

    private static IEnumerable<int> ReadIntLine()
    {
        return Console.ReadLine().Split(' ').Select(int.Parse);
    }
}

