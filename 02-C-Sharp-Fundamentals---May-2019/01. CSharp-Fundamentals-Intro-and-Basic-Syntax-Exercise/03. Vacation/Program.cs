using System;

class Program
{
    static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        string typeOfGroup = Console.ReadLine();
        string day = Console.ReadLine();
        double singlePrice = 0.0;
        double totalPrice = 0.0;
        switch (typeOfGroup)
        {
            case "Students":
                switch (day)
                {
                    case "Friday":
                        singlePrice = 8.45;
                        break;
                    case "Saturday":
                        singlePrice = 9.8;
                        break;
                    case "Sunday":
                        singlePrice = 10.46;
                        break;
                }
                break;
            case "Business":
                switch (day)
                {
                    case "Friday":
                        singlePrice = 10.9;
                        break;
                    case "Saturday":
                        singlePrice = 15.6;
                        break;
                    case "Sunday":
                        singlePrice = 16;
                        break;
                }
                break;
            case "Regular":
                switch (day)
                {
                    case "Friday":
                        singlePrice = 15;
                        break;
                    case "Saturday":
                        singlePrice = 20;
                        break;
                    case "Sunday":
                        singlePrice = 22.5;
                        break;
                }
                break;
        }
        switch (typeOfGroup)
        {
            case "Students":
                if (numberOfPeople >= 30)
                {
                    totalPrice = numberOfPeople * singlePrice * 0.85;
                }
                else
                {
                    totalPrice = numberOfPeople * singlePrice;

                }
                break;
            case "Business":
                if (numberOfPeople >= 100)
                {
                    totalPrice = (numberOfPeople - 10) * singlePrice;
                }
                else
                {
                    totalPrice = numberOfPeople * singlePrice;

                }
                break;
            case "Regular":
                if (numberOfPeople >= 10&&numberOfPeople<=20)
                {
                    totalPrice = numberOfPeople * singlePrice*0.95;
                }
                else
                {
                    totalPrice = numberOfPeople * singlePrice;
                }
                break;
        }
        Console.WriteLine($"Total price: {totalPrice:f2}");
    }
}

