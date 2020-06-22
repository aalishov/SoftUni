using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
		private string model;
		private double fuelAmount;
		private double fuelConsumptionPerKilometer;
		private double travelledDistancec;

		public Car()
		{
			travelledDistancec = 0;
		}
		public double TravelledDistance
		{
			get { return travelledDistancec; }
			set { travelledDistancec = value; }
		}
		public double FuelConsumptionPerKilometer
		{
			get { return fuelConsumptionPerKilometer; }
			set { fuelConsumptionPerKilometer = value; }
		}
		public double FuelAmount
		{
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public void Drive(int amountOFKm)
		{
			if (amountOFKm*FuelConsumptionPerKilometer<=FuelAmount)
			{
				FuelAmount -= amountOFKm * FuelConsumptionPerKilometer;
				TravelledDistance += amountOFKm;
			}
			else
			{
				Console.WriteLine("Insufficient fuel for the drive");
			}
		}

		public override string ToString()
		{
			return string.Format($"{Model} {FuelAmount:f2} {TravelledDistance}");
		}
	}
}
