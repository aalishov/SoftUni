using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MiddleChar(Console.ReadLine()));
        }
        private static string MiddleChar(string s)
        {
            if (s.Length % 2 == 0)
            {
                return s.Substring(s.Length / 2-1, 2);
            }
            else
            {
                return s.Substring(s.Length / 2, 1);
            }
        }
    }
}
