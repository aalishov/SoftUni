using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int visitor = int.Parse(Console.ReadLine());
        int sum = 0;
        int countVisitor = 0;
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "The restaurant is full")
            {
                break;
            }
            int people = int.Parse(command);
            if (people<5)
            {
                sum += people * 100; countVisitor += people;
            }
            else
            {
                sum += people * 70;
                countVisitor += people;
            }
        }
        if (sum>=visitor)
        {
            Console.WriteLine($"You have {countVisitor} guests and {sum-visitor} leva left.");
        }
        else
        {
            Console.WriteLine($"You have {countVisitor} guests and {sum} leva income, but no singer.");
        }
    }
}



