using System;

class Program
{
    static void Main()
    {
        int partySize = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int profit = 0;

        for (int i = 1; i <= days; i++)
        {
            if (i % 10 == 0)
            {
                partySize -= 2;
            }
            if (i % 15 == 0)
            {
                partySize += 5;
            }
            profit += 50;
            profit -= (2 * partySize);
            if (i % 3 == 0)
            {
                profit -= 3 * partySize;
            }
            if (i % 5 == 0 )
            {
                profit += 20 * partySize;
                if (i%3==0)
                {
                    profit -= 2 * partySize;
                }
            }

        }
        Console.WriteLine($"{partySize} companions received {profit/partySize} coins each.");
    }
}

