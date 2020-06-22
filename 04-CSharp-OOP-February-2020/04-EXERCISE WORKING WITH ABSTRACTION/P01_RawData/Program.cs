using P01_RawData.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{

    public class RawData
    {
        public static void Main()
        {
            Garage garage = new Garage();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                Car car = CreateCar();

                garage.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                Console.WriteLine(garage.Fragile());
            }
            else
            {
                Console.WriteLine(garage.Flamable());
            }
        }

        private static Car CreateCar()
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];


            Cargo cargo = new Cargo(cargoWeight, Enum.Parse<CargoType>(cargoType));


            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            Tire tire1 = new Tire(tire1age, tire1Pressure);

            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            Tire tire2 = new Tire(tire2age, tire2Pressure);

            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            Tire tire3 = new Tire(tire3age, tire3Pressure);

            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);
            Tire tire4 = new Tire(tire4age, tire4Pressure);

            List<Tire> tires = new List<Tire> { tire1, tire2, tire3, tire4 };

            Car car = new Car(model, engine, cargo, tires);
            return car;
        }
    }
}
