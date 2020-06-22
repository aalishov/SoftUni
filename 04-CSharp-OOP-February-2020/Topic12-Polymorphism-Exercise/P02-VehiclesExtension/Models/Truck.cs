namespace P02_VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        public Truck(double quantity, double consumption, double capacity) : base(quantity, consumption, capacity)
        {
        }

        protected override double FuelConsumtionModifier => 1.6;
        public override void Refuel(double liters)
        {
            double lostFuel = liters * 0.95;
            base.Refuel(liters);
            this.FuelQuantity -= lostFuel;
        }
    }
}
