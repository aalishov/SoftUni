using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> nums = Console.ReadLine().Split(' ').ToList();
        while (true)
        {
            string[] cmd = Console.ReadLine().Split(' ');
            if (cmd[0] == "END")
            {
                break;
            }
            switch (cmd[0])
            {
                case "Reverse":
                    nums.Reverse();
                    break;
                case "Hide":
                    if (nums.Contains(cmd[1]))
                    {
                        nums.RemoveAll(x=>x==cmd[1]);
                    }
                    break;
                case "Switch":
                    if (nums.Contains(cmd[1]) && nums.Contains(cmd[2]))
                    {
                        int firstElementIndex = nums.FindIndex(x => x == cmd[1]);
                        int secondElementIndex = nums.FindIndex(x => x == cmd[2]);
                        nums[firstElementIndex] = cmd[2];
                        nums[secondElementIndex] = cmd[1];
                    }
                    break;
                case "Change":
                    if (nums.Contains(cmd[1]))
                    {
                        nums[nums.FindIndex(x => x == cmd[1])] = cmd[2];
                    }
                    break;
                case "Insert":
                    if (int.Parse(cmd[1]) > -1 && int.Parse(cmd[1])< nums.Count)
                    {
                        nums.Insert(int.Parse(cmd[1]) + 1, cmd[2]);
                    }
                    break;
            }
        }
        Console.WriteLine(string.Join(' ', nums));
    }
}

