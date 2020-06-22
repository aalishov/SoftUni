using System;
using System.Numerics;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string bigestKeg = string.Empty;
            double maxCapacity=0;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
         
                double volume = Math.Pow(radius, 2) * Math.PI * height;
                if (volume>=maxCapacity)
                {
                    maxCapacity = volume;
                    bigestKeg = model;
                }
            }
            Console.WriteLine(bigestKeg);
        }
    }
}
