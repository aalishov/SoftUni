using System;

public class Program
{
    public static void Main()
    {
        int presentCount = int.Parse(Console.ReadLine());
        int fieldSize = int.Parse(Console.ReadLine());

        char[,] field = new char[fieldSize, fieldSize * 2];

        int colIndex = 0;
        int rowIndex = 0;
        int goodChildrens = 0;
        int goodChildrensGift = 0;

        ReadField(fieldSize, field, ref colIndex, ref rowIndex, ref goodChildrens);

        bool isOut = false;
        while (true)
        {
            if (isOut || presentCount <= 0 )
            {
                Console.WriteLine("Santa ran out of presents!");
                break;
            }

            string cmd = Console.ReadLine();
            if (cmd == "Christmas morning" )
            {
                break;
            }

            switch (cmd)
            {
                case "up":
                    if (rowIndex - 1 >= 0)
                    {
                        field[rowIndex, colIndex] = '-';
                        rowIndex--;
                        GaveGift(ref presentCount, field, colIndex, rowIndex, ref goodChildrensGift);
                        field[rowIndex, colIndex] = 'S';
                    }
                    else
                    {
                        isOut = true;
                    }
                    break;
                case "down":
                    if (rowIndex + 1 < field.GetLength(0))
                    {
                        field[rowIndex, colIndex] = '-';
                        rowIndex++;
                        GaveGift(ref presentCount, field, colIndex, rowIndex, ref goodChildrensGift);
                        field[rowIndex, colIndex] = 'S';
                    }
                    else
                    {
                        isOut = true;
                    }
                    break;
                case "left":
                    if (colIndex - 2 >= 0)
                    {
                        field[rowIndex, colIndex] = '-';
                        colIndex -= 2;
                        GaveGift(ref presentCount, field, colIndex, rowIndex, ref goodChildrensGift);
                        field[rowIndex, colIndex] = 'S';
                    }
                    else
                    {
                        isOut = true;
                    }
                    break;
                case "right":
                    if (colIndex + 2 < field.GetLength(1))
                    {
                        field[rowIndex, colIndex] = '-';
                        colIndex += 2;
                        GaveGift(ref presentCount, field, colIndex, rowIndex, ref goodChildrensGift);
                        field[rowIndex, colIndex] = 'S';
                    }
                    else
                    {
                        isOut = true;
                    }
                    break;
            }
        }
        int goodChildrenWithoutPresent = 0;

        for (int j = 0; j < field.GetLength(0); j++)
        {
            for (int k = 0; k < field.GetLength(1); k++)
            {
                if (field[j, k] == 'V')
                {
                    goodChildrenWithoutPresent++;
                }
            }
        }

        PrintField(field);

        if (goodChildrenWithoutPresent==0)
        {
            Console.WriteLine($"Good job, Santa! {goodChildrensGift} happy nice kid/s.");
        }
        else
        {
            Console.WriteLine($"No presents for {Math.Abs(goodChildrens - goodChildrensGift)} nice kid/s.");
        }

       
    }

    private static void GaveGift(ref int presentCount, char[,] field, int colIndex, int rowIndex,ref int goodChildrenCount)
    {
        if (field[rowIndex, colIndex] == 'V')
        {
            goodChildrenCount++;
            presentCount--;
        }
        else if (field[rowIndex, colIndex] == 'C')
        {
            if (field[rowIndex + 1, colIndex] != '-')
            {
                if (field[rowIndex+1, colIndex] == 'V')
                {
                    goodChildrenCount++;
                }
                field[rowIndex+1 , colIndex] = '-';
                presentCount--;
            }
            if (field[rowIndex - 1, colIndex] != '-')
            {
                if (field[rowIndex -1, colIndex] == 'V')
                {
                    goodChildrenCount++;
                }
                field[rowIndex-1, colIndex] = '-';
                presentCount--;
            }
            if (field[rowIndex, colIndex + 2] != '-')
            {
                if (field[rowIndex , colIndex+2] == 'V')
                {
                    goodChildrenCount++;
                }
                field[rowIndex, colIndex+2] = '-';
                presentCount--;
            }
            if (field[rowIndex, colIndex - 2] != '-')
            {
                if (field[rowIndex, colIndex-2] == 'V')
                {
                    goodChildrenCount++;
                }
                field[rowIndex, colIndex-2] = '-';
                presentCount--;
            }
        }
    }

    private static void ReadField(int fieldSize, char[,] field, ref int colIndex, ref int rowIndex, ref int goodChildrens)
    {
        for (int j = 0; j < fieldSize; j++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int k = 0; k < line.Length; k++)
            {
                field[j, k] = line[k];
                if (line[k] == 'S')
                {
                    rowIndex = j;
                    colIndex = k;
                }
                else if (line[k] == 'V')
                {
                    goodChildrens++;
                }
            }
        }
    }

    private static void PrintField(char[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }


}



