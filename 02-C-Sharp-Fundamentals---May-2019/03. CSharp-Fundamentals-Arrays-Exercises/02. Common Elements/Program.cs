using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] fLine = Console.ReadLine().Split(' ').ToArray();
        string[] sLine = Console.ReadLine().Split(' ').ToArray();

        string[] commonElement = new string[fLine.Length];
        int commonCounter = 0;

        for (int i = 0; i < sLine.Length; i++)
        {
            for (int j = 0; j < fLine.Length; j++)
            {
                if (sLine[i]==fLine[j])
                {
                    commonElement[commonCounter] = sLine[i];
                    commonCounter++;
                }
            }
        }
        for (int i = 0; i < commonCounter; i++)
        {
            Console.Write(commonElement[i]+" ");
        }
        Console.WriteLine();
    }
}

