using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string sushiType = Console.ReadLine();
        string restorant = Console.ReadLine();
        int porcion = int.Parse(Console.ReadLine());
        char order = (char)Console.Read();
        double price = 0.0;
        bool isInvalid = false;
        switch (sushiType)
        {
            case "sashimi":
                switch (restorant)
                {
                    case "Sushi Zone":
                        price = porcion * 4.99;
                        break;
                    case "Sushi Time":
                        price = porcion * 5.49;
                        break;
                    case "Sushi Bar":
                        price = porcion * 5.25;
                        break;
                    case "Asian Pub":
                        price = porcion * 4.50;
                        break;
                    default:
                        isInvalid = true;
                        break;
                }
                break;
            case "maki":
                switch (restorant)
                {
                    case "Sushi Zone":
                        price = porcion * 5.29;
                        break;
                    case "Sushi Time":
                        price = porcion * 4.69;
                        break;
                    case "Sushi Bar":
                        price = porcion * 5.55;
                        break;
                    case "Asian Pub":
                        price = porcion * 4.8;
                        break;
                    default:
                        isInvalid = true;
                        break;
                }
                break;
            case "uramaki":
                switch (restorant)
                {
                    case "Sushi Zone":
                        price = porcion * 5.99;
                        break;
                    case "Sushi Time":
                        price = porcion * 4.49;
                        break;
                    case "Sushi Bar":
                        price = porcion * 6.25;
                        break;
                    case "Asian Pub":
                        price = porcion * 5.50;
                        break;
                    default:
                        isInvalid = true;
                        break;
                }
                break;
            case "temaki":
                switch (restorant)
                {
                    case "Sushi Zone":
                        price = porcion * 4.29;
                        break;
                    case "Sushi Time":
                        price = porcion * 5.19;
                        break;
                    case "Sushi Bar":
                        price = porcion * 4.75;
                        break;
                    case "Asian Pub":
                        price = porcion * 5.50;
                        break;
                    default:
                        isInvalid = true;
                        break;
                }
                break;
        }
        if (order == 'Y')
        {
            price *= 1.2;
        }
        if (isInvalid==true)
        {
            Console.WriteLine($"{restorant} is invalid restaurant!");
        }
        else
        {
            Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
        }
   


    }
}

