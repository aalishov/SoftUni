using System;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ');
                students[i] = new Student(info[0], info[1], double.Parse(info[2]));
            }
            students = students.OrderByDescending(x => x.Grade).ToArray();
            foreach (var s in students)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
    public class Student
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public double Grade { get; set; }
        public Student(string fName, string lName, double grade)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Grade = grade;
        }
        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName}: {Grade:f2}");
        }
    }
}
