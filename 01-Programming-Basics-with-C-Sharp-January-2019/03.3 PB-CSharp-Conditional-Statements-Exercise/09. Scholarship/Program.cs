using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = minSalary * 0.35;
            double Scholarship = averageGrade * 25;

            if (averageGrade <= 4.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (averageGrade < 5.5)
            {
                if (income < minSalary)
                {

                    Console.WriteLine("You get a Social scholarship {0:f0} BGN", Math.Floor(socialScholarship));
                }
                else
                {

                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
            else if (averageGrade >= 5.5)
            {
                if (income < minSalary)
                {
                    if (Scholarship >= socialScholarship)
                    {

                        Console.WriteLine("You get a scholarship for excellent results {0:f0} BGN", Math.Floor(Scholarship));
                    }
                    else
                    {

                        Console.WriteLine("You get a Social scholarship {0:f0} BGN", Math.Floor(socialScholarship));
                    }
                }
                else
                {

                    Console.WriteLine("You get a scholarship for excellent results {0:f0} BGN", Math.Floor(Scholarship));
                }
            }
        }
    }
}