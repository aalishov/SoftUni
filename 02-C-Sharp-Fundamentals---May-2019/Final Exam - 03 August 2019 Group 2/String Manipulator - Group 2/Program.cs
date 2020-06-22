using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder s = new StringBuilder();
        StringBuilder removed = new StringBuilder();
        s.Append(Console.ReadLine());
        string cmd = string.Empty;

        while ((cmd = Console.ReadLine()) != "Done")
        {
            string[] command = cmd.Split(' ');
            switch (command[0])
            {
                case "Change":
                    char oldChar = command[1][0];
                    char newChar = command[2][0];
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == oldChar)
                        {
                            s[i] = newChar;
                        }
                    }
                    Console.WriteLine(s);
                    break;
                case "Includes":
                    if (s.ToString().IndexOf(command[1]) != -1)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                    break;
                case "End":
                    int startIndex = s.ToString().LastIndexOf(command[1]);
                    if (startIndex != -1)
                    {
                        string substring = s.ToString().Substring(startIndex);
                        if (substring == command[1])
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                    break;
                case "Uppercase":
                    string newS = s.ToString().ToUpper();
                    s.Clear();
                    s.Append(newS);
                    Console.WriteLine(s.ToString());
                    break;
                case "FindIndex":
                    Console.WriteLine(s.ToString().IndexOf(command[1][0]));
                    break;
                case "Cut":
                    int startIndexR = int.Parse(command[1]);
                    int lengthR = int.Parse(command[2]);
                    //for (int i = 0; i < s.Length; i++)
                    //{
                    //    if (s[i] >= startIndexR && s[i] <= (startIndexR+lengthR))
                    //    {
                            
                    //    }
                    //    else
                    //    {
                    //        removed.Append(s[i]);
                    //    }
                    //}
                    Console.WriteLine(s.ToString().Substring(startIndexR,lengthR));
                    //removed.Clear();
                    break;
            }
        }
        
    }
}

