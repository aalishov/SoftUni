using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine())+'a';
            for (int i = 'a'; i < end; i++)
            {
                for (int j = 'a'; j < end; j++)
                {
                    for (int k = 'a'; k < end; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
