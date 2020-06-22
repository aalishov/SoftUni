using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int sequenceLenght = int.Parse(Console.ReadLine());
        string[] arr = new string[sequenceLenght];

        int subSequenceLenght = -1;
        int subSequenceIndex = -1;
        int sequenceSum = 0;
        int sequenceNumber = 0;
        string[] dnaArr = new string[sequenceLenght];
        int count = 0;

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Clone them!")
            {
                break;
            }
            arr = line.Split('!', StringSplitOptions.RemoveEmptyEntries).ToArray();
            count++;
            var info = OneInfo(arr);
            if (subSequenceLenght < info.lenght)
            {
                subSequenceLenght = info.lenght;
                subSequenceIndex = info.index;
                sequenceSum = info.sum;
                dnaArr = arr;
                sequenceNumber = count;
            }
            else if (subSequenceLenght == info.lenght && info.index < subSequenceIndex)
            {
                subSequenceLenght = info.lenght;
                subSequenceIndex = info.index;
                sequenceSum = info.sum;
                dnaArr = arr;
                sequenceNumber = count;
            }
            else if (subSequenceLenght == info.lenght && info.index == subSequenceIndex && info.sum > sequenceSum)
            {
                subSequenceLenght = info.lenght;
                subSequenceIndex = info.index;
                sequenceSum = info.sum;
                dnaArr = arr;
                sequenceNumber = count;
            }

        }
        Console.WriteLine($"Best DNA sample {sequenceNumber} with sum: {sequenceSum}.");
        Console.WriteLine(string.Join(' ', dnaArr));
    }
    public static (int lenght, int index, int sum) OneInfo(string[] inputArr)
    {
        int maxLenght = 0;
        int index = 0;
        int sum = 0;
        int currentLenght = 0;

        for (int i = 0; i < inputArr.Length; i++)
        {
            if (inputArr[i] == "1")
            {
                currentLenght++;
            }
            else
            {
                currentLenght = 0;
            }
            if (currentLenght >= maxLenght)
            {
                maxLenght = currentLenght;
                index = i;                
            }
            sum += int.Parse(inputArr[i]);
        }

        return (maxLenght, index, sum);
    }
}

