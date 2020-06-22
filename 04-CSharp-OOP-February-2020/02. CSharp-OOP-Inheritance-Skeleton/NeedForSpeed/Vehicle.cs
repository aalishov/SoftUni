using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double ConstFuelConsumptio = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = ConstFuelConsumptio;
            this.FuelConsumption = DefaultFuelConsumption;
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.DefaultFuelConsumption * kilometers;
        }
    }
}
