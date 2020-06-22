using System;

class Program
{
    static void Main()
    {
        double money = double.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        double lightsabers = double.Parse(Console.ReadLine());
        double robes = double.Parse(Console.ReadLine());
        double belts = double.Parse(Console.ReadLine());

        double expenseLightsabers = Math.Ceiling(students * 1.1) * lightsabers;
        double expenseBelts = (students - students / 6) * belts;
        double expenseRobes = robes * students;

        double totalExpense = expenseBelts + expenseLightsabers + expenseRobes;

        if (money>=totalExpense)
        {
            Console.WriteLine($"The money is enough - it would cost {totalExpense:f2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivan Cho will need {totalExpense-money:f2}lv more.");
        }
    }
}

