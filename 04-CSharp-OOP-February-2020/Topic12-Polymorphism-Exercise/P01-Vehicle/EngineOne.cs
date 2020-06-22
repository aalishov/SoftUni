using P01_Vehicle.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicle
{
    public class EngineOne
    {
        public void Run()
        {
            var v1 = CreateVehicle();
            var v2 = CreateVehicle();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string cmd = cmdArgs[0];
                string vehicle = cmdArgs[1];
                double value = double.Parse(cmdArgs[2]);
                try
                {
                    if (cmd == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            Console.WriteLine(v1.Drive(value));
                        }
                        else if (vehicle == "Truck")
                        {
                            Console.WriteLine(v2.Drive(value));
                        }
                    }
                    else
                    {
                        if (vehicle == "Car")
                        {
                            v1.Refuel(value);
                        }
                        else if (vehicle == "Truck")
                        {
                            v2.Refuel(value);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
            }
            Console.WriteLine(v1);
            Console.WriteLine(v2);
        }
        private Vehicle CreateVehicle()
        {
            string[] line = Console.ReadLine().Split(' ');
            string type = line[0];
            double fuel = double.Parse(line[1]);
            double consumption = double.Parse(line[2]);

            if (type == "Car")
            {
                return new Car(fuel, consumption);
            }
            else if (type == "Truck")
            {
                return new Truck(fuel, consumption);
            }
            return null;
        }
    }
  
}
