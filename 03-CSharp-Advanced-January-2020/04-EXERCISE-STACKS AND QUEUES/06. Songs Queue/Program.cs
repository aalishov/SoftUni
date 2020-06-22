using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(',')
            .Select(p => p.Trim())
            .ToArray();

        Queue<string> tracks = new Queue<string>(input);

        while (tracks.Any())
        {
            string[] cmd = Console.ReadLine().Split();
            switch (cmd[0])
            {
                case "Play":
                    tracks.Dequeue();
                    break;
                case "Show":
                    Console.WriteLine(string.Join(", ", tracks.ToArray()));
                    break;
                case "Add":
                    var track = cmd.Skip(1).ToList();
                    StringBuilder add = new StringBuilder();
                    foreach (var part in track)
                    {
                        if (true)
                        {

                        }
                        add.Append(part + " ");
                    }
                    string newTrack = add.ToString().Trim();
                    if (!tracks.Contains(newTrack))
                    {
                        tracks.Enqueue(newTrack);
                    }
                    else
                    {
                        Console.WriteLine($"{newTrack} is already contained!");
                    }
                    break;
            }
        }
        Console.WriteLine("No more songs!");
    }
}

