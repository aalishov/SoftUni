using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] nums = new int[n, n];
        ReadIntMatrix(nums);

        int sumPrimaryDiagonal = 0;
        int sumSecondaryDiagonal = 0;

        for (int row = 0; row < nums.GetLength(0); row++)
        {
            for (int cow = 0; cow < nums.GetLength(1); cow++)
            {
                if (row==cow)
                {
                    sumPrimaryDiagonal += nums[row, cow];
                    break;
                }
            }
        }

        for (int row = 0; row < nums.GetLength(0); row++)
        {
            for (int cow = 0; cow < nums.GetLength(1); cow++)
            {
                if (row + cow==nums.GetLength(0)-1)
                {
                    sumSecondaryDiagonal += nums[row, cow];
                    break;
                }
            }
        }

        Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));
    }

    private static void ReadIntMatrix(int[,] nums)
    {
        for (int row = 0; row < nums.GetLength(0); row++)
        {
            int[] rowNums = ArrayLineFromConsole();

            for (int cow = 0; cow < nums.GetLength(1); cow++)
            {
                nums[row, cow] = rowNums[cow];
            }
        }
    }

    private static int[] ArrayLineFromConsole()
    {
        return Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}

