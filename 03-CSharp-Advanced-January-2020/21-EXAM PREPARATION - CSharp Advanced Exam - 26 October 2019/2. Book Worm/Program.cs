using System;
using System.Text;

public class Program
{
    static void Main()
    {
        StringBuilder initialString = new StringBuilder(Console.ReadLine());

        int fieldSize = int.Parse(Console.ReadLine());

        char[,] field = new char[fieldSize, fieldSize];

        int startCol = 0;
        int startRow = 0;

        for (int j = 0; j < fieldSize; j++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int k = 0; k < fieldSize; k++)
            {
                field[j, k] = line[k];
                if (line[k] == 'P')
                {
                    startRow = j;
                    startCol = k;
                }
            }
        }

        while (true)
        {
            string cmd = Console.ReadLine();
            if (cmd == "end")
            {
                Console.WriteLine(initialString);
                PrintArr(fieldSize, field);
                break;
            }
            
            switch (cmd)
            {                
                case "up":
                    if (startRow - 1 >= 0)
                    {
                        MoveUp(field, startRow, startCol, initialString);
                        startRow--;
                    }
                    else
                    {
                        EatLetter(initialString);
                    }                  
                    break;
                case "down":
                    if (startRow + 1 < fieldSize)
                    {
                        MoveDown(field, startRow, startCol, initialString);
                        startRow++;
                    }
                    else
                    {
                        EatLetter(initialString);
                    }
                    break;
                case "left":
                    if (startCol - 1 >= 0)
                    {
                        MoveLeft(field, startRow, startCol, initialString);
                        startCol--;
                    }
                    else
                    {
                        EatLetter(initialString);
                    }
                    break;
                case "right":
                    if (startCol + 1 < fieldSize)
                    {
                        MoveRight(field, startRow, startCol, initialString);
                        startCol++;
                    }
                    else
                    {
                        EatLetter(initialString);
                    }
                    break;
            }
        }

        
    }

    private static void EatLetter(StringBuilder initialString)
    {
        if (initialString.Length>0)
        {
            initialString.Remove(initialString.Length - 1, 1);
        }
    }

    private static void PrintArr(int fieldSize, char[,] field)
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine(); ;
        }
    }

    private static void MoveRight(char[,] field, int startRow, int startCol, StringBuilder initialString)
    {
        field[startRow, startCol] = '-';
        startCol++;
        if (field[startRow, startCol] != '-')
        {
            initialString.Append(field[startRow, startCol]);
        }
        field[startRow, startCol] = 'P';
    }

    private static void MoveLeft(char[,] field, int startRow, int startCol, StringBuilder initialString)
    {
        field[startRow, startCol] = '-';
        startCol--;
        if (field[startRow, startCol] != '-')
        {
            initialString.Append(field[startRow, startCol]);
        }
        field[startRow, startCol] = 'P';
    }

    private static void MoveDown(char[,] field, int startRow, int startCol, StringBuilder initialString)
    {
        field[startRow, startCol] = '-';
        startRow++;
        if (field[startRow, startCol] != '-')
        {
            initialString.Append(field[startRow, startCol]);
        }
        field[startRow, startCol] = 'P';
    }

    private static void MoveUp(char[,] field, int startRow, int startCol, StringBuilder initialString)
    {
        field[startRow, startCol] = '-';
        startRow--;
        if (field[startRow, startCol] != '-')
        {
            initialString.Append(field[startRow, startCol]);
        }
        field[startRow, startCol] = 'P';
    }

}
