using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            string result = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = Sum(arr, 0, i);
                int rightSum = Sum(arr, i + 1, arr.Length);
                if (leftSum==rightSum)
                {
                    result = i + " ";
                }
            }
            if (result!=string.Empty)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        static int Sum(int[] inputArr,int startIndex, int endIdex)
        {
            int sum = 0;
            for (int i = startIndex; i < endIdex; i++)
            {
                sum += inputArr[i];
            }
            return sum;
        }
    }
}
