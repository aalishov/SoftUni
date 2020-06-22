using System;

namespace _06._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double sum = 0;
            while (counter<12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade>=4)
                {
                    sum += grade;
                    counter++;
                }
            }
            
            
            Console.WriteLine($"{name} graduated. Average grade: {sum/12:f2}");
        }

    }
}
