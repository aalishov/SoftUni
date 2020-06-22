using System;


class Program
{
    public static char[][] field;
    public static int playerRow = -1;
    public static int playerCol = -1;
    public static int finishRow = -1;
    public static int finishCol = -1;

    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());

        int countOfCommands = int.Parse(Console.ReadLine());

        field = new char[fieldSize][];

        ReadField(fieldSize);

        SearchPlayerAndFinish(fieldSize);

        bool isBonus = false;
        string cmd = string.Empty;
        int previousRow = -1;
        int previousCol = -1;


        while (countOfCommands > 0)
        {
            if (!isBonus)
            {
                previousRow = playerRow;
                previousCol = playerCol;
                cmd = Console.ReadLine();

            }         

            Move(fieldSize, cmd);

            if (field[playerRow][playerCol] == '-')
            {
                isBonus = false;
                field[previousRow][previousCol] = '-';
                field[playerRow][playerCol] = 'f';
            }
            else if (field[playerRow][playerCol] == 'B')
            {
                
                    field[previousRow][previousCol] = '-';
                    isBonus = true;
                    countOfCommands++;                  
            }
            else if (field[playerRow][playerCol] == 'T')
            {                
                playerRow=previousRow;
                playerCol=previousCol;
                isBonus = false;
            }
            else
            {
                field[previousRow][previousCol] = '-';
                field[playerRow][playerCol] = 'f';
                Console.WriteLine("Player won!");
                break;
            }
            countOfCommands--;
        }

        if (countOfCommands == 0)
        {
            Console.WriteLine("Player lost!");
        }

        PrintField(fieldSize);
    }

    private static void Move(int fieldSize, string cmd)
    {
        if (cmd == "up")
        {
            if (playerRow <= 0)
            {
                playerRow = fieldSize - 1;
            }
            else
            {
                playerRow--;
            }
        }
        else if (cmd == "down")
        {
            if (playerRow+1 >= fieldSize)
            {
                playerRow = 0;
            }
            else
            {
                playerRow++;
            }
        }
        else if (cmd == "left")
        {
            if (playerCol <= 0)
            {
                playerCol = fieldSize-1;
            }
            else
            {
                playerCol--;
            }
        }
        else if (cmd == "right")
        {
            if (playerCol+1 >= fieldSize)
            {
                playerCol = 0;
            }
            else
            {
                playerCol++;
            }
        }
    }

    private static void SearchPlayerAndFinish(int fieldSize)
    {
        bool isPlayerFound = false;

        for (int row = 0; row < fieldSize; row++)
        {
            for (int col = 0; col < fieldSize; col++)
            {
                if (field[row][col] == 'f')
                {
                    playerRow = row;
                    playerCol = col;
                    isPlayerFound = true;
                }
            }
        }
    }

    private static void PrintField(int fieldSize)
    {
        for (int i = 0; i < fieldSize; i++)
        {
            Console.WriteLine(string.Join("", field[i]));
        }
    }

    private static void ReadField(int fieldSize)
    {
        for (int i = 0; i < fieldSize; i++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            field[i] = line;
        }
    }
}

