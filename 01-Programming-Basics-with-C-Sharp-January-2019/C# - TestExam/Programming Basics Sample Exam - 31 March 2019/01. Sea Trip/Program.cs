using System;

class Program
{
    static void Main(string[] args)
    {
        double moneyFood = double.Parse(Console.ReadLine());
        double moneySouvenir = double.Parse(Console.ReadLine());
        double moneyHotel = double.Parse(Console.ReadLine());

        double fuel = 420.0 / 100.0 * 7.0;
            double moneyTrip=fuel* 1.85;
        double foodSouvenir = 3 * moneyFood + 3 * moneySouvenir;
        double hotel = moneyHotel * 0.9 + moneyHotel * 0.85 + moneyHotel * 0.8;

        double totalMoney = moneyTrip + foodSouvenir + hotel;
        Console.WriteLine($"Money needed: { totalMoney:f2}");
    }
}

