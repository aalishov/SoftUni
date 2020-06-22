using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string filmName = Console.ReadLine();
        string hallType = Console.ReadLine();
        int numberOfTickets = int.Parse(Console.ReadLine());
        decimal incomes = 0.0m;

        switch (filmName)
        {
            case "A Star Is Born":
                switch (hallType)
                {
                    case "normal":
                        incomes = numberOfTickets * 7.5m;
                            break;
                    case "luxury":
                        incomes = numberOfTickets * 10.5m;
                        break;
                    case "ultra luxury":
                        incomes = numberOfTickets * 13.5m;
                        break;
                }
                break;
            case "Bohemian Rhapsody":
                switch (hallType)
                {
                    case "normal":
                        incomes = numberOfTickets * 7.35m;
                        break;
                    case "luxury":
                        incomes = numberOfTickets * 9.45m;
                        break;
                    case "ultra luxury":
                        incomes = numberOfTickets * 12.75m;
                        break;
                }
                break;
            case "Green Book":
                switch (hallType)
                {
                    case "normal":
                        incomes = numberOfTickets * 7.15m;
                        break;
                    case "luxury":
                        incomes = numberOfTickets * 10.25m;
                        break;
                    case "ultra luxury":
                        incomes = numberOfTickets * 13.25m;
                        break;
                }
                break;
            case "The Favourite":
                switch (hallType)
                {
                    case "normal":
                        incomes = numberOfTickets * 8.75m;
                        break;
                    case "luxury":
                        incomes = numberOfTickets * 11.55m;
                        break;
                    case "ultra luxury":
                        incomes = numberOfTickets * 13.95m;
                        break;
                }
                break;
        }
        Console.WriteLine($"{filmName} -> {incomes:f2} lv.");
    }
}

