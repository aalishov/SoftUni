using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string fileName = Console.ReadLine();
        int copyIndex = fileName.LastIndexOf('\\')+1;
        if (copyIndex!=-1)
        {

            string[] fileInfo=fileName.Substring(copyIndex).Split('.');
            Console.WriteLine($"File name: {fileInfo[0]}");
            Console.WriteLine($"File extension: {fileInfo[1]}");

        }
    }
}

