namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            Car firstCar = new Car(150, 20);
            System.Console.WriteLine(firstCar.FuelConsumption);
        }
    }
}
