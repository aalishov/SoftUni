using System;

namespace _01._Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentName = Console.ReadLine();
            var studentAge = int.Parse(Console.ReadLine());
            var studentGrade = double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Grade: {studentGrade:F2}");
        }
    }
}
