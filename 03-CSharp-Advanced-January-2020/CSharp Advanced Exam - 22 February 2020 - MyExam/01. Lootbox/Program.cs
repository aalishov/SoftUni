using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

        List<int> collectedItem = new List<int>();

        while (firstBox.Any() && secondBox.Any())
        {
            int firstBoxItem = firstBox.Peek();
            int secondBoxItem = secondBox.Peek();

            secondBox.Pop();

            int sum = firstBoxItem + secondBoxItem;
            if (sum % 2 == 0)
            {
                collectedItem.Add(sum);
                firstBox.Dequeue();
                
            }
            else
            {
                firstBox.Enqueue(secondBoxItem);
            }
        }
        if (!firstBox.Any())
        {
            Console.WriteLine("First lootbox is empty");
        }
        else
        {
            Console.WriteLine("Second lootbox is empty");
        }

        int collectedItemSum = collectedItem.Sum();
        if (collectedItemSum >= 100)
        {
            Console.WriteLine($"Your loot was epic! Value: {collectedItemSum}");
        }
        else
        {
            Console.WriteLine($"Your loot was poor... Value: {collectedItemSum}");
        }
    }
}

