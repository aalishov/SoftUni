using System;
using System.Linq;
namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < line.Length; i++)
            {
                if (IsCorrectLength(line[i]) && IsContainsCorrectSymbol(line[i]))
                {
                    Console.WriteLine(line[i]);
                }
            }
        }

        public static bool IsCorrectLength(string s)
        {
            if (s.Length >= 3 && s.Length <= 16)
            {
                return true;
            }
            return false;
        }
        public static bool IsContainsCorrectSymbol(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {

                if (char.IsLetterOrDigit(s[i]) || s[i]=='-'||s[i]=='_')
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

}
