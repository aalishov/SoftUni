using System;
using System.Reflection.Metadata;

namespace P02_VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double quantity, double consumption,double capacity)
        {
            this.TankCapacity=capacity;
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumption;
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value>this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity
        {
            get; set;
        }

        protected virtual double FuelConsumtionModifier { get;  set; }
        public string Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumption + FuelConsumtionModifier);
            if (FuelQuantity < neededFuel)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters > 0)
            {
                double newLiters = FuelQuantity + liters;
                if (newLiters > TankCapacity)
                {
                    throw new Exception($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += liters;
                }
            }
            else
            {
                throw new Exception("Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
