using System;

class Program
{
    static void Main(string[] args)
    {
        double shipWidth = double.Parse(Console.ReadLine());
        double shipLength = double.Parse(Console.ReadLine());
        double shipHeight = double.Parse(Console.ReadLine());
        double averageHeight = double.Parse(Console.ReadLine());

        double volume = shipWidth * shipHeight * shipLength;
        double neeededVolume = 2 * 2 * (averageHeight + 0.4);

        double number = Math.Floor(volume / neeededVolume);

        if (number>10)
        {
            Console.WriteLine($"The spacecraft is too big.");
        }
        else if (number<3)
        {
            Console.WriteLine($"The spacecraft is too small.");
        }
        else
        {
            Console.WriteLine($"The spacecraft holds {number} astronauts.");
        }

    }
}

