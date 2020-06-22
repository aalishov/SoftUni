using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
   public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; } = new Tire[4];

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight,cargoType);
            Tire tire1 = new Tire(tire1Pressure, tire1Age);
            Tire tire2 = new Tire(tire2Pressure, tire2Age);
            Tire tire3 = new Tire(tire3Pressure, tire3Age);
            Tire tire4 = new Tire(tire4Pressure, tire4Age);

            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            Tires[0] = tire1;
            Tires[1] = tire2;
            Tires[2] = tire3;
            Tires[3] = tire4;
        }

        
        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
