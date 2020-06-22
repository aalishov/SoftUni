using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        for (int i = 0; i < arr.Length-1; i++)
        {
            int count = 0;
            for (int j = i+1; j < arr.Length; j++)
            {                
                if (arr[i]>arr[j])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            if (count==arr.Length-i-1)
            {
                Console.Write(arr[i]+" ");
            }
        }
        Console.Write(arr[arr.Length-1]);
        Console.WriteLine();
    }
}

