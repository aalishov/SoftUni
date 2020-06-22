using System;


class Program
{
    static void Main()
    {
        int power = int.Parse(Console.ReadLine());
        int initialPower = power;
        int distance = int.Parse(Console.ReadLine());
        sbyte exhaustFactor = sbyte.Parse(Console.ReadLine());
        int count = 0;

        while (distance<=power)
        {
            if (power == initialPower / 2)
            {
                if (exhaustFactor > 0)
                {
                    power /= exhaustFactor;
                    if (power < distance)
                    {
                        break;
                    }
                }
            }          
                power -= distance;
                count++;                 
        }
        Console.WriteLine(power);
        Console.WriteLine(count);
    }
}

