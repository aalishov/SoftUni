using System;

class Program
{
    static void Main(string[] args)
    {
        double money = 0.0;

        string input = Console.ReadLine();
        while (input != "Start")
        {
            double enteredMoney = double.Parse(input);

            switch (enteredMoney)
            {
                case 0.1:
                case 0.2:
                case 0.5:
                case 1:
                case 2:
                    money += enteredMoney;
                    break;
                default:
                    Console.WriteLine($"Cannot accept {enteredMoney}");
                    break;
            }
            input = Console.ReadLine();
        }
        input = Console.ReadLine().ToLower();
        while (input != "end")
        {
            bool isPurchased = true;
            double expence = 0.0;
            
            switch (input)
            {
                case "nuts":
                    expence = 2;
                    break;
                case "water":
                    expence = 0.7;
                    break;
                case "crisps":
                    expence = 1.5;
                    break;
                case "soda":
                    expence = 0.8;
                    break;
                case "coke":
                    expence = 1;
                    break;
                default:
                    Console.WriteLine("Invalid product");
                    isPurchased = false;
                    break;
            }
            if (money - expence >= 0 && isPurchased)
            {
                Console.WriteLine($"Purchased {input}");
                money -= expence;
            }
            else if (isPurchased)
            {
                Console.WriteLine("Sorry, not enough money");
            }
            input = Console.ReadLine().ToLower();
        }
        Console.WriteLine($"Change: {money:f2}");
    }
}

