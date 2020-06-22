using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicle.Models
{
    public interface IVehicle
    {
        public double FuelQuantity { get;  }
        public double FuelConsumption { get;  }
        public string Drive(double distance);
        public void Refuel(double liters);

    }
}
