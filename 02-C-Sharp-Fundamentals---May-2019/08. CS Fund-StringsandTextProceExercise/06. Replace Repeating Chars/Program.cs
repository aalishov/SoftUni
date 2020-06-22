using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        StringBuilder newS = new StringBuilder();
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i-1]!=s[i])
            {
                newS.Append(s[i-1]);
            }
        }
        if (newS.Length!=0)
        {
            if (s[s.Length - 1] != newS[newS.Length - 1])
            {
                newS.Append(s[s.Length - 1]);
            }
        }
        if (newS.Length>0)
        {
            Console.WriteLine(newS);
        }
        else
        {
            Console.WriteLine(s[0]);
        }
    }
}

