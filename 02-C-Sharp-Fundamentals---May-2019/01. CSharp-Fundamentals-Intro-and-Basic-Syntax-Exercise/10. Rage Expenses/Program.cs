using System;


class Program
{
    static void Main(string[] args)
    {
        int games = int.Parse(Console.ReadLine());
        double headsetPrice = double.Parse(Console.ReadLine());
        double mousePrice = double.Parse(Console.ReadLine());
        double keyboardPrice = double.Parse(Console.ReadLine());
        double displayPrice = double.Parse(Console.ReadLine());

        int headset = games / 2;
        int mouse = games / 3;
        int keyboard = games / 6;
        int display = keyboard / 2;

        double expenses = headset * headsetPrice + mouse * mousePrice + keyboard * keyboardPrice + display * displayPrice;
        Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
    }
}

