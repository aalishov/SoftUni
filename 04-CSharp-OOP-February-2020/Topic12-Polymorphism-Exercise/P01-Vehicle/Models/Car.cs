using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicle.Models
{
    public class Car : Vehicle
    {
        public Car(double quantity, double consumption) : base(quantity, consumption)
        {

        }
        protected override double FuelConsumtionModifier { get => 0.9; }
    }
}
