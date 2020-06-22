using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(' ');
        int minLength = Math.Min(words[0].Length, words[1].Length);
        int sum = 0;
        for (int i = 0; i < minLength; i++)
        {
            sum += words[0][i] * words[1][i];
        }
        if (words[0].Length>words[1].Length)
        {
            for (int i = minLength; i < words[0].Length; i++)
            {
                sum += words[0][i];
            }
        }
        if (words[0].Length < words[1].Length)
        {
            for (int i = minLength; i < words[1].Length; i++)
            {
                sum += words[1][i];
            }
        }
        Console.WriteLine(sum);
    }
}

