using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine()
            .Split(' ')
            .Select(x => int.Parse(x))
            .ToArray();
        int rotateNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < rotateNumber; i++)
        {
            arr = Rotate(arr);
        }
        Console.WriteLine(string.Join(' ',arr));
    }
    static int[] Rotate(int[] inputArr)
    {
        int[] result = new int[inputArr.Length];
        result[result.Length - 1] = inputArr[0];
        for (int i = 0; i < inputArr.Length-1; i++)
        {
            result[i] = inputArr[i + 1];
        }
        return result;
    }
}

