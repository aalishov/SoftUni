using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string pattern = @"([*@])([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$";
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            
            if (Regex.IsMatch(input,pattern))
            {
                foreach (Match m in Regex.Matches(input, pattern))
                {
                    string tag = m.Groups[2].ToString();
                    char s1 = m.Groups[3].ToString()[0];
                    char s2 = m.Groups[4].ToString()[0];
                    char s3 = m.Groups[5].ToString()[0];
                    Console.WriteLine($"{tag}: {(int)s1} {(int)s2} {(int)s3}");
                }
            }
            else
            {
                Console.WriteLine("Valid message not found!");
            }

        }
    }
}

