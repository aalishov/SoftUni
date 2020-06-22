using System;


class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        bool isCorrec = true;
        if (!IsCorectLength(s))
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
            isCorrec = false;
        }
        if (!IsContainsLetterAndDigits(s))
        {
            Console.WriteLine("Password must consist only of letters and digits");
            isCorrec = false;
        }
        if (!IsContainsTwoDigits(s))
        {
            Console.WriteLine("Password must have at least 2 digits");
            isCorrec = false;   
        }
        if (isCorrec)
        {
            Console.WriteLine("Password is valid");
        }
    }
    private static bool IsCorectLength(string input)
    {
        if (input.Length >= 6 && input.Length < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private static bool IsContainsLetterAndDigits(string input)
    {
        char[] arr = input.ToCharArray();
        foreach (var c in arr)
        {
            if ((c < '0' || c > '9') && (c < 'a' || c > 'z')&& (c < 'A' || c > 'Z'))
            {
                return false;
            }
        }
        return true;
    }
    private static bool IsContainsTwoDigits(string input)
    {
        char[] arr = input.ToCharArray();
        int count = 0;
        foreach (var c in arr)
        {
            if (c >= '0' && c <= '9')
            {
                count++;
                if (count == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

}

