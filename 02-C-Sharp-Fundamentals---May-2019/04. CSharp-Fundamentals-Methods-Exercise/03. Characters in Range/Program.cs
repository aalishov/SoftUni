using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        char s = Console.ReadLine().ToCharArray().First();
        char e = Console.ReadLine().ToCharArray().First();
        Console.WriteLine(PrintCharInRange(s, e));
    }
    private static string PrintCharInRange(char f, char l)
    {
        char start, end;
        if (f <= l)
        {
            start = f;
            end = l;
        }
        else
        {
            start = l;
            end = f;
        }
        StringBuilder s = new StringBuilder();
        for (int i = start + 1; i < end; i++)
        {
            s.Append((char)i + " ");
        }
        return s.ToString();
    }
}

