using System;

namespace _07._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double sum = 0;
            int studentClass=1;
            int error = 0;

            while (counter < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sum += grade;
                    counter++;
                    studentClass++;
                    error = 0;
                }
                else
                {
                    error++;
                    if (error>1)
                    {
                        break;
                    }
                }
            }

            if (studentClass>12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum / 12:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {studentClass} grade");
            }
            
        }
    }
}
