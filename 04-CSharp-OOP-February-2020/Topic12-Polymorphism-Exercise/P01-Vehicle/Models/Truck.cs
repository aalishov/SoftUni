using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicle.Models
{
    public class Truck : Vehicle
    {
        public Truck(double quantity, double consumption) : base(quantity, consumption)
        {
        }
        protected override double FuelConsumtionModifier => 1.6;
        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
