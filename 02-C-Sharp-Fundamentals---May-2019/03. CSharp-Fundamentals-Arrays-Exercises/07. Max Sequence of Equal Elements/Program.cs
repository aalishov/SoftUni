using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int count = 1;
        int maxCount = 0;
        int repeatNum = 0;
        for (int i = 0; i < arr.Length-1; i++)
        {
            bool isLast = false;
            bool isOutIf = true;
            if (arr[i]==arr[i+1])
            {
                count++;
                if (i+1==arr.Length-1)
                {
                    isLast = true;
                }
                isOutIf = false;
            }
            if(isLast||isOutIf)
            {                
                if (count>maxCount)
                {
                    maxCount = count;
                    repeatNum = arr[i];
                }
                count = 1;
            }
        }
        for (int i = 0; i < maxCount; i++)
        {
            Console.Write(repeatNum+" ");
        }
        Console.WriteLine();
    }
}

