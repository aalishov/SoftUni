using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //int timeOfTask = int.Parse(Console.ReadLine());
        List<int> tasks = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Where(x=>x>=-1&&x<=5).ToList();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdLine = command.Split(' ').ToArray();
            string cmd = cmdLine[0];

            switch (cmd)
            {
                case "Complete":
                    if (int.Parse(cmdLine[1]) >= 0 && int.Parse(cmdLine[1]) < tasks.Count)
                    {
                        tasks[int.Parse(cmdLine[1])] = 0;
                    }
                    break;
                case "Change":
                    if (int.Parse(cmdLine[1]) >= 0 && int.Parse(cmdLine[1]) < tasks.Count&& int.Parse(cmdLine[2]) >= 0&& int.Parse(cmdLine[2])<=5)
                    {
                        tasks[int.Parse(cmdLine[1])] = int.Parse(cmdLine[2]);
                    }
                    break;
                case "Drop":
                    if (int.Parse(cmdLine[1]) >= 0 && int.Parse(cmdLine[1]) < tasks.Count)
                    {
                        tasks[int.Parse(cmdLine[1])] = -1;
                    }
                    break;
                case "Count":
                    string cmdCount = cmdLine[1];
                    switch (cmdCount)
                    {
                        case "Completed":
                            Console.WriteLine(tasks.Count(x => x == 0));
                            break;
                        case "Incomplete":
                            Console.WriteLine(tasks.Count(x => x != 0 && x != -1));
                            break;
                        case "Dropped":
                            Console.WriteLine(tasks.Count(x => x == -1));
                            break;
                    }
                    break;
                    
            }
            Console.WriteLine(string.Join(' ', tasks));
        }
        Console.WriteLine(string.Join(' ',tasks.Where(x => x != 0 && x != -1)));
    }
}

