using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int studentTickets = 0;
        int standardTickets = 0;
        int kidsTickets = 0;
        double totalTickets = 0;
        while (true)
        {
            string line = Console.ReadLine();
            if (line=="Finish")
            {
                break;
            }
            double freePlace = double.Parse(Console.ReadLine());
            totalTickets = 0;
            for (int i = 0; i < freePlace; i++)
            {
                string ticketType = Console.ReadLine();                
                if (ticketType=="End")
                {
                    break;
                }
                totalTickets++;
                if (ticketType=="student")
                {
                    studentTickets++;
                }
                else if (ticketType == "standard")
                {
                    standardTickets++;
                }
                else if (ticketType == "kid")
                {
                    kidsTickets++;
                }
            }
            Console.WriteLine($"{line} - {totalTickets/freePlace*100:f2}% full.");
        }
        totalTickets = studentTickets + standardTickets + kidsTickets;
        Console.WriteLine($"Total tickets: {totalTickets}");
        Console.WriteLine($"{studentTickets / totalTickets * 100.0:f2}% student tickets.");
        Console.WriteLine($"{standardTickets/totalTickets*100:f2}% standard tickets.");
        Console.WriteLine($"{kidsTickets/totalTickets*100:f2}% kids tickets.");
    }
}

