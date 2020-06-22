using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string model = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelConsumptionFor1km = double.Parse(line[2]);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new Car()
                    {
                        Model = model,
                        FuelAmount = fuelAmount,
                        FuelConsumptionPerKilometer = fuelConsumptionFor1km
                    });
                }
            }

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                if (cmd[0] == "End")
                {
                    foreach (var c in cars)
                    {
                        Console.WriteLine(c.Value.ToString());
                    }
                    break;
                }
                string car = cmd[1];
                int km = int.Parse(cmd[2]);

                cars[car].Drive(km);
            }
        }
    }
}
