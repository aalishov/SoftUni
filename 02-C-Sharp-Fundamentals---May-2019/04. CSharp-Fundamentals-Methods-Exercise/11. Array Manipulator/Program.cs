using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        
    }
    public static int[] Exchange(int[] numbers, int index)
    {
        int[] resultArr = new int[numbers.Length];
        int counter = 0;

        for (int i = index + 1; i < numbers.Length; i++)
        {
            resultArr[counter] = numbers[i];
            counter++;
        }
        for (int j = 0; j <= index; j++)
        {
            resultArr[counter] = numbers[j];
            counter++;
        }
        return resultArr;
    }


}

