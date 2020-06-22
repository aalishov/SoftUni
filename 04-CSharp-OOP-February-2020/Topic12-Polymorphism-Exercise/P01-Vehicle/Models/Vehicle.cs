using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicle.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double quantity, double consumption)
        {
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumption;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        protected virtual double FuelConsumtionModifier { get; }
        public string Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumption + FuelConsumtionModifier);
            if (FuelQuantity<neededFuel)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters>0)
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
