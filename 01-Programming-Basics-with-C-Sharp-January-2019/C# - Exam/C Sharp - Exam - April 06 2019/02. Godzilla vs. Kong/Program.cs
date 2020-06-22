using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        decimal budget = decimal.Parse(Console.ReadLine());
        int numberOfStatists = int.Parse(Console.ReadLine());
        decimal priceClothesOfStatist = decimal.Parse(Console.ReadLine());

        decimal decor = 0.1m * budget;
        decimal statistExpense = 0.0m;
        if (numberOfStatists>=150)
        {
            statistExpense = numberOfStatists * priceClothesOfStatist;
            statistExpense *= 0.9m;
        }
        else
        {
            statistExpense = numberOfStatists * priceClothesOfStatist;
        }

        decimal totalExpense = decor + statistExpense;

        decimal difference = Math.Abs(budget - totalExpense);

        if (statistExpense>=budget)
        {
            Console.WriteLine($"Not enough money!");
            Console.WriteLine($"Wingard needs {difference:f2} leva more.");
        }
        else
        {
            Console.WriteLine($"Action!");
            Console.WriteLine($"Wingard starts filming with {difference:f2} leva left.");
        }
    }
}
