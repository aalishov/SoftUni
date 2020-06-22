using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = line[0];
            int power = int.Parse(line[1]);

            if (!engines.ContainsKey(model))
            {
                if (line.Length == 2)
                {
                    engines.Add(model, new Engine(model, power));
                }
                else if (line.Length == 3)
                {
                    int displacement = 0;
                    if (int.TryParse(line[2], out displacement))
                    {
                        engines.Add(model, new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = line[2];
                        engines.Add(model, new Engine(model, power, efficiency));
                    }
                }
                else if (line.Length == 4)
                {
                    int displacement = int.Parse(line[2]);
                    string efficiency = line[3];
                    engines.Add(model, new Engine(model, power, displacement, efficiency));
                }
                else
                {
                    throw new ArgumentException("Engine incorect arguments!");
                }
            }
            else
            {
                if (line.Length == 2)
                {
                    engines[model].Power = power;
                }
                else if (line.Length == 3)
                {
                    int displacement = 0;
                    if (int.TryParse(line[2], out displacement))
                    {
                        engines[model].Power = power;
                        engines[model].Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = line[2];
                        engines[model].Power = power;
                        engines[model].Efficiency = efficiency;
                    }
                }
                else if (line.Length == 4)
                {
                    int displacement = int.Parse(line[2]);
                    string efficiency = line[3];
                    engines[model].Power = power;
                    engines[model].Efficiency = efficiency;
                    engines[model].Displacement = displacement;
                }
                else
                {
                    throw new ArgumentException("Engine incorect arguments!");
                }
            }

        }
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = line[0];
            Engine engine = engines[line[1]];


            if (line.Length == 2)
            {
                cars.Add(model, new Car(model, engine));
            }
            else if (line.Length == 3)
            {
                int weight = 0;
                if (int.TryParse(line[2], out weight))
                {
                    cars.Add(model, new Car(model, engine, weight));
                }
                else
                {
                    string color = line[2];
                    cars.Add(model, new Car(model, engine, color));
                }
            }
            else if (line.Length == 4)
            {
                int weight = int.Parse(line[2]);
                string color = line[3];
                cars.Add(model, new Car(model, engine, weight, color));
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.Value.ToString());
        }
    }
}