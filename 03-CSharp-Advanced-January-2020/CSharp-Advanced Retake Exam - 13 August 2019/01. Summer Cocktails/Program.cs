using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    const int Mimosa = 150;
    const int Daiquiri = 250;
    const int Sunshine = 300;
    const int Mojito = 400;

    private static int mimosaCount = 0;
    private static int daiquiriCount = 0;
    private static int sunshineCount = 0;
    private static int mojitoCount = 0;
    public static void Main()
    {
        int[] inputIngredients = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x != 0).ToArray();
        int[] inputFreshnes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Queue<int> ingredients = new Queue<int>(inputIngredients);
        Stack<int> freshness = new Stack<int>(inputFreshnes);

        while (ingredients.Any() && freshness.Any())
        {
            MixElement(ingredients, freshness);
        }

        PrintOutput(ingredients);

    }

    private static void MixElement(Queue<int> ingredients, Stack<int> freshness)
    {
        int ingredientsFirst = ingredients.Peek();

        int freshnessLast = freshness.Peek();

        int mul = ingredientsFirst * freshnessLast;
        RemoveBoth(ingredients, freshness);

        switch (mul)
        {
            case Mimosa:
                mimosaCount++;

                break;
            case Daiquiri:
                daiquiriCount++;
                break;
            case Sunshine:
                sunshineCount++;
                break;
            case Mojito:
                mojitoCount++;
                break;
            default:
                ingredientsFirst += 5;
                ingredients.Enqueue(ingredientsFirst);
                break;
        }
    }

    private static void PrintOutput(Queue<int> ingredients)
    {
        if (mimosaCount > 0 && daiquiriCount > 0 && sunshineCount > 0 && mojitoCount > 0)
        {
            Console.WriteLine("It's party time! The cocktails are ready!");
        }
        else
        {
            Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
        }
        if (ingredients.Any())
        {
            Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
        }
        if (daiquiriCount > 0)
        {
            Console.WriteLine($"# Daiquiri --> {daiquiriCount}");
        }
        if (mimosaCount > 0)
        {
            Console.WriteLine($"# Mimosa --> {mimosaCount}");
        }
        if (mojitoCount > 0)
        {
            Console.WriteLine($"# Mojito --> {mojitoCount}");
        }
        if (sunshineCount > 0)
        {
            Console.WriteLine($"# Sunshine --> {sunshineCount}");
        }
    }

    private static void RemoveBoth(Queue<int> ingredients, Stack<int> freshness)
    {
        ingredients.Dequeue();
        freshness.Pop();
    }
}

