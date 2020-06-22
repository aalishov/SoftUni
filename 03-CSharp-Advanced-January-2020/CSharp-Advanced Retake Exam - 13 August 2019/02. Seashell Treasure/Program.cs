using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static char[][] field;
    private static List<char> collected = new List<char>();
    private static int stolenCounter;
    public static void Main()
    {
        int rowNum = int.Parse(Console.ReadLine());

        field = new char[rowNum][];

        ReadField();

        while (true)
        {
            string[] line = Console.ReadLine().Split(' ');

            string cmd = line[0];

            if (cmd == "Sunset")
            {
                break;
            }

            int cmdRow = int.Parse(line[1]);
            int cmdCol = int.Parse(line[2]);

            if (cmd == "Collect")
            {
                if (IsIndexValid(cmdRow, cmdCol))
                {
                    if (field[cmdRow][cmdCol] != '-')
                    {
                        collected.Add(field[cmdRow][cmdCol]);
                        field[cmdRow][cmdCol] = '-';
                    }
                }
            }
            else if (cmd == "Steal")
            {
                if (IsIndexValid(cmdRow, cmdCol) && field[cmdRow][cmdCol]!='-')
                {
                    string direction = line[3];

                    StoleTreasure(cmdRow, cmdCol);
                    switch (direction)
                    {
                        case "up":
                            for (int i = 0; i < 3; i++)
                            {
                                cmdRow--;
                                if (IsIndexValid(cmdRow, cmdCol) && field[cmdRow][cmdCol]!='-')
                                {
                                    StoleTreasure(cmdRow, cmdCol);
                                }
                            }
                            break;
                        case "down":
                            for (int i = 0; i < 3; i++)
                            {
                                cmdRow++;
                                if (IsIndexValid(cmdRow, cmdCol) && field[cmdRow][cmdCol] != '-')
                                {
                                    StoleTreasure(cmdRow, cmdCol);
                                }
                            }
                            break;
                        case "left":
                            for (int i = 0; i < 3; i++)
                            {
                                cmdCol--;
                                if (IsIndexValid(cmdRow, cmdCol) && field[cmdRow][cmdCol] != '-')
                                {
                                    StoleTreasure(cmdRow, cmdCol);
                                }
                            }
                            break;
                        case "right":
                            for (int i = 0; i < 3; i++)
                            {
                                cmdCol++;
                                if (IsIndexValid(cmdRow, cmdCol) && field[cmdRow][cmdCol] != '-')
                                {
                                    StoleTreasure(cmdRow, cmdCol);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    
                }

            }

        }

        PrintField();
        if (collected.Count==0)
        {
            Console.WriteLine($"Collected seashells: {collected.Count}");
        }
        else
        {
            Console.WriteLine($"Collected seashells: {collected.Count} -> {string.Join(", ", collected)}");
        }        
        Console.WriteLine($"Stolen seashells: {stolenCounter}");
    }

    private static void StoleTreasure(int cmdRow, int cmdCol)
    {
        field[cmdRow][cmdCol] = '-';
        stolenCounter++;
    }

    private static bool IsIndexValid(int cmdRow, int cmdCol)
    {
        return cmdRow >= 0 && cmdRow < field.GetLength(0) && cmdCol >= 0 && cmdCol < field[cmdRow].GetLength(0);
    }

    private static void PrintField()
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            Console.WriteLine(string.Join(" ", field[row]));
        }
    }

    private static void ReadField()
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            field[row] = line.Where(x => x != ' ').ToArray();
        }
    }
}

