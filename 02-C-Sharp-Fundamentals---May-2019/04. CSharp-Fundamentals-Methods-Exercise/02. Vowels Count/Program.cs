using System;

class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(CountVowels(s));
    }
    private static int CountVowels(string s)
    {
        char[] arr = s.ToCharArray();
        int count = 0;
        foreach (var c in arr)
        {
            switch (c)
            {
                case 'a':
                case 'A':
                case 'e':
                case 'E':
                case 'i':
                case 'I':
                case 'o':
                case 'O':
                case 'u':
                case 'U':
                    count++;
                    break;
            }
        }
        return count; 
    }
}

