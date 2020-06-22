using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] fArr = new int[n];
        int[] sArr = new int[n];
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int fNum = int.Parse(input[0]);
            int sNum = int.Parse(input[1]);
            if (i % 2 == 0)
            {
                fArr[i] = fNum;
                sArr[i] = sNum;
            }
            else

            {
                fArr[i] = sNum;
                sArr[i] = fNum;
            }
        }
        Console.WriteLine(string.Join(' ',fArr));
        Console.WriteLine(string.Join(' ', sArr));
    }
}

