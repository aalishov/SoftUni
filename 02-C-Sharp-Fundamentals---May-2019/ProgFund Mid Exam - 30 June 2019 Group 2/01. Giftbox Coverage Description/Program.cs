using System;

class Program
{
    static void Main(string[] args)
    {
        double sizeOfSide = double.Parse(Console.ReadLine());
        int numberOfSheets = int.Parse(Console.ReadLine());
        double sheetArea = double.Parse(Console.ReadLine());

        double area = sizeOfSide * sizeOfSide * 6;
        int third = numberOfSheets / 3;
        double totalSheatArea = ((numberOfSheets-third) * sheetArea)+third*sheetArea*0.25;

        double percentage = totalSheatArea / area  * 100;
        Console.WriteLine($"You can cover {percentage:f2}% of the box.");
    }
}

