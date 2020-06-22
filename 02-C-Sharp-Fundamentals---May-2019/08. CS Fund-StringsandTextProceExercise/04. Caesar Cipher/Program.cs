using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder newInput = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            int cIndex = (int)input[i] + 3;
            newInput.Append((char)cIndex);
        }
        Console.WriteLine(newInput);

    }
}

