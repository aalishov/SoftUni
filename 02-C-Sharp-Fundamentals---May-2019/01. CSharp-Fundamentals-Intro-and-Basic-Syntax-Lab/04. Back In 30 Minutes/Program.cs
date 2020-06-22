using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var src = DateTime.Now;
            DateTime current = new DateTime(src.Year, src.Month, src.Day, hours, minutes, 0);
            current=current.AddMinutes(30);
            Console.WriteLine($"{current:H:mm}");

        }
    }
}
