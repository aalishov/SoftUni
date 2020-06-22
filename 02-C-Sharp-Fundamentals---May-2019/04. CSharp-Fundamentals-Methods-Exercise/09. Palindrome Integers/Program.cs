using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            string l = ReturnLeftSide(input);
            string r = new string(ReturnRightSide(input).ToCharArray().Reverse().ToArray());
            if (l == r)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
    private static string ReturnLeftSide(string s)
    {
        int middle = s.Length / 2;

        return s.Substring(0, middle);
    }
    private static string ReturnRightSide(string s)
    {
        int middle = s.Length / 2;

        if (s.Length % 2 == 1)
        {
            return s.Substring(middle + 1, middle);
        }
        else
        {
            return s.Substring(middle, middle);
        }
    }
}

