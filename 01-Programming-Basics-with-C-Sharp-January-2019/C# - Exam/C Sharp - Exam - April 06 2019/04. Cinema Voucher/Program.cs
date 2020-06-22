using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int vaucherPrice = int.Parse(Console.ReadLine());
        decimal total = vaucherPrice;
        int countTickets = 0;
        int countOther = 0;
        while (true)
        {
            string line = Console.ReadLine();
            decimal price = 0.0m;
            if (line=="End")
            {
                break;
            }
            if (line.Length>8)
            {
                price = line.Take(2).ToArray().Sum(x=>x);
                if (price<= total)
                {
                    countTickets++;
                    total -= price;
                }
                else
                {
                    break;
                }
            }
            else
            {
                price = line.Take(1).ToArray().Sum(x => x);
                if (price<= total)
                {
                    countOther++;
                    total -= price;
                }
                else
                {
                    break;
                }               
            }
        }
        Console.WriteLine(countTickets);
        Console.WriteLine(countOther);
    }
}

