using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string model = line[0];
                int engineSpeed = int.Parse(line[1]);
                int enginePower = int.Parse(line[2]);
                int cargoWeight = int.Parse(line[3]);
                string cargoType = line[4];
                double tire1Pressure = double.Parse(line[5]);
                int tire1Age = int.Parse(line[6]);
                double tire2Pressure = double.Parse(line[7]);
                int tire2Age = int.Parse(line[8]);
                double tire3Pressure = double.Parse(line[9]);
                int tire3Age = int.Parse(line[10]);
                double tire4Pressure = double.Parse(line[11]);
                int tire4Age = int.Parse(line[12]);
                Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                cars.Add(newCar);
            }

            string cmd = Console.ReadLine();
            if (cmd == "fragile")
            {
                List<Car> fragile = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(t=>t.Pressure<1)).ToList();
                if (fragile.Any())
                {
                    foreach (var car in fragile)
                    {
                        Console.WriteLine(car);
                    }
                }
            }
            else
            {
                List<Car> flamable = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power>250).ToList();
                if (flamable.Any())
                {
                    foreach (var car in flamable)
                    {
                        Console.WriteLine(car);
                    }
                }
            }

        }
    }
}
