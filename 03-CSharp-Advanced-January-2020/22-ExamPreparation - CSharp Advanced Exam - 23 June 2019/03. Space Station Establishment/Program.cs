using System;

class Program
{
    public static void Main()
    {
        int firstHoleRow = -1;
        int firstHoleCol = -1;
        int secondHoleRow = -1;
        int secondHoleCol = -1;

        bool isThereAreHole = false;
        bool isHoleActivate = false;

        int stephanRow = -1;
        int stephanCol = -1;

        int power = 0;

        int size = int.Parse(Console.ReadLine());

        char[,] field = new char[size, size];

        ReadField(field, ref firstHoleRow, ref firstHoleCol, ref secondHoleRow, ref secondHoleCol, ref stephanRow, ref stephanCol, ref isThereAreHole);


        bool isBrake = false;
        while (power < 50 && !isBrake)
        {
            string cmd = Console.ReadLine();

            switch (cmd)
            {
                case "up":
                    if (stephanRow - 1 >= 0)
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        stephanRow--;
                        CollectStars(firstHoleRow, firstHoleCol, secondHoleRow, secondHoleCol, ref stephanRow, ref stephanCol, ref power, field, ref isHoleActivate);
                    }
                    else
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        isBrake = true;
                    }
                    break;
                case "down":
                    if (stephanRow + 1 < field.GetLength(0))
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        stephanRow++;
                        CollectStars(firstHoleRow, firstHoleCol, secondHoleRow, secondHoleCol, ref stephanRow, ref stephanCol, ref power, field, ref isHoleActivate);
                    }
                    else
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        isBrake = true;
                    }
                    break;
                case "left":
                    if (stephanCol - 1 >= 0)
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        stephanCol--;
                        CollectStars(firstHoleRow, firstHoleCol, secondHoleRow, secondHoleCol, ref stephanRow, ref stephanCol, ref power, field, ref isHoleActivate);
                    }
                    else
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        isBrake = true;
                    }
                    break;
                case "right":
                    if (stephanCol + 1 < field.GetLength(1))
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        stephanCol++;
                        CollectStars(firstHoleRow, firstHoleCol, secondHoleRow, secondHoleCol, ref stephanRow, ref stephanCol, ref power, field, ref isHoleActivate);
                    }
                    else
                    {
                        ClearPosition(stephanRow, stephanCol, field);
                        isBrake = true;
                    }
                    break;
            }
        }
        if (isBrake)
        {
            Console.WriteLine("Bad news, the spaceship went to the void.");
        }
        else
        {
            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
        }

        
        Console.WriteLine($"Star power collected: {power}");
        PrintField(field);
    }

    private static void ClearPosition(int stephanRow, int stephanCol, char[,] field)
    {
        field[stephanRow, stephanCol] = '-';
    }

    private static void CollectStars(int firstHoleRow, int firstHoleCol, int secondHoleRow, int secondHoleCol, ref int stephanRow, ref int stephanCol, ref int power, char[,] field, ref bool isHoleActivate)
    {
        if (int.TryParse(field[stephanRow, stephanCol].ToString(), out int value))
        {
            power += value;
            field[stephanRow, stephanCol] = 'S';
        }
        else if (!isHoleActivate)
        {
            isHoleActivate = true;
            if (IsOnFirstHole(firstHoleRow, firstHoleCol, stephanRow, stephanCol))
            {
                field[stephanRow, stephanCol] = '-';
                stephanRow = secondHoleRow;
                stephanCol = secondHoleCol;
                field[stephanRow, stephanCol] = 'S';
            }
            else if (IsOnSecHole(secondHoleRow, secondHoleCol, stephanRow, stephanCol))
            {
                field[stephanRow, stephanCol] = '-';
                stephanRow = firstHoleRow;
                stephanCol = firstHoleCol;
                field[stephanRow, stephanCol] = 'S';
            }
        }
        else
        {
            field[stephanRow, stephanCol] = 'S';
        }
    }

    private static void ReadField(char[,] field, ref int firstHoleRow, ref int firstHoleCol, ref int secHoleRow, ref int secHoleCol, ref int stephanRow, ref int stephanCol, ref bool isThereAreHole)
    {
        int countHole = 0;
        for (int i = 0; i < field.GetLength(0); i++)
        {
            char[] fieldLine = Console.ReadLine().ToCharArray();

            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = fieldLine[j];
                if (field[i, j] == 'O')
                {
                    if (countHole == 0)
                    {
                        firstHoleRow = i;
                        firstHoleCol = j;
                        countHole++;
                        isThereAreHole = true;
                    }
                    else
                    {
                        secHoleRow = i;
                        secHoleCol = j;
                    }
                }
                if (field[i, j] == 'S')
                {
                    stephanRow = i;
                    stephanCol = j;
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

    private static bool IsOnFirstHole(int firstHoleRow, int firstHoleCol, int stRow, int stCol)
    {
        if (stRow == firstHoleRow && stCol == firstHoleCol)
        {
            return true;
        }
        return false;
    }

    private static bool IsOnSecHole(int secHoleRow, int sectHoleCol, int stRow, int stCol)
    {
        if (stRow == secHoleRow && stCol == sectHoleCol)
        {
            return true;
        }
        return false;
    }
}

