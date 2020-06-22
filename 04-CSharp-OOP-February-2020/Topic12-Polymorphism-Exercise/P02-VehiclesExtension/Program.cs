using P02_VehiclesExtension.Models;
using System;

namespace P02_VehiclesExtension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var v1 = CreateVehicle();
            var v2 = CreateVehicle();
            var v3 = CreateVehicle();

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
                        else if (vehicle=="Bus")
                        {
                            var a = (Bus)v3;
                            a.EmtyBus(false);
                            Console.WriteLine(v3.Drive(value));
                        }
                    }
                    else if (cmd=="DriveEmpty")
                    {
                        var a = (Bus)v3;
                        a.EmtyBus(true);
                        Console.WriteLine(v3.Drive(value));
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
                        else if (vehicle=="Bus")
                        {
                            v3.Refuel(value);
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
            Console.WriteLine(v3);
        }
        private static Vehicle CreateVehicle()
        {
            string[] line = Console.ReadLine().Split(' ');
            string type = line[0];
            double fuel = double.Parse(line[1]);
            double consumption = double.Parse(line[2]);
            double capacity = double.Parse(line[3]);

            if (type == "Car")
            {
                return new Car(fuel, consumption,capacity);
            }
            else if (type == "Truck")
            {
                return new Truck(fuel, consumption,capacity);
            }
            else if (type=="Bus")
            {
                return new Bus(fuel, consumption, capacity);
            }
            return null;
        }
    }
    
}
